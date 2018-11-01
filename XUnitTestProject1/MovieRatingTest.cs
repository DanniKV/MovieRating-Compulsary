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
        private const int SpecificGradeTest = 1;
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
                "There was found 0 or less");

            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //2
        [Fact]
        public void ReviewersAverageGradeTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var averageGrade = _movieRatingService.ReviewersAverageGrade(ReviewerIdTest);
            
            Assert.True(averageGrade >= 0 && averageGrade <= 5,
            "The average grade is not between 0 and 5");
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
            
        }   
        
        //3
        [Fact]
        public void ReviewersSpecificGradingTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var specificGradeCount = _movieRatingService.ReviewersSpecificGrading(ReviewerIdTest, SpecificGradeTest);

            Assert.True(specificGradeCount >= 0,
                "The number of specific grades are 0 or less");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        //4
        [Fact]
        public void HowManyTimesHasMovieBeenReviewedTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var movieReviewAmount = _movieRatingService.MovieAmountOfReviews(MovieIdTest);

            Assert.True(movieReviewAmount >= 0,
                "There was found 0 or less reviews");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //5   
        [Fact]
        public void AverageGradeOnMovieTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var averageGradeOfMovie = _movieRatingService.AverageGradeOfMovie(1488844); //This number somehow works.

            Assert.True(averageGradeOfMovie >= 0 && averageGradeOfMovie <= 5,
                "The average grade is not between 0 and 5");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //6
        [Fact]
        public void HowManyTimesHasMovieReceivedSpecificGradeTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var specificGradeCount = _movieRatingService.HowManyTimesHasMovieReceivedSpecificGrade(MovieIdTest, SpecificGradeTest);

            Assert.True(specificGradeCount >= 0,
                "The number of specific grades are 0 or less");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //7 
        [Fact]
        public void MoviesWithMostRatingsOfFiveTest()        
        {
            var sw = new Stopwatch();
            sw.Start();

            var moviesWithMostRatingsOfFive = _movieRatingService.MoviesWithMostRatingsOfFive();

            Assert.True(moviesWithMostRatingsOfFive.Count >= 0,
                "It didn't work! (I have no idea what to write here)");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //8
        [Fact]
        public void ReviewerWithMostReviewsTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var reviewerWithMostRatings = _movieRatingService.ReviewerWithMostRatings();

            Assert.True(reviewerWithMostRatings >= 0,
                "There was found 0 or less ratings");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //9
        [Fact]
        public void FindTopXOfMoviesTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var topXOfMovies = _movieRatingService.FindTopXOfMovies(5);
            
            
            
            Assert.True(topXOfMovies.Count == 5,
                "The top 5 wasn't found");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0,0,0,4,0),
                "The function took 4 seconds or more.");
        }
        
        //10
        [Fact]
        public void WhatMoviesHasXReviewedTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var whatMoviesHasXRated = _movieRatingService.WhatMoviesHasXRated(ReviewerIdTest);

            Assert.True(whatMoviesHasXRated.Count >= 0,
                "There was found 0 or less ratings");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
        
        //11 
        [Fact]
        public void WhatReviewersHasReviewedXMovieTest()
        {
            var sw = new Stopwatch();
            sw.Start();

            var whatReviewersHasRatedXMovie = _movieRatingService.whatReviewersHasRatedXMovie(MovieIdTest);

            Assert.True(whatReviewersHasRatedXMovie.Count >= 0,
                "There was found 0 or less ratings");
            
            
            Assert.True(sw.Elapsed < new TimeSpan(0, 0, 0, 4, 0),
                "The function took 4 seconds or more.");
        }
    }
}
