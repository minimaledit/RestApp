namespace RestApp.ReservationDto
{
    public class CreateTableDto
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int RestaurantId { get; set; }
        public bool IsReserved { get; set; }
    }
}
