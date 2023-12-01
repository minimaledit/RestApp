namespace RestApp.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public bool IsReserved { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}