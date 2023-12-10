namespace RestApp.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeOut { get; set; }
        public int GuestsCount { get; set; }
        public User User { get; set; }
        public Table Table { get; set; }
    }
}
