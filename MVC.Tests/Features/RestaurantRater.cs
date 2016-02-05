namespace MVC.Tests.Features
{
    using System.Linq;

    using MVC.Models;

    class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        public RatingResult ComputeRating(IRatingAlgorithm ratingAlgorithm, int numberOfReviews)
        {
            var nReviews = _restaurant.Reviews.Take(numberOfReviews);

            return ratingAlgorithm.Compute(nReviews.ToList());
        }
    }
}