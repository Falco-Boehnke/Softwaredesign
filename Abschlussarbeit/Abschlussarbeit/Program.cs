using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializeData(LoadData());
            PopulateCourseList();
            CalculateCompleteSchedule();

            StartUserInterfacing();
        }

        static JArray LoadData()
        {
            string filePath = DataCatalogueService.DatafilePath;
            string JsonString;

            using (StreamReader r = new StreamReader(filePath))
            {
                JsonString = r.ReadToEnd();
                Console.WriteLine(JsonString + "");
            }

            return JArray.Parse(JsonString);
        }

        static void DeserializeData(JArray toDeserialize)
        {
            Console.WriteLine("AT 0: " + toDeserialize[0]);
            //JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            DataCatalogueService.CurrentLectureRooms = JsonConvert.DeserializeObject<List<LectureRoom>>(toDeserialize[0].ToString());
            DataCatalogueService.CurrentlyEmployedLecturers = JsonConvert.DeserializeObject<List<Lecturer>>(toDeserialize[1].ToString());
            DataCatalogueService.CurrentlyTaughtCourses = JsonConvert.DeserializeObject<List<Course>>(toDeserialize[2].ToString());
        }

        static void PopulateCourseList()
        {
            foreach (Lecturer LecturerToGoThrough in DataCatalogueService.CurrentlyEmployedLecturers)
            {
                if (LecturerToGoThrough == null)
                {
                    continue;
                }

                LecturerToGoThrough.AddCoursesToDataCatalogue();
            }
        }

        static void CalculateCompleteSchedule()
        {
            int day = (int)WorkDays.Monday;
            int timeBlock = (int)TimeBlocks.First_Block;
            Course courseToPlaceInSchedule = new Course();
            Schedule cSched = DataCatalogueService.CompleteSchedule;

            for (int i = 0; i < DataCatalogueService.CurrentlyTaughtCourses.Count; i++)
            {
                courseToPlaceInSchedule = DataCatalogueService.CurrentlyTaughtCourses[i];

                if (courseToPlaceInSchedule.CheckIfSchedulesLineUp((WorkDays)day, (TimeBlocks)timeBlock))
                {
                    cSched.scheduleMatrix[day, timeBlock]._allScheduledCoursesCollection.Add(courseToPlaceInSchedule);
                    courseToPlaceInSchedule.AddEntryToAllAssociatedSchedules((WorkDays)day, (TimeBlocks)timeBlock);
                    day = 0;
                    timeBlock = 0;
                }
                else
                {
                    timeBlock++;
                    if (timeBlock == Enum.GetNames(typeof(WorkDays)).Length - 1)
                    {
                        day++;
                        timeBlock = 0;
                        if (day == Enum.GetNames(typeof(TimeBlocks)).Length - 1)
                        {
                            UserIOController.OutputErrorMessage("Course konnte nicht platziert werden. Stundenplan generierung abgebrochen");
                        }
                    }
                }
            }
            UserIOController.OutputMessage("Stundenplan erfolgreich erstellt.");
        }

        private static void StartUserInterfacing()
        {
            bool userIsInterfaced = true;

            while (userIsInterfaced)
            {
                userIsInterfaced &= UserIOController.OutputCurrentUserOptions();
            }
        }

    }
}
