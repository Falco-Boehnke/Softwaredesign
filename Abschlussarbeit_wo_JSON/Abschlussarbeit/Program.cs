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
            //DeserializeData(LoadData());
            CreateExampleDataWithoutJson();

            // TODO Filling up CompleteSchedule to avoid null errors and make it less memory stupid
           // DataCatalogueService.CompleteSchedule.SetEmptyEntriesForCompleteSchedule();
            PopulateCourseList();
            CalculateCompleteSchedule();

            StartUserInterfacing();
        }

        // TODO added all this 
        static void CreateExampleDataWithoutJson()
        {
            LectureRoom exampleRoom; 
         
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "i0.13";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 40;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "i0.14";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 70;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "i0.15";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 80;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "i0.16";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 30;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "i0.17";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 40;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "L1.05a";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 40;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "L2.05a";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 30;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "L2.07";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 50;          
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "L2.09";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 50;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "C0.14";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 100;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "C0.02";
            exampleRoom._availableEquipment = InstituteEquipment.None;
            exampleRoom._capacity = 100;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);
            exampleRoom = new LectureRoom();
            exampleRoom.Name = "N1.06";
            exampleRoom._availableEquipment = InstituteEquipment.Smart_Board;
            exampleRoom._capacity = 100;
            DataCatalogueService.CurrentLectureRooms.Add(exampleRoom);


            StudentCohort exampleCohort;
            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MiB";
            exampleCohort._semester = Semester.Second;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Mathematik und Simulation"));
            exampleCohort._requiredCourses.Add(new Course("Computergrafik"));
            exampleCohort._requiredCourses.Add(new Course("GIS"));
            exampleCohort._requiredCourses.Add(new Course("3D Modellierung"));
            exampleCohort._requiredCourses.Add(new Course("User Experience Design"));
            exampleCohort._requiredCourses.Add(new Course("Medienökonomie"));
            exampleCohort._requiredCourses.Add(new Course("Marketing"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MIB";
            exampleCohort._semester = Semester.Fourth;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Grafische Datenverarbeitung"));
            exampleCohort._requiredCourses.Add(new Course("Softwaredesign Seminar"));
            exampleCohort._requiredCourses.Add(new Course("Softwaredesign Praktikum"));
            exampleCohort._requiredCourses.Add(new Course("Kommunikationssysteme"));
            exampleCohort._requiredCourses.Add(new Course("Projektmanagement"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MIB";
            exampleCohort._semester = Semester.Fifth;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Datenverarbeitung"));
            exampleCohort._requiredCourses.Add(new Course("Verteilte Anwendungen"));
            exampleCohort._requiredCourses.Add(new Course("Digitale AV-Technik"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);


            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MKB";
            exampleCohort._semester = Semester.First;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Audiotechnik"));
            exampleCohort._requiredCourses.Add(new Course("BWL"));
            exampleCohort._requiredCourses.Add(new Course("Planspiel"));
            exampleCohort._requiredCourses.Add(new Course("Medienanalyse"));
            exampleCohort._requiredCourses.Add(new Course("Medienkonzeption"));
            exampleCohort._requiredCourses.Add(new Course("Videotechnik"));
            exampleCohort._requiredCourses.Add(new Course("Medienpsychologie"));
            exampleCohort._requiredCourses.Add(new Course("Entwicklung interaktiver Anwendungen"));
            exampleCohort._requiredCourses.Add(new Course("Mediengestaltung"));
            exampleCohort._requiredCourses.Add(new Course("Medientechnik"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MKB";
            exampleCohort._semester = Semester.Fourth;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("E-Learning Vorlesung"));
            exampleCohort._requiredCourses.Add(new Course("E-Learning Praktikum"));
            exampleCohort._requiredCourses.Add(new Course("Konzeption"));
            exampleCohort._requiredCourses.Add(new Course("Ideenentwicklung"));
            exampleCohort._requiredCourses.Add(new Course("Creative Writing"));
            exampleCohort._requiredCourses.Add(new Course("Storytelling"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "MKB";
            exampleCohort._semester = Semester.Fifth;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Operatives Marketing"));
            exampleCohort._requiredCourses.Add(new Course("Kommunikationswirtschaft"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "OMB";
            exampleCohort._semester = Semester.Fourth;
            exampleCohort._numberOfStudents = 1;
            exampleCohort._requiredCourses.Add(new Course("Webtechnologien"));
            exampleCohort._requiredCourses.Add(new Course("Responsive Webdesign"));
            exampleCohort._requiredCourses.Add(new Course("Projektstudium"));
            exampleCohort._requiredCourses.Add(new Course("E-Business"));
            exampleCohort._requiredCourses.Add(new Course("Webtechnologien Praktikum"));
            exampleCohort._requiredCourses.Add(new Course("Medienwirtschaft"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            exampleCohort = new StudentCohort();
            exampleCohort.Name = "OMB";
            exampleCohort._semester = Semester.Fifth;
            exampleCohort._requiredCourses.Add(new Course("Interface Design Vorlesung"));
            exampleCohort._requiredCourses.Add(new Course("Interface Design Praktikum"));
            exampleCohort._requiredCourses.Add(new Course("Streaming-Anwendungen Praktikum"));
            exampleCohort._requiredCourses.Add(new Course("Streaming-Anwendungen Vorlesung"));
            exampleCohort._requiredCourses.Add(new Course("E-Business"));
            exampleCohort._requiredCourses.Add(new Course("Webtechnologien Praktikum"));
            DataCatalogueService.CurrentStudentCohorts.Add(exampleCohort);

            

            Lecturer exampleLecturer;

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Reusch";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Sixth_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Thursday, TimeBlocks.Second_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.Fourth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Audiotechnik", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Videotechnik", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Schneider";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Wednesday, TimeBlocks.First_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.First_Block));
            exampleLecturer._teachingCourses.Add(new Course("Mathematik und Simulation", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Herbststreit";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.Third_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Monday, TimeBlocks.Second_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Thursday, TimeBlocks.Fourth_Block));
            exampleLecturer._teachingCourses.Add(new Course("BWL", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Planspiel", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Friess";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Wednesday, TimeBlocks.First_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Monday, TimeBlocks.Third_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Thursday, TimeBlocks.Fifth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Medienanalyse", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Medienkonzeption", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Mediengestaltung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Konzeption", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Ideenentwicklung", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Timmalog";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Monday, TimeBlocks.Third_Block));
            exampleLecturer._teachingCourses.Add(new Course("Entwicklung interaktiver Anwendungen", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Waldowski";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Fifth_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Fourth_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Sixth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Medientechnik", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Grafische Datenverarbeitung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Dufner";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Sixth_Block));
            exampleLecturer._teachingCourses.Add(new Course("GIS", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Dittler";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.Sixth_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.Fifth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Medienpsychologie", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("E-Learning Vorlesung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("E-Learning Praktikum", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Ruf";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Second_Block));
            exampleLecturer._teachingCourses.Add(new Course("Creative Writing", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Storytelling", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Pietsch";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Wednesday, TimeBlocks.First_Block));
            exampleLecturer._teachingCourses.Add(new Course("Projektmanagement", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Operatives Marketing", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Projektstudium", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("E-Business", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Anders";
            exampleLecturer._teachingCourses.Add(new Course("Webtechnologien", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Webtechnologien Praktikum", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Zydorek";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Second_Block));
            exampleLecturer._teachingCourses.Add(new Course("Medienwirtschaft", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Kommunikationswirtschaft", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Medienökonomie", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Marketing", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Engenhart";
            exampleLecturer._teachingCourses.Add(new Course("Interface Design Vorlesung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Interface Design Praktikum", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Hottong";
            exampleLecturer._teachingCourses.Add(new Course("Streaming-Anwendungen Praktikum", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Streaming-Anwendungen Vorlesung", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Digitale AV-Technik", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Krach";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Tuesday, TimeBlocks.Second_Block));
            exampleLecturer._teachingCourses.Add(new Course("Responsive Webdesign", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("User Experience Design", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Mueller";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Monday, TimeBlocks.Fifth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Computergrafik", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("3D Modellierung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer._teachingCourses.Add(new Course("Datenverarbeitung", CourseTypes.Mandatory, InstituteEquipment.None));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

            exampleLecturer = new Lecturer();
            exampleLecturer.Name = "Dell'Oro";
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Sprechstunde", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Monday, TimeBlocks.First_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Thursday, TimeBlocks.First_Block));
            exampleLecturer._unavailabilityTimes.Add(new ScheduleEntry(new Course("Abwesend", CourseTypes.Unspecified, InstituteEquipment.None), WorkDays.Friday, TimeBlocks.Sixth_Block));
            exampleLecturer._teachingCourses.Add(new Course("Softwaredesign Seminar", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Softwaredesign Praktikum", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer._teachingCourses.Add(new Course("Verteilte Anwendungen", CourseTypes.Mandatory, InstituteEquipment.Smart_Board));
            exampleLecturer.SetUnavailibilityTimesInSchedule();
            DataCatalogueService.CurrentlyEmployedLecturers.Add(exampleLecturer);

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
                LecturerToGoThrough.AddCoursesToDataCatalogue();
            }
        }

        // TODO Changed the entire loop, because it didn't actually loop through blocks/days
        // and only checked every course ONCE, so it obviously didn't work
        static void CalculateCompleteSchedule()
        {
            foreach (Course courseToPlace in DataCatalogueService.CurrentlyTaughtCourses)
            {
                // TODO made the looping it's own method, so I could break out of the "search for day and timeblock" part
                // without breaking out of the "loop through all courses" part
                bool couldPlace = LoopThroughScheduleAndPlaceIfPossible(courseToPlace);

                if (!couldPlace)
                {
                    UserIOController.OutputErrorMessage("Der Kurs " + courseToPlace.Name + " konnte nicht eingetragen werden. Daten überprüfen");
                }
            }
            UserIOController.OutputMessage("Stundenplan erfolgreich erstellt.");
        }

        // TODO changed the "loop through days and timeblocks" loop to actually loop through
        // days and blocks. Before was broken because it had no way of breaking out of the loop
        // while simultaneously NOT breaking out of "loop through all courses" loop
        private static bool LoopThroughScheduleAndPlaceIfPossible(Course courseToPlace)
        {
            int totalDays = Enum.GetNames(typeof(WorkDays)).Length;
            int totalTimeblocks = Enum.GetNames(typeof(TimeBlocks)).Length;

            Schedule cSched = DataCatalogueService.CompleteSchedule;

            for (int loopDay = 0; loopDay < totalDays; loopDay++)
            {
                for (int loopTimeBlock = 0; loopTimeBlock < totalTimeblocks; loopTimeBlock++)
                {
                    if (courseToPlace.CheckIfSchedulesLineUp((WorkDays)loopDay, (TimeBlocks)loopTimeBlock))
                    {
                        courseToPlace.AddEntryToAllAssociatedSchedules((WorkDays)loopDay, (TimeBlocks)loopTimeBlock);
                        cSched.scheduleMatrix[loopDay, loopTimeBlock]._allScheduledCoursesCollection.Add(courseToPlace);
                        Console.WriteLine("Course " + courseToPlace.Name + " was placed");
                        return true;
                    }
                }
            }
            return false;
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
