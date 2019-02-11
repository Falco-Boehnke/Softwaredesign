using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    public enum WorkDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum TimeBlocks
    {
        First_Block,
        Second_Block,
        Third_Block,
        Fourth_Block,
        Fifth_Block,
        Sixth_Block
    }

    public enum InstituteEquipment
    {
        None,
        Smart_Board
    }

    public enum CourseTypes
    {
        Unspecified,
        Mandatory,
        WPM
    }

    public enum Semester
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth
    }

    static class DataCatalogueService
    {
        public static string DatafilePath = @"../../InstituteData.json";
        public static List<Lecturer> CurrentlyEmployedLecturers = new List<Lecturer>();
        public static List<StudentCohort> CurrentStudentCohorts = new List<StudentCohort>();
        public static List<LectureRoom> CurrentLectureRooms = new List<LectureRoom>();
        public static List<Course> CurrentlyTaughtCourses = new List<Course>();
        public static Schedule CompleteSchedule;

    }
}
