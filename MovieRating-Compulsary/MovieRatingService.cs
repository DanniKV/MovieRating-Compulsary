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
        
    }
}