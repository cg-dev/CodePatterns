using System.Collections.Generic;
using System.Linq;

namespace MVC.Tests.Features
{
    using MVC.Models;

    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }

    public class SimpleRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            return new RatingResult
            {
                Rating = (int)reviews.Average(r => r.Rating)
            };
        }
    }

    public class WeightedSimpleRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var counter = 0;
            var total = 0;

            for (int i = 0; i < reviews.Count(); i++)
            {
                if (i < reviews.Count() / 2)
                {
                    counter += 2;
                    total += reviews[i].Rating * 2;
                }
                else
                {
                    counter += 1;
                    total += reviews[i].Rating;
                }
            }

            return new RatingResult { Rating = total / counter };
        }
    }
}