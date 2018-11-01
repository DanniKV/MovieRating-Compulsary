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
    }
    
}