using System;

namespace Softwaredesign
{
    class Program
    {

        static void Main(string[] args)
        {
            // Einzige Ausgabe des Compilers: Variable nicht genutzt
            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World";

            var floatVariable = 0f;
            var doubleVariable = 0.0;
            var shortVariable = 0x040A;

            // Type: int, Name: ia, Speicher: 10
            int[] ia2 = new int[10];
            // Type: char, Name: ca, Speicher: 30
            char[] ca = new char[30];
            // Type: double, Name: da, Speicher: 12
            double[] da = new double[12];

            int[] ia = new int[10];
            ia[0] = 1;
            ia[1] = 0;
            ia[2] = 2;
            ia[3] = 9;
            ia[4] = 3;
            ia[5] = 8;
            ia[6] = 4;
            ia[7] = 7;
            ia[8] = 5;
            ia[9] = 6;

            // 13
            int ergebnis = ia[2] * ia[8] + ia[4];
            Console.WriteLine(ergebnis);
            double[] weirdNumbers = new double[50];
            weirdNumbers[0] = Math.PI;
            weirdNumbers[1] = Math.E;
            weirdNumbers[2] = 2.97 * Math.Pow(10, -19);
            Console.WriteLine("Pi: " + weirdNumbers[0] + " Euler: " + weirdNumbers[1] + " Kepler: " + weirdNumbers[2]);
            Console.WriteLine("ArrayLength:" + weirdNumbers.Length);
            
            weirdNumbers[3] = 1234;
            weirdNumbers[4] = 5678;
            Console.WriteLine("New ArrayLength:" + weirdNumbers.Length);
            Console.WriteLine();
            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);
            string meinString = "Dies ist ein String";
            char zeichen = meinString[5];
            
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(a_eq_b);
            Console.WriteLine(a_eq_c);
            Console.WriteLine(zeichen);
            Console.WriteLine();

            bool tryAgain = true;
            do
            {
                try
                {
                    Console.Write("Erste Zahl eingeben: ");
                    int firstNumber = int.Parse(Console.ReadLine());

                    Console.Write("Zweite Zahl eingeben: ");
                    int secondNumber = int.Parse(Console.ReadLine());

                    if (firstNumber > 3 && secondNumber == 6)
                        Console.WriteLine("WinnerWinnerChickenDinner");
                    else
                    if (firstNumber < secondNumber)
                        Console.WriteLine("Zweite ist Größer als Erste");
                    else
                    if (firstNumber > secondNumber)
                        Console.WriteLine("Erste ist Größer als Zweite");
                    else
                        Console.WriteLine("Loser"); ;

                    tryAgain = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Fehlerhafte eingabe, nur Int! Try Again");
                    Console.WriteLine();
                }
            } while (tryAgain);

            Console.WriteLine();
            Console.WriteLine("SwitchCase Int");
            int switchCase = int.Parse(Console.ReadLine());
            switch (switchCase)
            {
                case 1:
                    Console.WriteLine("Du hast EINS eingegeben");
                    break;
                case 2:
                    Console.WriteLine("ZWEI war Deine Wahl");
                    break;
                case 3:
                    Console.WriteLine("Du tipptest eine DREI");
                    break;
                case 4:
                    Console.WriteLine("Itsa 4");
                    break;
                default:
                    Console.WriteLine("Die Zahl " + switchCase + " kenne ich nicht");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("SwitchCase String");
            string switchCase2 = Console.ReadLine();
            switchCase2 = switchCase2.ToUpper();
            switch (switchCase2)
            {
                case "EINS":
                    Console.WriteLine("Du hast EINS eingegeben");
                    break;
                case "ZWEI":
                    Console.WriteLine("ZWEI war Deine Wahl");
                    break;
                case "DREI":
                    Console.WriteLine("Du tipptest eine DREI");
                    break;
                case "VIER":
                    Console.WriteLine("Itsa 4");
                    break;
                default:
                    Console.WriteLine("Die Eingabe " + switchCase2 + " kenne ich nicht");
                    break;
            }

            // Break vergessen: Nachfolgender Case wird ebenfalls ausgeführt
            // Praktisch wenn ein Case auch bedeutet das ein weiterer Case nötig ist

            Console.WriteLine();
            Console.WriteLine("SwitchCase ifelse");
            switchCase2 = Console.ReadLine().ToUpper();
            if(switchCase2 == "EINS")
                Console.WriteLine("Du hast EINS eingegeben");
            else
            if(switchCase2 == "ZWEI")
                Console.WriteLine("ZWEI war Deine Wahl");
            else
            if(switchCase2 == "DREI")
                Console.WriteLine("Du tipptest eine DREI");
            else
            if(switchCase2 == "VIER")
                Console.WriteLine("Itsa 4");
            else
                Console.WriteLine("Die Eingabe " + switchCase2 + " kenne ich nicht");

            Console.WriteLine();
            Console.WriteLine("While Loop");
            // Init
            int whileAusgabe = 0;
                    // Condition
            while (whileAusgabe < 11)
            {
                Console.Write(whileAusgabe + " ");
                // Increment
                whileAusgabe++;
            }

            // Gibt die ersten vier Elemente von someStrings aus
            string[] someStrings =
            {
                "Hier",
                "sehen",
                "wir",
                "einen",
                "Array",
                "von",
                "Strings"
              };

            for (int k = 0; k < 5; k++)
            {
                Console.WriteLine(someStrings[k]);
            }
            Console.WriteLine();
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine(someStrings[j]);
                j++;
            }
            Console.WriteLine();
            for (int r = 0; r < someStrings.Length; r++)
            {
                Console.WriteLine(someStrings[r]);
            }

            Console.WriteLine();
            i = 0;
            do
            {
                Console.WriteLine(someStrings[i]);
                i++;
            }
            while (i < someStrings.Length);

            i = 0;
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine(someStrings[i]);
                if (i >= someStrings.Length-1)
                    break;
                i++;
            }

            // Dowhile ohne Einträge = Crash 
            // While Break = Crash
            // For = Instant break

            // Foreach erlaubt keine Kontrolle über die Iteration der Einträge, spart haufenweise Arbeit und ist sehr klar, außerdem niemals
            // Endlosschleifen. Läuft das Array komplett durch
            // For = Gut für Schleifen deren Iterationszahl man abschätzen kann, oder angeben durch Bedingungen
            // While = Am besten wenn die Schleife eine unbekannte Menge an Iterationen durchlaufen muss

        }
    }
}
