using System;
using System.Diagnostics;
using System.Text;

namespace Softwaredesign
{
    class Program
    {
        static int inp;
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
        static string GetRomanHundred() {
            StringBuilder sb = new StringBuilder();
            if (inp >= 900)
            {     //false
                sb.Append("CM");
                inp -= 900;
            }
            if (inp >= 500)
            {     // true
                sb.Append("D");        //"D"
                inp -= 500;     // inp = 248
            }
            if (inp >= 400)
            {     //false
                sb.Append("CM");
                inp -= 400;
            }

            if (inp >= 100)
            {     // true
                do
                {
                    sb.Append("C");    // "DCC"
                    inp -= 100; // inp = 48
                }
                while (inp >= 100);
            }

            return sb.ToString();
        }

        static string GetRomanTenth() {
            StringBuilder sb = new StringBuilder();
            if (inp >= 90)
            {  //false
                sb.Append("XC");
                inp -= 90;
            }
            if (inp >= 50)
            {  // false
                sb.Append("L");
                inp -= 50;
            }
            if (inp >= 40)
            {  // true
                sb.Append("XL");   // DCCXL
                inp -= 40;  // inp = 8
            }

            if (inp >= 10)
            {  // false
                while (inp >= 10)
                {
                    sb.Append("X");
                    inp -= 10;
                }
            }
            return sb.ToString();
        }

        static string GetRomanOne() {
            StringBuilder sb = new StringBuilder();
            if (inp >= 9)
            { // false
                sb.Append("IX");
                inp -= 9;
            }
            if (inp >= 5)
            {   // true
                sb.Append("V");    // "DCCXLV
                inp -= 5;   // inp = 3
            }
            if (inp >= 4)
            {   // false
                sb.Append("IV");
                inp -= 4;
            }

            if (inp >= 1)
            {   // true
                while (inp >= 1)
                {
                    sb.Append("I");    // "DCCXLVIII"
                    inp -= 1; // inp = 0
                }
            }
            return sb.ToString();
        }

        static string GetRomanNumber(int inp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetRomanHundred());
            sb.Append(GetRomanTenth());
            sb.Append(GetRomanOne());

            return sb.ToString();
        }
    }
}















