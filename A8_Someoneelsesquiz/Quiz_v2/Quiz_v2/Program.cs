using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class Program
    {
        public static List<Quizelement> questions;
        public static int points;
        static void Main(string[] args)
        {
            questions = new List<Quizelement>();
            sampleQuestions();
            callToAction();
        }

        static void sampleQuestions()
        {
            Quizelement sampleQuestion = new QuizSingle();
            sampleQuestion.question = "Welche der Planeten im Sonnensystem passen in den Platz zwischen Mond und Erde?";
            sampleQuestion.answers.Add(new Answer("Merkur, Venus und Mars", false));
            sampleQuestion.answers.Add(new Answer("Jupiter", false));
            sampleQuestion.answers.Add(new Answer("Uranus", false));
            sampleQuestion.answers.Add(new Answer("Alle", true));
            sampleQuestion.answers.Add(new Answer("Jupiter, Mars und Saturn", false));
            questions.Add(sampleQuestion);

            sampleQuestion = new QuizMultiple();
            sampleQuestion.question = "Welche GamePublishers haben im Jahr 2018 vollkommen versagt?";
            sampleQuestion.answers.Add(new Answer("EA", true));
            sampleQuestion.answers.Add(new Answer("Bethesda", true));
            sampleQuestion.answers.Add(new Answer("Ubisoft", true));
            sampleQuestion.answers.Add(new Answer("Activision", true));
            sampleQuestion.answers.Add(new Answer("Nochmal EA", true));
            sampleQuestion.answers.Add(new Answer("Nochmal Bethesda", true));
            sampleQuestion.answers.Add(new Answer("Ein drittes Mal Bethesda", true));
            sampleQuestion.answers.Add(new Answer("Frontier Developments", false));
            sampleQuestion.answers.Add(new Answer("Toby Fox", false));
            sampleQuestion.answers.Add(new Answer("MotionTwin", false));
            questions.Add(sampleQuestion);

            sampleQuestion = new QuizBinary();
            sampleQuestion.question = "Ist es nachts kälter als draußen?";
            sampleQuestion.answers.Add(new Answer("", true));
            sampleQuestion.answers.Add(new Answer("", false));
            questions.Add(sampleQuestion);

            sampleQuestion = new QuizGuess();
            sampleQuestion.question = "Wieviele Kisten Bier passen ca. in einen VW Golf 5?";
            sampleQuestion.answers.Add(new Answer("5"));
            questions.Add(sampleQuestion);

            sampleQuestion = new QuizFree();
            sampleQuestion.question = "Wie heißt der baumartige Charakter aus Filmen wie Guardians of the Galaxy, Avengers: Infinity War, und Guardians of the Galaxy Volume 2?";
            sampleQuestion.answers.Add(new Answer("Groot"));


        }

        static void callToAction()
        {
            bool quizRunning = true;

            while (quizRunning)
                {
                Console.WriteLine();
                Console.WriteLine("Punkte: " + points);
                Console.WriteLine();
                Console.WriteLine("Action auswählen");
                Console.WriteLine("(1) Frage einfügen");
                Console.WriteLine("(2) Frage beantwroten");
                Console.WriteLine("(3) Beenden");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "1":
                        AddQuestion();
                        break;
                    case "2":
                        AskQuestion();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye");
                        quizRunning = false;
                        break;
                    
                }
            }
        }

        static void AskQuestion()
        {
            Random r = new Random();
            int whichQuestion = r.Next(questions.Count);

            bool failureOrWin = questions[whichQuestion].show();

            if (failureOrWin)
            {
                points++;
                Console.WriteLine("Korrekte Antwort!");
            }
            else
                Console.WriteLine("Falsche Antwort");

        }

        static void AddQuestion()
        {
            Console.WriteLine("Welche Art von Frage wollen Sie hinzufügen?");
            Console.WriteLine("(1) Freitext-Frage");
            Console.WriteLine("(2) Ja/Nein Frage");
            Console.WriteLine("(3) SingleChoice Frage");
            Console.WriteLine("(4) MultipleChoice Frage");
            Console.WriteLine("(5) Schätz Frage");

            string decision = Console.ReadLine();

            switch (decision)
            {
                case "1":
                    Quizelement freeText = new QuizFree();
                    freeText.createElement();
                    questions.Add(freeText);
                    break;
                case "2":
                    Quizelement binaryQuestion = new QuizBinary();
                    binaryQuestion.createElement();
                    questions.Add(binaryQuestion);
                    break;
                case "3":
                    Quizelement singleChoice = new QuizSingle();
                    singleChoice.createElement();
                    questions.Add(singleChoice);
                    break;
                case "4":
                    Quizelement multiChoice = new QuizMultiple();
                    multiChoice.createElement();
                    questions.Add(multiChoice);
                    break;
                case "5":
                    Quizelement guessQuestion = new QuizGuess();
                    guessQuestion.createElement();
                    questions.Add(guessQuestion);
                    break;

            }
        }
    }
}
