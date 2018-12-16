using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class QuizSingle : Quizelement
    {
        public override bool IsAnswerCorrect(int correcter)
        {
            return answers[correcter].correct;
        }

        public override bool show()
        {
            Console.WriteLine(question);
            Console.WriteLine();

            int answercounter = 0;
            foreach (Answer answerToShow in answers)
            {
                Console.WriteLine("(" + answercounter + ") " + answerToShow.text);
                answercounter++;
            }

            int choice = Int32.Parse(Console.ReadLine());

            return IsAnswerCorrect(choice);
        }

        public override void createElement()
        {
            this.typeOfThis = QuestionType.Single;
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
        }
    }
}
