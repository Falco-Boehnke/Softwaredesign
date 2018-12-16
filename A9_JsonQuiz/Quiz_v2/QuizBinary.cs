using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class QuizBinary : Quizelement
    {

        public override bool IsAnswerCorrect(int choice)
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
        public override bool show()
        {
            Console.WriteLine(question + "Yes(1)/No(0)");
            Console.WriteLine();
            int choice = Int32.Parse(Console.ReadLine());

            return IsAnswerCorrect(choice);
        }

        public override void createElement()
        {
            this.typeOfThis = QuestionType.Binary;
            Console.WriteLine("Bitte Ja/Nein Frage eineben");
            string text = Console.ReadLine();
            this.question = text;

            Console.WriteLine("Antwort korrekt (1) or nah (2)?");
            int choice = Int32.Parse(Console.ReadLine());
            bool correctOrNah = false;

            if (choice == 1)
                correctOrNah = true;


            answers.Add(new Answer("", correctOrNah));
        }
    }
}
