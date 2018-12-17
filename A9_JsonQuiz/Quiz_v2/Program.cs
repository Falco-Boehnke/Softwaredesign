using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_v2
{
    class Program
    {
        public static List<Quizelement> questions;
        public static int points;
        public static string json, filepath;
        static void Main(string[] args)
        {
            questions = new List<Quizelement>();
           
            CreateDefaultQuestions();
            callToAction();
        }
        
        static void CreateDefaultQuestions()
        {
         filepath = @"../../QuizDatabase.json";

            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                json = r.ReadToEnd();
            }

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            questions = JsonConvert.DeserializeObject<List<Quizelement>>(json, settings);
        }

       
        static void callToAction()
        {
            bool quizRunning = true;

            while (quizRunning)
                {
                Console.WriteLine();
                Console.WriteLine("Punkte: " + points);
                Console.WriteLine();
                Console.WriteLine("Action auswählen");
                Console.WriteLine("(1) Frage einfügen");
                Console.WriteLine("(2) Frage beantwroten");
                Console.WriteLine("(3) Beenden");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "1":
                        AddQuestion();
                        break;
                    case "2":
                        AskQuestion();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye");
                        quizRunning = false;
                        break;
                    
                }
            }
        }

        static void AskQuestion()
        {
            Random r = new Random();
            int whichQuestion = r.Next(questions.Count);

            bool failureOrWin = questions[whichQuestion].show();

            if (failureOrWin)
            {
                points++;
                Console.WriteLine("Korrekte Antwort!");
            }
            else
                Console.WriteLine("Falsche Antwort");

        }

        static void AddQuestion()
        {
            Console.WriteLine("Welche Art von Frage wollen Sie hinzufügen?");
            Console.WriteLine("(1) Freitext-Frage");
            Console.WriteLine("(2) Ja/Nein Frage");
            Console.WriteLine("(3) SingleChoice Frage");
            Console.WriteLine("(4) MultipleChoice Frage");
            Console.WriteLine("(5) Schätz Frage");

            string decision = Console.ReadLine();

            Quizelement newQuestion;
            switch (decision)
            {
                case "1":
                    newQuestion = new QuizFree();
                    break;
                case "2":
                    newQuestion = new QuizBinary();
                    break;
                case "3":
                    newQuestion = new QuizSingle();
                    break;
                case "4":
                    newQuestion = new QuizMultiple();
                    break;
                case "5":
                    newQuestion = new QuizGuess();                   
                    break;
                default:
                    newQuestion = new QuizGuess();
                    break;

            }
            newQuestion.createElement();
            questions.Add(newQuestion);

            json = JsonConvert.SerializeObject(questions, Formatting.Indented);
            File.WriteAllText(filepath, json);



        }
    }
}
