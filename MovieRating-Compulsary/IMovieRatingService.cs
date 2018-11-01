namespace MovieRating_Compulsary
{
    public interface IMovieRatingService
    {
        //To load the file
        void LoadJson();
        
        //1
        int ReviewersTotalRatings(int x);
    }
}