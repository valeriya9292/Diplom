namespace BLL.DomainModel.Entities
{
    public class TimeLog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int Week { get; set; }
        public int Year { get; set; }

        public decimal HoursInMonday { get; set; }
        public decimal HoursInTuesday { get; set; }
        public decimal HoursInWednesday { get; set; }
        public decimal HoursInThursday { get; set; }
        public decimal HoursInFriday { get; set; }
        public decimal HoursInSaturday { get; set; }
        public decimal HoursInSunday { get; set; }
    }
}
