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
            _unavailabilityTimes = new List<ScheduleEntry>();
            SpecificSchedule = new Schedule();
        }

        public void AddCoursesToDataCatalogue()
        {
            foreach (Course ToAddCourse in _teachingCourses)
            {
                ToAddCourse.CourseLecturer = this;

                if(ToAddCourse.TypeOfCourse != CourseTypes.WPM)
                {
                    ToAddCourse.SetAssociatedCohort();
                }
                DataCatalogueService.CurrentlyTaughtCourses.Add(ToAddCourse);
            }
        }

        public void SetUnavailibilityTimesInSchedule()
        {
            foreach (ScheduleEntry se in _unavailabilityTimes)
            {
                // TODO added this to avoid error, should be set in JSON instead
                se._allScheduledCoursesCollection[0].CourseLecturer = this;
                SpecificSchedule.SetEntryForDayAndTimeBlock(se, se._dayOfEntry, se._timeBlockOfEntry);
            }
        }
    }
}
