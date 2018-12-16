using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class QuizFree : Quizelement
    {
        public bool IsFreeAnswerCorrect(string userAnswer)
        {
            if (userAnswer == answers[0].text)
                return true;
            else
                return false;
        }

        public override bool show()
        {
            Console.WriteLine(question + "(Antwort als Freitext eingeben)");
            Console.WriteLine();

            string userAnswer = Console.ReadLine();
            return IsFreeAnswerCorrect(userAnswer);        
        }

        public override void createElement()
        {
            this.typeOfThis = QuestionType.Free;
            Console.WriteLine("Bitte Freitext-Frage eingeben: ");
            string text = Console.ReadLine();
            this.question = text;

            Console.WriteLine("Bitte Antwortstext eingeben: ");
            text = Console.ReadLine();
            answers.Add(new Answer(text));
        }
    }
}
