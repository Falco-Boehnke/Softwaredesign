using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class Lecturer : ISchedulable
    {
        public string Name { get; set; }
        public Schedule SpecificSchedule { get; set; }
        public List<Course> _teachingCourses;
        public List<ScheduleEntry> _unavailabilityTimes;

        public Lecturer()
        {
            _teachingCourses = new List<Course>();
            SpecificSchedule = new Schedule();

            foreach (ScheduleEntry se in _unavailabilityTimes)
            {
                SpecificSchedule.SetEntryForDayAndTimeBlock(se, se._dayOfEntry, se._timeBlockOfEntry);
            }
        }

        public void AddCoursesToDataCatalogue()
        {
            foreach (Course ToAddCourse in _teachingCourses)
            {
                if (ToAddCourse == null)
                {
                    continue;
                }

                ToAddCourse.CourseLecturer = this;

                if(ToAddCourse.TypeOfCourse != CourseTypes.WPM)
                {
                    ToAddCourse.SetAssociatedCohort();
                }
                DataCatalogueService.CurrentlyTaughtCourses.Add(ToAddCourse);
            }
        }
    }
}
