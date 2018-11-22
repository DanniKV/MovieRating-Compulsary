using System.Collections.Generic;

namespace MovieRating_Compulsary
{
    public interface IMovieRatingService
    {
        //To load the file
        void LoadJson();
        
        //1
        int ReviewersTotalRatings(int x);
        //2
        double ReviewersAverageGrade(int x);
        //3
        int ReviewersSpecificGrading(int x, int y);
        //4
        int MovieAmountOfReviews(int x);
        //5
        double AverageGradeOfMovie(int x);
        //6
        int HowManyTimesHasMovieReceivedSpecificGrade(int x, int y);
        //7
        List<MovieRatingEntity> MoviesWithMostRatingsOfFive();
        //8
        int ReviewerWithMostRatings();
        //9
        List<int> FindTopXOfMovies(int x);
        //10
        List<MovieRatingEntity> WhatMoviesHasXRated(int x);
        //11
        List<MovieRatingEntity> WhatReviewersHasRatedXMovie(int x);
    }
    
}