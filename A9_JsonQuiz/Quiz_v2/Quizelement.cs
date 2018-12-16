using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{

    public enum QuestionType
    { Single, Multiple, Guess, Free, Binary, Empty }
    public class Quizelement
    {

        public QuestionType typeOfThis;

        public string question;
        public List<Answer> answers;

        public Quizelement()
        {
            answers = new List<Answer>();
            //question = "Placeholder";
            //typeOfThis = QuestionType.Empty;
            //answers.Add(new Answer("placeholder1", false));
            //answers.Add(new Answer("placeholder2", true));
        }

        public virtual bool IsAnswerCorrect(int correcter)
        {
            switch (typeOfThis)
            {
                case QuestionType.Single:
                    return answers[correcter].correct;                 

                case QuestionType.Multiple:
                    return answers[correcter].correct;

                case QuestionType.Guess:
                    int answerValue = Int32.Parse(answers[0].text);
                    if (correcter >= (answerValue - 10) && correcter <= (answerValue + 10))
                        return true;
                    else
                        return false;

                case QuestionType.Binary:
                    bool ffs = false;
                    if (correcter == 1)
                        ffs = true;
                    if (correcter == 2)
                        ffs = false;

                    if (ffs == answers[0].correct)
                        return true;
                    else
                        return false;
            }
            return false;
        }

        public virtual bool show()
        {
            int answercounter = 0;
            switch (typeOfThis)
            {
                case QuestionType.Single:
                    Console.WriteLine(question);
                    Console.WriteLine();

                    foreach (Answer answerToShow in answers)
                    {
                        Console.WriteLine("(" + answercounter + ") " + answerToShow.text);
                        answercounter++;
                    }

                    int choiceS = Int32.Parse(Console.ReadLine());

                    return IsAnswerCorrect(choiceS);

                case QuestionType.Multiple:
                    Console.WriteLine(question);
                    Console.WriteLine();

                    answercounter = 0;
                    foreach (Answer answerToShow in answers)
                    {
                        Console.WriteLine("(" + answercounter + ") " + answerToShow.text);
                        answercounter++;
                    }

                    int choiceM = Int32.Parse(Console.ReadLine());
                    bool correctChoice = IsAnswerCorrect(choiceM);
                    if (!correctChoice)
                        return false;
                    else
                    {
                        answers.Remove(answers[choiceM]);
                        foreach (Answer remaining 
                            in answers)
                        {
                            if (remaining.correct)
                                show();
                            else
                                return true;

                        }
                    }
                    return false;

                case QuestionType.Guess:
                    Console.WriteLine(question);
                    Console.WriteLine();

                    int choice = Int32.Parse(Console.ReadLine());
                    return IsAnswerCorrect(choice);

                case QuestionType.Binary:
                    Console.WriteLine(question + "Yes(1)/No(0)");
                    Console.WriteLine();
                    int choiceB = Int32.Parse(Console.ReadLine());

                    return IsAnswerCorrect(choiceB);

                    
            }
            return false;
        }

        public virtual void createElement()
        {
            switch (typeOfThis)
            {
                case QuestionType.Single:
                    this.typeOfThis = QuestionType.Single;
                    int indexS = 1;
                    string textS = "";
                    bool correctOrNahS = false;
                    int isCorrectOrNahS;

                    Console.WriteLine("Bitte Frage eingeben: ");
                    textS = Console.ReadLine();
                    this.question = textS;

                    Console.WriteLine("Wieviele Antworten soll die Frage besitzen? (min: 2+n): ");
                    indexS += Int32.Parse(Console.ReadLine());

                    for (int i = 0; i <= indexS; i++)
                    {
                        Console.WriteLine("Bitte Antwort eingeben: ");
                        textS = Console.ReadLine();

                        Console.WriteLine("Ist die Antwort richtig (1) oder falsch (2)");
                        isCorrectOrNahS = Int32.Parse(Console.ReadLine());

                        if (isCorrectOrNahS == 1)
                            correctOrNahS = true;

                        answers.Add(new Answer(textS, correctOrNahS));
                    }
                    break;
                case QuestionType.Multiple:
                    this.typeOfThis = QuestionType.Multiple;
                    int index = 1;
                    string text = "";
                    bool correctOrNah = false;
                    int isCorrectOrNah;

                    Console.WriteLine("Bitte Frage eingeben: ");
                    text = Console.ReadLine();
                    this.question = text;

                    Console.WriteLine("Wieviele Antworten soll die Frage besitzen? (min: 2+n): ");
                    index += Int32.Parse(Console.ReadLine());

                    for (int i = 0; i <= index; i++)
                    {
                        Console.WriteLine("Bitte Antwort eingeben: ");
                        text = Console.ReadLine();

                        Console.WriteLine("Ist die Antwort richtig (1) oder falsch (2)");
                        isCorrectOrNah = Int32.Parse(Console.ReadLine());

                        if (isCorrectOrNah == 1)
                            correctOrNah = true;

                        answers.Add(new Answer(text, correctOrNah));
                    }
                    break;

                case QuestionType.Guess:
                    this.typeOfThis = QuestionType.Guess;
                    Console.WriteLine("Bitte Schätzfrage eingeben: ");
                    string textG = Console.ReadLine();
                    this.question = textG;

                    Console.WriteLine("Bitte Antwortszahl eingeben: ");
                    text = Console.ReadLine();
                    answers.Add(new Answer(text));
                    break;

                case QuestionType.Binary:
                    this.typeOfThis = QuestionType.Binary;
                    Console.WriteLine("Bitte Ja/Nein Frage eineben");
                    string textB = Console.ReadLine();
                    this.question = textB;

                    Console.WriteLine("Antwort korrekt (1) or nah (2)?");
                    int choiceB = Int32.Parse(Console.ReadLine());
                    bool correctOrNahB = false;

                    if (choiceB == 1)
                        correctOrNah = true;
                    answers.Add(new Answer("", correctOrNahB));
                    break;

            }
           


           
        }
    }
}
