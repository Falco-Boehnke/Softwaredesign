using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class StudentCohort : ISchedulable
    {
        public string Name { get; set; }
        public Schedule SpecificSchedule { get; set; }
        public Semester _semester;
        public int _numberOfStudents;
        public List<Course> _requiredCourses;

        public StudentCohort()
        {
            _requiredCourses = new List<Course>();
            SpecificSchedule = new Schedule();
        }
    }
}