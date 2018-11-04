using System;

namespace Softwaredesign
{
    class Program
    {
        // Nimmt eine Zahl, deren Zahlensystem und das Zielzahlensystem und konvertiert die Zahl
        int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
        {

            int result = 0;
            // Überschreibt result, da aber beide Funktionen nacheinander aufgerufen werden, wird result nur
            // zu einer konvertierten Zahl für die entsprechende Funktion. Eine DezimalZahl wird von
            // OtherToDecimal nicht verändert, sondern wiedergegeben (bsp: OthertoDecimal(40,10) == 40 ;)
            result = OtherToDecimal(number, fromSystem);
            result = DecimalToOther(result, toSystem);
            return result;
        }

        int DecimalToOther(int dec, int system)
        {
            int result = 0;
            int factor = 1;
            // In der while Schleife wird jede Stelle der Zahl konvertiert, solange die Zahl nicht 0 ist
            while (dec != 0)
            {
                // Modulo gibt den Rest zurück, der bei Zahl/ZielSystem entsteht
                int digit = dec % system;
                // Dec wird durch Zielsystem geteilt, um die nächste Zahlenstelle zu konvertieren
                // dabei werden nachkommastellen abgeschnitten weil int
                dec /= system;
                // Momentaner Faktor (10, 100, 1000 etc) * digit ergibt die jeweilige, konvertierte Stelle
                result += factor * digit;
                // Faktor wird hochgerechnet um die nächste Stelle zu berechnen.
                factor *= 10;
            }
            return result;
        }

        // Prinizipiell das gleiche wie DecimalToOther, aber hier wird die Zahl in Zehnerschritten heruntergebrochen
        // und der Faktor mit dem Startzahlensystem multipliziert
        int OtherToDecimal(int other, int system)
        {
            int result = 0;
            int factor = 1;
            while (other != 0)
            {
                int digit = other % 10;
                other /= 10;
                result += factor * digit;
                factor *= system;
            }
            return result;
        }



        static int number, fromSystem, toSystem;
        static void Main(string[] args)
        {

            getUserNumber();
            Console.WriteLine();
            Console.WriteLine(NumberToDifferentSystem(number, fromSystem, toSystem));
            Console.WriteLine();
        }

        static void getUserNumber()
        {
            try
            {
                Console.WriteLine("Input number to convert:");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("What number-system is your number based in?");
                fromSystem = int.Parse(Console.ReadLine());
                Console.WriteLine("What number-system do you want your number to be?:");
                toSystem = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Error: Falscher Input. Bitte nur Ganzzahlen eingeben");
                Console.WriteLine();
                getUserNumber();
            }       
        }

        static bool isNumberDecimal(int startSystem)
        {
            if (startSystem == 10)
                return true;
            return false;
        }

        static int NumberToDifferentSystem(int numberToConvert, int fromSystem, int toSystem)
        {
            int result = 0;
            int factor = 1;
            // int factorMultiplier = decimalNumber ? 10 : fromSystem;
            // int systemToConvertTo = decimalNumber ? toSystem : 10;
            while (numberToConvert != 0)
            {
                if (isNumberDecimal(fromSystem))
                {                  
                    int digit = numberToConvert % toSystem;
                    numberToConvert /= toSystem;                   
                    result += factor * digit;                   
                    factor *= 10;
                }
                else
                {
                    int digit = numberToConvert % 10;
                    numberToConvert /= 10;
                    result += factor * digit;
                    factor *= fromSystem;
                }
            }
            return result;
        }

        
       
        }
    }

