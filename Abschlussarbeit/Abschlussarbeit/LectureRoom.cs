namespace Abschlussarbeit
{
    internal class LectureRoom : ISchedulable
    {
        public string Name { get => _name; set => _name = value; }
        public Schedule SpecificSchedule { get => _specificSchedule; set => _specificSchedule = value; }

        public string _name;
        public Schedule _specificSchedule;

        public int _capacity;
        public InstituteEquipment _availableEquipment;

        public LectureRoom()
        {
            SpecificSchedule = new Schedule();
        }
    }
}