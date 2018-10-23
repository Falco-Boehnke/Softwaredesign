using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Softwaredesign
{
    class Program
    {
        static int inp;
        // Klasse die als assoziatives Array (Schlüssel -> Wert) fungiert https://de.wikipedia.org/wiki/Assoziatives_Datenfeld
        // Hier mit Datentyp string als Schlüssel und int als Wert "<string,int>"
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

        static void Main(string[] args)
        {
            // Versuche den Code im Block auszuführen, bei einem Ausnahmefehler (Exception), führe den Block "catch" aus
            // Verhindert Absturz des Programms und gibt eine Fehlermeldung zum bugfixen aus
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
            // Notwendig um in C# Strings zusammenzubauen
            StringBuilder sb = new StringBuilder();
            
            // Für jedes [Key,Value]-Paar des Dictonary wird die Schleife einmal durchlaufen
            // Dictonary[Key,Value] wird als variable converterPair[Key,Value] gespeichert um das Dictionary nur einmalig
            // aufrufen zu müssen
            foreach (var converterPair in romanDecimalPairs)
            {
                
                // FEHLER ENTDECKT -> Diese if-Abfrage als zweites und if(converterPair.Value == 100) etc. als erstes
                // verbunden mit elseif
                if (inp >= converterPair.Value)
                {
                    sb.Append(converterPair.Key);
                    inp -= converterPair.Value;
                }
                if (converterPair.Value == 100 || converterPair.Value == 10 || converterPair.Value == 1)
                {
                    // Variable inp ist ein int, daher ist das Ergebnis der Division ebenfalls ein int und
                    // kein cast/parse ist notwendig
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

        static bool isInRange(int valueToCheck)
        {
            return (valueToCheck > 0 && valueToCheck < 1000);
        }
    }
}
