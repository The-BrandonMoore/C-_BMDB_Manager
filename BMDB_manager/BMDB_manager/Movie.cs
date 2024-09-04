
namespace BMDB_manager
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
            this.Id = idnum;
            this.Title = title;
            this.Year = year;
            this.Rating = rating;
            this.Director = director;
        }
    }

}