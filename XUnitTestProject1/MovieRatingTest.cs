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
        private const int SpecificGrade = 1;
        private const int MovieIdTest = 1;
        private readonly IMovieRatingService _movieRatingService = new MovieRatingService();
        /**
         *  Running the unit test takes a while at the start
         *  Due to the fact that it has the load the JSONFile
         */
        
        
        //1 
        [Fact]
        public void ReviewersTotalRatingsTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var reviewersTotalReviews = _movieRatingService.ReviewersTotalRatings(ReviewerIdTest);
            Assert.True(reviewersTotalReviews >= 0,
                "There was found more than 0 ratings");

            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 minutes or more.");
        }
        
        //2
        [Fact]
        public void ReviewersAverageGradeTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var averageGrade = _movieRatingService.ReviewersAverageGrade(ReviewerIdTest);
            
            Assert.True(averageGrade >= 0 && averageGrade <= 5,
            "The average grade is between 0 and 5");
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 minutes or more.");
            
        }   
        
        //3
        [Fact]
        public void ReviewersSpecificGradingTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var specificGradeCount = _movieRatingService.ReviewersSpecificGrading(ReviewerIdTest, SpecificGrade);

            Assert.True(specificGradeCount >= 0,
                "The number of specific grades are more than 0");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 minutes or more.");
        }
    }
}
