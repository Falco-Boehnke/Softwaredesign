using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    static class UserIOController
    {
        public static bool OutputCurrentUserOptions()
        {
            int choice;

            Console.WriteLine("Applikation beenden (0)");
            Console.WriteLine("Gesamtstundenplan ansehen (1)");
            Console.WriteLine("Kohorten Stundenplan ansehen (2)");
            Console.WriteLine("Dozenten Stundenplan ansehen (3)");
            Console.WriteLine("Raum Stundenplan ansehen (4)");
            Console.WriteLine("Liste aller Kurse ansehen (5)");

            choice = HandleUserChoice();
            switch (choice)
            {
                case 0:
                    OutputErrorMessage("Auf Wiederschauen");
                    return false;
                case 1:
                    DataCatalogueService.CompleteSchedule.PrintOut();
                    return true;
                case 2:
                    OutputCohortOptions();
                    return true;
                case 3:
                    OutputLecturerOptions();
                    return true;
                case 4:
                    OutputLectureRoomOptions();
                    return true;
                case 5:
                    OutputAllCourses();
                    return true;
                default:
                    return false;
            }
        }

        public static void OutputCohortOptions()
        {
            Console.WriteLine("Zurück(0)");
            Console.WriteLine(DataCatalogueService.CurrentStudentCohorts[0].Name + "  Stundenplan Ansehen (1)");
            Console.WriteLine(DataCatalogueService.CurrentStudentCohorts[1].Name + "  Stundenplan Ansehen (2)");
            Console.WriteLine(DataCatalogueService.CurrentStudentCohorts[2].Name + "  Stundenplan Ansehen (3)");
            int choice = HandleUserChoice();
            switch (choice)
            {
                case 1:
                    DataCatalogueService.CurrentStudentCohorts[0].SpecificSchedule.PrintOut();
                    break;
                case 2:
                    DataCatalogueService.CurrentStudentCohorts[1].SpecificSchedule.PrintOut();
                    break;
                case 3:
                    DataCatalogueService.CurrentStudentCohorts[2].SpecificSchedule.PrintOut();
                    break;
                default:
                    break;
            }
        }

        public static void OutputLecturerOptions()
        {
            Console.WriteLine("Zurück(0)");
            int choice = 0;
            foreach(Lecturer lec in DataCatalogueService.CurrentlyEmployedLecturers)
            {
                Console.WriteLine(lec.Name + "  Stundenplan Ansehen (" + choice + ")");
                choice++;
            }

            choice = HandleUserChoice();
            switch (choice)
            {
                case 1:
                    DataCatalogueService.CurrentlyEmployedLecturers[0].SpecificSchedule.PrintOut();
                    break;
                case 2:
                    DataCatalogueService.CurrentlyEmployedLecturers[1].SpecificSchedule.PrintOut();
                    break;
                case 3:
                    DataCatalogueService.CurrentlyEmployedLecturers[2].SpecificSchedule.PrintOut();
                    break;
                case 4:
                    DataCatalogueService.CurrentlyEmployedLecturers[3].SpecificSchedule.PrintOut();
                    break;
                case 5:
                    DataCatalogueService.CurrentlyEmployedLecturers[4].SpecificSchedule.PrintOut();
                    break;
                default:
                    break;
            }
        }

        public static void OutputLectureRoomOptions()
        {
            Console.WriteLine("Zurück(0)");
            int choice = 0;
            foreach (LectureRoom lec in DataCatalogueService.CurrentLectureRooms)
            {
                Console.WriteLine(lec.Name + "  Stundenplan Ansehen (" + choice + ")");
                choice++;
            }

            choice = HandleUserChoice();
            switch (choice)
            {
                case 1:
                    DataCatalogueService.CurrentLectureRooms[0].SpecificSchedule.PrintOut();
                    break;
                case 2:
                    DataCatalogueService.CurrentLectureRooms[1].SpecificSchedule.PrintOut();
                    break;
                case 3:
                    DataCatalogueService.CurrentLectureRooms[2].SpecificSchedule.PrintOut();
                    break;
                case 4:
                    DataCatalogueService.CurrentLectureRooms[3].SpecificSchedule.PrintOut();
                    break;
                case 5:
                    DataCatalogueService.CurrentLectureRooms[4].SpecificSchedule.PrintOut();
                    break;
                default:
                    break;
            }
        }

        public static int HandleUserChoice()
        {
            try
            {
                int toReturn = int.Parse(Console.ReadLine());
                return toReturn;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Eingabefehler, bitte nur Ganzzahlen eingeben");
                return HandleUserChoice();
            }

        }

        public static void OutputErrorMessage(String msg)
        {
            Console.WriteLine();
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Error: " + msg);
            System.Threading.Thread.Sleep(5000);
            Environment.Exit(1);
        }
        public static void OutputMessage(String msg)
        {
            Console.WriteLine();
            Console.WriteLine("----------Information----------");
            Console.WriteLine(msg);
            System.Threading.Thread.Sleep(2000);
        }

        public static void OutputCoursesForTheDay(Course toOutput, WorkDays day, TimeBlocks block)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(day + " " + block);
            Console.WriteLine(toOutput.Name);
            Console.WriteLine(toOutput.AssociatedCohort.Name);
            Console.WriteLine(toOutput.CourseLecturer.Name);
            Console.WriteLine(toOutput.ChosenLectureRoom.Name);
            Console.WriteLine("______________________________");
            Console.WriteLine();
        }

        public static void OutputAllCourses()
        {
            foreach (Course toOutput in DataCatalogueService.CurrentlyTaughtCourses)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------");
                Console.WriteLine(toOutput.scheduledDay + " " + toOutput.scheduledTime);
                Console.WriteLine(toOutput.Name);
                Console.WriteLine(toOutput.AssociatedCohort.Name);
                Console.WriteLine(toOutput.CourseLecturer.Name);
                Console.WriteLine(toOutput.ChosenLectureRoom.Name);
                Console.WriteLine("______________________________");
                Console.WriteLine();
            }
        }

        public static void OutputUserChoice()
        {
            throw new NotImplementedException();
        }

        public static void RequestUserInput()
        {
            Console.WriteLine("Bitte geben sie ihre Auswahl ein (als Ganzzahl): ");
            HandleUserChoice();
        }


    }
}
