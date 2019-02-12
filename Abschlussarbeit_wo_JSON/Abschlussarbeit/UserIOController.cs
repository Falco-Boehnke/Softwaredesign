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

            Console.WriteLine();
            Console.WriteLine("Applikation beenden (0)");
            Console.WriteLine("Gesamtstundenplan ansehen (1)");
            Console.WriteLine("Kohorten Stundenplan ansehen (2)");
            Console.WriteLine("Dozenten Stundenplan ansehen (3)");
            Console.WriteLine("Raum Stundenplan ansehen (4)");
            Console.WriteLine("Liste aller Kurse ansehen (5)");
            Console.WriteLine();

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

            int i = 0;
            foreach(StudentCohort sc in DataCatalogueService.CurrentStudentCohorts)
            {
                Console.WriteLine(sc.Name + " " + sc._semester + " Semester: " + "Stundenplan Ansehen (" + i + ")");
                i++;
            }
            int choice = HandleUserChoice();

            DataCatalogueService.CurrentStudentCohorts[choice].SpecificSchedule.PrintOut();
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

            DataCatalogueService.CurrentlyEmployedLecturers[choice].SpecificSchedule.PrintOut();
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
            DataCatalogueService.CurrentLectureRooms[choice].SpecificSchedule.PrintOut();
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
            if (toOutput != null)
            { 
                Console.WriteLine(toOutput.Name);
                if(toOutput.TypeOfCourse == CourseTypes.WPM)
                    Console.WriteLine("WPM");

                if (toOutput.TypeOfCourse == CourseTypes.Unspecified)
                    Console.WriteLine("-");

                if (toOutput.TypeOfCourse == CourseTypes.Mandatory)
                    Console.WriteLine(toOutput.AssociatedCohort.Name);

                Console.WriteLine(toOutput.CourseLecturer.Name);
                if(toOutput.ChosenLectureRoom != null)
                    Console.WriteLine(toOutput.ChosenLectureRoom.Name);
            }
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
