using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    public class Quizelement
    {
        public string question;
        public List<Answer> answers;
        public int correct;
        public string callToAction;

        public Quizelement()
        {
            answers = new List<Answer>();
        }

        public virtual bool IsAnswerCorrect(int correcter)
        {
            return false;
        }

        public virtual bool show()
        {         
            return false;
        }

        public virtual void createElement()
        {

        }
    }
}
