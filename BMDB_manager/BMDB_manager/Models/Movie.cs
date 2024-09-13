namespace BMDB_manager.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }

        public Movies(int idnum, string title, int year, string rating, string director)
        {
            Id = idnum;
            Title = title;
            Year = year;
            Rating = rating;
            Director = director;
        }
    }

}