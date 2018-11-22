using System;
using System.Collections.Generic;
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

        private readonly IMovieRatingService _movieRatingService = new MovieRatingService();

        
        
        //1 
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 5)]
        public void NumberReviewsFromReviewer(int input, int result)
        {
            int reviewsFromReviewer = _movieRatingService.ReviewersTotalRatings(input);
            Assert.Equal(result, reviewsFromReviewer);
        }
        
        //2
        [Theory]
        [InlineData(1, 1.5)]
        [InlineData(2, 3)]
        [InlineData(3, 3.5)]
        [InlineData(4, 4)]
        public void ReviewersAverageGradeTest(int input, double result)
        {
            double averageRate = _movieRatingService.ReviewersAverageGrade(input);
            Assert.Equal(result, averageRate);
        }   
        
        //3
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 2, 1)]
        [InlineData(4, 3, 2)]
        [InlineData(5, 4, 4)]
        public void ReviewersSpecificGradingTest(int input1, int input2, int result)
        {
            int givenGrade = _movieRatingService.ReviewersSpecificGrading(input1, input2);
            Assert.Equal(result, givenGrade);
        }
        //4
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 5)]
        [InlineData(3, 4)]
        [InlineData(4, 3)]
        public void HowManyTimesHasMovieBeenReviewedTest(int input, int result)
        {

            int movieReviewed = _movieRatingService.MovieAmountOfReviews(input);
            Assert.Equal(result, movieReviewed);
        }
        
        //5   
        [Theory]
        [InlineData(1, 3.6)]
        [InlineData(2, 2.8)]
        [InlineData(3, 4)]
        [InlineData(5, 3.5)]        
        public void AverageGradeOnMovieTest(int input, double result)
        {
            var averageGradeOfMovie = _movieRatingService.AverageGradeOfMovie(input); 

            Assert.Equal(result, averageGradeOfMovie);
        }
        
        //6
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 1)]
        [InlineData(3, 4, 2)]
        [InlineData(4, 1, 0)]
        public void HowManyTimesHasMovieReceivedSpecificGradeTest(int input1, int input2, int result)
        {
            var sw = new Stopwatch();
            sw.Start();

            var movieGrade =
                _movieRatingService.HowManyTimesHasMovieReceivedSpecificGrade(input1, input2);

            Assert.Equal(result, movieGrade);
        }
     }
}
