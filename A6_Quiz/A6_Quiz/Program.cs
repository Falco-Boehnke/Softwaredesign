using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_Quiz
{
    class Program
    {
        static int points = 0, attemptedQuestions = 0;
        static bool isQuizGameRunning;
        static List<QuizQuestion> allQuestions, answeredQuestions;
        static void Main(string[] args)
        {            
            addDefaultQuestions();            
            startGame();
        }

        static void addDefaultQuestions()
        {
            allQuestions = new List<QuizQuestion>();
            answeredQuestions = new List<QuizQuestion>();

            QuizQuestion question1 = new QuizQuestion("Wie weit befindet sich die Sonne von der Erde?");
            question1.answers.Add(new Answer("150 Millionen Kilometer", true));
            question1.answers.Add(new Answer("600 Millionen Kilometer", false));
            question1.answers.Add(new Answer("20 Millionen Kilometer", false));
            question1.answers.Add(new Answer("Die Distanz zwischen Furtwangen und schönem Wetter", false));
            
            QuizQuestion question2 = new QuizQuestion("Welche der Planeten im Sonnensystem passen in den Platz zwischen Mond und Erde?");
            question2.answers.Add(new Answer("Merkur, Venus und Mars", false));
            question2.answers.Add(new Answer("Jupiter", false));
            question2.answers.Add(new Answer("Uranus", false));
            question2.answers.Add(new Answer("Alle", true));
            question2.answers.Add(new Answer("Jupiter, Mars und Saturn", false));

            QuizQuestion question3 = new QuizQuestion("Was ist das beste Haustier?");
            question3.answers.Add(new Answer("Hund", true));
            question3.answers.Add(new Answer("Katze", true));
            question3.answers.Add(new Answer("Vogel", true));

            QuizQuestion question4 = new QuizQuestion("Wer ist der/die schönste Person?");
            question4.answers.Add(new Answer("Usain Bolt", false));
            question4.answers.Add(new Answer("Terry Crews", false));
            question4.answers.Add(new Answer("Keira Knightley", false));
            question4.answers.Add(new Answer("Meghan Markle", false));
            question4.answers.Add(new Answer("Du", true));

            QuizQuestion question5 = new QuizQuestion("Ist es nachts kälter als draußen?");
            question5.answers.Add(new Answer("Ja", false));
            question5.answers.Add(new Answer("Nein", false));

            QuizQuestion question6 = new QuizQuestion("Ryzen oder Intel?");
            question6.answers.Add(new Answer("Ryzen", true));
            question6.answers.Add(new Answer("Intel", true));

            allQuestions.Add(question1);
            allQuestions.Add(question2);
            allQuestions.Add(question3);
            allQuestions.Add(question4);
            allQuestions.Add(question5);
            allQuestions.Add(question6);
        }

        
        static void startGame()
        {  
            isQuizGameRunning = true;
            Console.WriteLine("Willkommen zum Super-Extreme Ultra Stealth Fusion Quiz!");

            do
            {
                Console.WriteLine();
                Console.Write("Momentaner Punktestand: " + points + " " + "Versuchte Fragen: " + attemptedQuestions);
                if(attemptedQuestions != 0)
                    Console.Write("(" +((float)points/(float)attemptedQuestions)*100 + "%)");
                Console.WriteLine();
                Console.WriteLine("Wollen sie: ");
                Console.WriteLine("Eine Frage beantworten (1)");
                Console.WriteLine("Eine Frage eintragen (2)");
                Console.WriteLine("Das Quiz beenden (3)");

                // Console.Read returns integer CODE of character being read
                // To get actual value you have to subtract 48, or use Readline and Parse
                // https://stackoverflow.com/questions/32050026/wrong-integer-output-on-console-read
                int decision = Int32.Parse(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        answerQuestion();
                        break;
                    case 2:
                        insertQuestion();
                        break;
                    case 3:
                        isQuizGameRunning = false;
                        Console.WriteLine("Thanks for playing.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    // default braucht break sonst error?!
                    default:
                        Console.WriteLine("Unbekannte Antwort, bitte wiederholen");
                        break;
                }
            } while (isQuizGameRunning);

        }


        public static void insertQuestion()
        {
            Console.WriteLine("Bitte geben sie Ihren Fragentext ein:");

            string questiontext = Console.ReadLine();
            
            QuizQuestion newQuestionToImplement = new QuizQuestion(questiontext);

            Console.WriteLine("Jede Frage benötigt mindestens zwei mögliche Antworten.");
            Console.WriteLine("Wieviele optionale Antwortmöglichkeiten möchten Sie dazu hinzufügen? (0 eingeben wenn Sie nur zwei Antworten eintragen möchten)");

            int answerCount = Int32.Parse(Console.ReadLine());
            if (answerCount == 0)
                newQuestionToImplement.addRequiredAnswers();
            else
            {
                newQuestionToImplement.minRequiredAnswers += answerCount;
                newQuestionToImplement.addRequiredAnswers();
            }

            allQuestions.Add(newQuestionToImplement);

        }

        private static void answerQuestion()
        {

            checkIfQuestionsHaveToBeRecycled();

            Random r = new Random();
            int randomInt = r.Next(allQuestions.Count);

            bool answerCorrectOrNah = allQuestions[randomInt].askQuestionAndShowAnswers();

            if (answerCorrectOrNah)
            {
                points++;
                Console.WriteLine("Korrekte Antwort");
            }
            else
                Console.WriteLine("YOU FAILED. YOU LOST YOUR SOUL.");

            removeQuestionFromPool(allQuestions[randomInt]);
            attemptedQuestions++;
        }

        #region Prevent question repetition until all are answered
        static void removeQuestionFromPool(QuizQuestion toRemove)
        {
            answeredQuestions.Add(toRemove);
            allQuestions.Remove(toRemove);
        }
        static void checkIfQuestionsHaveToBeRecycled()
        {
            if (allQuestions.Count <= 2)
            {
                foreach (QuizQuestion question in answeredQuestions)
                    allQuestions.Add(question);
                foreach (QuizQuestion question in allQuestions)
                    answeredQuestions.Remove(question);
            }
        }
        #endregion
    }



    public class QuizQuestion
    {
        public string questionText;
        public List<Answer> answers;
        public int minRequiredAnswers = 2;

        public QuizQuestion(string questionText)
        {
            this.questionText = questionText;
            answers = new List<Answer>(); 
        }

        
        public void addRequiredAnswers()
        {
            while (!minimumQuestionsReached())
            {
                try
                {
                    bool isCorrect;
                    int correctOrNah;

                    Console.WriteLine("Bitte geben sie jetzt ihren Antworttext ein: ");
                    string answerText = Console.ReadLine();

                    Console.WriteLine("Ist die Antwort korrekt (1) oder inkorrekt (2)?");
                    correctOrNah = Int32.Parse(Console.ReadLine());
                    if (correctOrNah == 1)
                        isCorrect = true;
                    else
                        isCorrect = false;

                    answers.Add(new Answer(answerText, isCorrect));
                    Console.WriteLine("Answer added. Current Answercount: " + answers.Count);
                    Console.WriteLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Falsche Eingabe. Bitte Fließtext und Ganzahl zur Optionsauswahl eingeben.");
                    Console.WriteLine();
                    addRequiredAnswers();
                }
            }
        }
        private bool minimumQuestionsReached()
        {
            if (answers.Count < minRequiredAnswers)
                return false;
            return true;
        }

        public bool askQuestionAndShowAnswers()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Frage: " + questionText);
            Console.WriteLine();
            int questionCount = 1;
            foreach (Answer answer in answers)
            {
                Console.WriteLine(String.Format("Antwort ({0}): {1}", questionCount, answer.answerText));
                questionCount++;
            }

            Console.WriteLine("Wie lautet Ihre Antwort?");
            int chosenAnswer = Int32.Parse(Console.ReadLine());

            if (answers[chosenAnswer - 1].isCorrect)
            {
                return true;
            }
            else
                return false;
        }
    }

    public class Answer
    {
        public string answerText;
        public bool isCorrect;
       
        public Answer(string answerText, bool correctAnswer)
        {
            this.answerText = answerText;
            this.isCorrect = correctAnswer;
        }
    }
}
