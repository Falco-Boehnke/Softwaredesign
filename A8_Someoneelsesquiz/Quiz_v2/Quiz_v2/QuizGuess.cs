using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class QuizGuess : Quizelement
    {

        public override bool IsAnswerCorrect(int choice)
        {
            int answerValue = Int32.Parse(answers[0].text);
            if (choice >= (answerValue - 10) && choice <= (answerValue + 10))
                return true;
            else
                return false;
        }
        public override bool show()
        {
            Console.WriteLine(question);
            Console.WriteLine();

            int choice = Int32.Parse(Console.ReadLine());
            return IsAnswerCorrect(choice);
        }

        public override void createElement()
        {
            Console.WriteLine("Bitte Schätzfrage eingeben: ");
            string text = Console.ReadLine();
            this.question = text;

            Console.WriteLine("Bitte Antwortszahl eingeben: ");
            text = Console.ReadLine();
            answers.Add(new Answer(text));
        }
    }
}
