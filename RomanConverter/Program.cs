using System;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Softwaredesign
{
    class Program
    {
        static int inp;

        static Dictionary<string, int> romanDecimalPairs = new Dictionary<string, int>() {
            {"CM", 900},
            {"D",  500},
            {"CD", 400},
            {"C",  100},
            {"XC", 90},
            {"L",  50},
            {"DL", 40},
            {"X",  10},
            {"IX", 9},
            {"V",  5},
            {"IV", 4},
            {"I",  1},
        };
        static bool isInRange(int valueToCheck)
        {
            return (valueToCheck > 0 && valueToCheck < 1000);
        }

        static void Main(string[] args)
        {
            try
            {
                inp = int.Parse(args[0]);
                // cs0173 & cs0201 Error: isInRange(inp) ? Console.WriteLine(GetRomanNumber(inp)) : Console.WriteLine("Input muss aus einer Zahl zwischen 0 und 1000 bestehen");
                if (isInRange(inp))
                    Console.WriteLine(GetRomanNumber(inp));
                else
                    Console.WriteLine("Input muss aus einer Zahl zwischen 0 und 1000 bestehen");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + ". Input darf nur aus zahlen bestehen");
            }                                    
        }
        
        static string GetRomanNumber(int inp)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var converterPair in romanDecimalPairs)
            {
                if (inp >= converterPair.Value)
                {
                    sb.Append(converterPair.Key);
                    inp -= converterPair.Value;
                }
                if (converterPair.Value == 100 || converterPair.Value == 10 || converterPair.Value == 1)
                {   
                    // inp is an int, therefore calculation-result will already be int and no cast/parse is needed
                    int howManyTimes = inp / converterPair.Value;
                    for (int i = 0; i < howManyTimes; i++)
                    {
                        sb.Append(converterPair.Key);
                        inp -= converterPair.Value;
                    }          
                }
            }
            return sb.ToString();
        }
    }
}















