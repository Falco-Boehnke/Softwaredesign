using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class QuizBinary : Quizelement
    {

        public override bool IsAnswerCorrect(int choice)  //der Variablenname ffs ist unverständlch und sollte eher den Zweck erklären 
        {
            bool ffs = false;
            if (choice == 1)
                ffs = true;
            if (choice == 2)
                ffs = false;

            if (ffs == answers[0].correct)
                return true;
            else
                return false;
        }
        public override bool show()         //Methodennamen immer erster Buchstabe groß
        {
            Console.WriteLine(question + "Yes(1)/No(0)");
            Console.WriteLine();
            int choice = Int32.Parse(Console.ReadLine());

            return IsAnswerCorrect(choice);
        }

        public override void createElement()             //Methodennamen immer erster Buchstabe groß
        {
            Console.WriteLine("Bitte Ja/Nein Frage eineben");
            string text = Console.ReadLine();
            this.question = text;

            Console.WriteLine("Antwort korrekt (1) or nah (2)?");
            int choice = Int32.Parse(Console.ReadLine());
            bool correctOrNah = false;                      //Ich verstehe zwar was gemeint ist mit Nah aber ich denke viele andere nicht 

            if (choice == 1)
                correctOrNah = true;


            answers.Add(new Answer("", correctOrNah));
        }
    }
}
