using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    public class Answer
    {
        public string text;
        public bool correct;

        public Answer(string answertext = "", bool isCorrect = false)
        {
            this.text = answertext;
            this.correct = isCorrect;
        }
    }
}
