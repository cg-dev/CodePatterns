// A restaurant's overall rating can be calculated using various methods.
// For this app we want to try different methods over time,
// but for starters we'll allow an administrator to toggle between two 
// different techniques.

// 1. Simple mean of rating value for most recent n reviews.
// 2. Weighted mean of last n reviews. The most recent n/2 reviews
//    will be weighted twice as much as the oldest n/2 reviews

// Overall rating should be a whole number

namespace MVC.Tests.Features
{
    using System.Collections.Generic;
    using System.Linq;

    using MVC.Models;

    using NUnit.Framework;

    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void ComputesResultForOneReview()
        {
            var data = BuildRestaurantAndReviews(4);

            var rater = new RestaurantRater(data);

            var result = rater.ComputeRating(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(4, result.Rating);
        }

        [Test]
        public void ComputesResultForTwoReviews()
        {
            var data = BuildRestaurantAndReviews(new[] { 4, 8 });

            var rater = new RestaurantRater(data);

            var result = rater.ComputeRating(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [Test]
        public void ComputesWeightedResultForTwoReviews()
        {
            var data = BuildRestaurantAndReviews(new[] { 3, 9 });

            var rater = new RestaurantRater(data);

            var result = rater.ComputeRating(new WeightedSimpleRatingAlgorithm(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        public void ComputeIncludesOnlyFirstNReviews()
        {
            var data = BuildRestaurantAndReviews(new[] { 1, 1, 1, 10, 10, 10 });

            var rater = new RestaurantRater(data);

            var result = rater.ComputeRating(new WeightedSimpleRatingAlgorithm(), 3);

            Assert.AreEqual(1, result.Rating);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new Restaurant();

            restaurant.Reviews = ratings.Select(r => new RestaurantReview { Rating = r })
                                        .ToList();

            return restaurant;
        }
    }
}