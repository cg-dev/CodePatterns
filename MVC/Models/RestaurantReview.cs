namespace MVC.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public int RestaurantId { get; set; } // optional
    }
}