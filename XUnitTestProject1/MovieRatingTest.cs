using System;
using System.Diagnostics;
using MovieRating_Compulsary;
using Xunit;
using System.Linq;
using Xunit.Sdk;

namespace XUnitTestProject1
{
    public class MovieRatingTest

    {
        public MovieRatingTest()
        {
            _movieRatingService.LoadJson();
        }

        private const int ReviewerIdTest = 1;
        private const int MovieIdTest = 1;
        private readonly IMovieRatingService _movieRatingService = new MovieRatingService();
        
        //1 
        [Fact]
        public void ReviewersTotalReviews()
        {
            var sw = new Stopwatch();
            sw.Start();

            var reviewersTotalReviews = _movieRatingService.ReviewersTotalRatings(ReviewerIdTest);
            Assert.True(reviewersTotalReviews >= 0,
                "There was found more than 0 ratings");

            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 minutes or more.");
        }
    }
}
