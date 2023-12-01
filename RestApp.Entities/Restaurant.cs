namespace RestApp.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public List<Table> Tables { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
