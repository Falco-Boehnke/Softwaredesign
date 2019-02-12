using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    interface ISchedulable
    {
        string Name
        {
            get;
            set;
        }

        Schedule SpecificSchedule
        {
            get;
            set;
        }

    }
}
