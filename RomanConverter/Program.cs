using System;
using System.Diagnostics;
using System.Text;

namespace Softwaredesign
{
    class Program
    {
        static int inp;
        static string[,] romanDigits =
        {
                    {"CM", "D", "CD", "C"},
                    {"XC", "L", "DL", "X"},
                    {"IX", "V", "IV", "I"},
        };

        static int[,] divisionSteps =
        {
                    {900, 500, 400, 100},
                    {90, 50, 40, 10},
                    {9, 5, 4, 1},
        };

        static void Main(string[] args)
        {
            try
            {
                inp = int.Parse(args[0]);
                if (inp < 1000 && inp > 0)
                {
                    Console.WriteLine(GetRomanNumber(inp));
                }
                else
                {
                    Console.WriteLine("Input muss aus einer Zahl zwischen 0 und 1000 bestehen");
                }
            }
            catch (FormatException e)
            {
                Console.Write(e.Message);
                Console.WriteLine("Input darf nur aus zahlen bestehen");
            }                                    
        }
        
        static string GetRomanNumber(int inp)
        {
            StringBuilder sb = new StringBuilder();

            for (int phase = 0; phase < 3; phase++)
            {
                for (int step = 0; step < 3; step++)
                {
                    if (inp >= divisionSteps[phase, step])
                    {     //false
                        sb.Append(romanDigits[phase, step]);
                        inp -= divisionSteps[phase, step];
                    }
                }

                if (inp >= divisionSteps[phase, 3])
                {     // true
                    do
                    {
                        sb.Append(romanDigits[phase, 3]);    // "DCC"
                        inp -= divisionSteps[phase, 3]; // inp = 48
                    }
                    while (inp >= divisionSteps[phase, 3]);
                }
            }
            return sb.ToString();
        }
    }
}















