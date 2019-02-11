using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class ScheduleEntry
    {
        public List<Course> _allScheduledCoursesCollection;
        public WorkDays _dayOfEntry;
        public TimeBlocks _timeBlockOfEntry;

        public ScheduleEntry()
        {
            _allScheduledCoursesCollection = new List<Course>();
        }

        public ScheduleEntry(Course toBlock, WorkDays day, TimeBlocks block)
        {
            _allScheduledCoursesCollection = new List<Course>();
            _dayOfEntry = day;
            _timeBlockOfEntry = block;
            _allScheduledCoursesCollection.Add(toBlock);
        }
    }
}
