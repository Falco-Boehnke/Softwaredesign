using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class Course : ISchedulable
    {
        public string Name { get; set; }
        public Schedule SpecificSchedule { get; set; }

        public WorkDays scheduledDay;
        public TimeBlocks scheduledTime;
        public CourseTypes TypeOfCourse { get; set; }
        public InstituteEquipment NecessaryEquipment { get; set; }
        public Lecturer CourseLecturer { get; set; }
        public StudentCohort AssociatedCohort { get; set; }
        private List<LectureRoom> CompatibleRooms { get; set; }
        public LectureRoom ChosenLectureRoom { get; set; }

        public Course()
        {
            CompatibleRooms = new List<LectureRoom>();
            SpecificSchedule = new Schedule();
        }

        public Course(String nameOnly)
        {
            CompatibleRooms = new List<LectureRoom>();
            SpecificSchedule = new Schedule();
            Name = nameOnly;
        }

        // TODO additional constructor for setting coursetype as well
        public Course(String nameOnly, CourseTypes typeOfCourse, InstituteEquipment necessaryEquipment)
        {
            CompatibleRooms = new List<LectureRoom>();
            SpecificSchedule = new Schedule();
            Name = nameOnly;
            TypeOfCourse = typeOfCourse;
            NecessaryEquipment = necessaryEquipment;
        }

        public void SetAssociatedCohort()
        {
            foreach (StudentCohort cohortToCheckForAssociation in DataCatalogueService.CurrentStudentCohorts)
            {
                if (AssociatedCohort != null)
                {
                    break;
                }

                if (cohortToCheckForAssociation == null)
                {
                    UserIOController.OutputErrorMessage("Keine Cohorte für den Kurs gefunden, Abbruch!");
                }

                foreach (Course RequiredCourseToCompare in cohortToCheckForAssociation._requiredCourses)
                {
                    if(this.Name == RequiredCourseToCompare.Name)
                    {
                        AssociatedCohort = cohortToCheckForAssociation;
                        break;
                    }
                }
            }
            SetCompatibleCourseRooms();
        }

        public void SetCompatibleCourseRooms()
        {
            foreach (LectureRoom courseRoomToVerify in DataCatalogueService.CurrentLectureRooms)
            {
                if (courseRoomToVerify._availableEquipment == NecessaryEquipment)
                {
                    if (AssociatedCohort != null && courseRoomToVerify._capacity >= AssociatedCohort._numberOfStudents)
                    {
                        CompatibleRooms.Add(courseRoomToVerify);
                    }
                }
            }
        }

        private void SortCompatibleCourseRoomsList()
        {
            throw new NotImplementedException();
        }

        // TODO slighty changed this to check for == 0 instead of  == null
        public bool CheckIfSchedulesLineUp(WorkDays day, TimeBlocks block)
        {
            Console.WriteLine();
            Console.WriteLine("Checking Schedules for: ");
            Console.WriteLine(CourseLecturer.Name);
            Console.WriteLine(Name);
 
            if (CourseLecturer.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block)._allScheduledCoursesCollection.Count == 0)
            {
                if (AssociatedCohort.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block)._allScheduledCoursesCollection.Count == 0)
                {
                    Console.WriteLine("Cohort Schedule Free");
                    foreach (LectureRoom roomToCheck in CompatibleRooms)
                    {
                        if (roomToCheck.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block)._allScheduledCoursesCollection.Count == 0)
                        {
                            ChosenLectureRoom = roomToCheck;
                            return true;
                        }
                        else {
                            Console.WriteLine("Kein Raum frei");
                            return false;
                        }
                    }
                }
                else {
                    Console.WriteLine("Kohorte keine Zeit hat");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Dozent keine Zeit hat");
                return false;
            }
            return false;
        }

        public void AddEntryToAllAssociatedSchedules(WorkDays day, TimeBlocks timeBlock)
        {
            scheduledDay = day;
            scheduledTime = timeBlock;

            SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            CourseLecturer.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            AssociatedCohort.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            ChosenLectureRoom.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
        }
    }
}
