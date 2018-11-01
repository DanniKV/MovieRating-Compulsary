using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace MovieRating_Compulsary
{
    public class MovieRatingService: IMovieRatingService
    {
        //VERY IMPORTANT. REMEMBER TO DELETE YOUR PATH BEFORE COMMITTING
        //Jakobs - "/Users/choi/Desktop/ratings.json"
        //Dannis - 
        private const string JsonPath = ""; //ENTER PATH HERE TO THE JSON FILE
        
        private static List<MovieRatingEntity> ratings;

        public void LoadJson()
        {
            if (ratings == null)
            {
                using (var reader = new StreamReader(JsonPath))
                {
                    var jsonFile = reader.ReadToEnd();
                    ratings = JsonConvert.DeserializeObject<List<MovieRatingEntity>>(jsonFile);
                }
            }
        }
        
        //1
        public int ReviewersTotalRatings(int x)
        {
            return ratings.Count(i => i.Reviewer == x);
        }
        
        //2 
        public double ReviewersAverageGrade(int x)
        {
            return ratings.Where(i => i.Reviewer == x).Average(i => i.Grade);
        }
        
        //3
        public int ReviewersSpecificGrading(int x, int y)
        {
            return ratings.Count(i => i.Reviewer == x && i.Grade == y);
        }
        
        //4
        public int MovieAmountOfReviews(int x)
        {
            return ratings.Count(i => i.Movie == x);
        }
        //5
        public double AverageGradeOfMovie(int x)
        {
            return ratings.Where(i => i.Movie == x).Average(info => info.Grade);
        }
        //6
        public int HowManyTimesHasMovieReceivedSpecificGrade(int x, int y)
        {
            return ratings.Count(i => i.Movie == x && i.Grade == y);
        }
        //7
        public List<MovieRatingEntity> MoviesWithMostRatingsOfFive()
        {
            var topMovies = new List<MovieRatingEntity>();
            
            topMovies.AddRange(ratings.Where(i => i.Grade == 5));

            return topMovies;
        }
        //8
        public int ReviewerWithMostRatings()
        {
            return ratings.GroupBy(i => i.Reviewer).OrderByDescending(i2 => i2.Count()).Take(1).Select(i3 => i3.Key).FirstOrDefault();
        }
        
        //9
        public List<int> FindTopXOfMovies(int x)
        {
            return ratings.GroupBy(i => i.Movie).OrderByDescending(i2 => i2.Average(i3 => i3.Grade))
                .Select(i4 => i4.Key).Take(x).ToList();
        }
        
        //10
        public List<MovieRatingEntity> WhatMoviesHasXRated(int x)
        {
            return ratings.Where(i => i.Reviewer == x)
                .OrderByDescending(i2 => i2.Grade)
                .ThenByDescending(i3 => i3.Date).ToList();
        }

        public List<MovieRatingEntity> whatReviewersHasRatedXMovie(int x)
        {
            return ratings.Where(i => i.Movie == x)
                .OrderByDescending(i2 => i2.Grade)
                .ThenByDescending(i3 => i3.Date).ToList();
        }
    }
}