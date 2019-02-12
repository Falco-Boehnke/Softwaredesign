using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abschlussarbeit
{
    class Schedule
    {
        public ScheduleEntry[,] scheduleMatrix;

        public Schedule()
        {
            scheduleMatrix = new ScheduleEntry[6, 6];
            for (int i = 0; i < scheduleMatrix.GetLength(0); i++)
            {
                for (int k = 0; k < scheduleMatrix.GetLength(1); k++)
                {
                    //scheduleMatrix[i, k] = null;
                    scheduleMatrix[i, k] = new ScheduleEntry((WorkDays)i, (TimeBlocks)k);
                }
            }
        }

        public void PrintOut()
        {
            for (int i = 0; i < scheduleMatrix.GetLength(0); i++)
            {
                Console.WriteLine((WorkDays)i + ": ");
                for (int k = 0; k < scheduleMatrix.GetLength(1); k++)
                {
                        foreach (Course toPrint in scheduleMatrix[i, k]._allScheduledCoursesCollection)
                        {
                            UserIOController.OutputCoursesForTheDay(toPrint, (WorkDays)i, (TimeBlocks)k);
                        }
                    
                }
            }
        }

        public ScheduleEntry GetEntryForDayAndTimeBlock(WorkDays day, TimeBlocks block)
        {
            return scheduleMatrix[(int)day, (int)block];
        }

        public void SetEntryForDayAndTimeBlock(ScheduleEntry entry, WorkDays day, TimeBlocks block)
        {
            scheduleMatrix[(int)day, (int)block] = entry;
        }
    }
}
