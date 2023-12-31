﻿namespace RestApp.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }
    }
}
