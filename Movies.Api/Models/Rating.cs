namespace Movies.Api.Models
{
    public class Rating
    {
        public Rating()
        {}

        public Rating(decimal score, int userId)
        {
            Score = score;
            UserId = userId;
        }

        public decimal Score { get; set; }
        public int UserId { get; set; }
    }
}