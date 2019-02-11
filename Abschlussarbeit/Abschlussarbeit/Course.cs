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

        public void SetAssociatedCohort()
        {
            foreach (StudentCohort cohortToCheckForAssociation in DataCatalogueService.CurrentStudentCohorts)
            {
                if (AssociatedCohort != null)
                {
                    return;
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
                        return;
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
                    if (courseRoomToVerify._capacity >= AssociatedCohort._numberOfStudents)
                    {
                        CompatibleRooms.Add(courseRoomToVerify);
                    }
                }
            }

            SortCompatibleCourseRoomsList();
        }

        private void SortCompatibleCourseRoomsList()
        {
            throw new NotImplementedException();
        }

        public bool CheckIfSchedulesLineUp(WorkDays day, TimeBlocks block)
        {
            if (CourseLecturer.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block) == null)
            {
                if (AssociatedCohort.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block) == null)
                {
                    foreach (LectureRoom roomToCheck in CompatibleRooms)
                    {
                        if (roomToCheck.SpecificSchedule.GetEntryForDayAndTimeBlock(day, block) == null)
                        {
                            ChosenLectureRoom = roomToCheck;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void AddEntryToAllAssociatedSchedules(WorkDays day, TimeBlocks timeBlock)
        {
            this.scheduledDay = day;
            this.scheduledTime = timeBlock;
            SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            CourseLecturer.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            AssociatedCohort.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
            ChosenLectureRoom.SpecificSchedule.SetEntryForDayAndTimeBlock(new ScheduleEntry(this, day, timeBlock), day, timeBlock);
        }
    }
}
