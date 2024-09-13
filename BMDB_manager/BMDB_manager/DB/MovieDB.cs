using BMDB_manager.Models;

namespace BMDB_manager.DB
{
    public class MovieDB
    {

        List<Movies> movies = new List<Movies>();
        string moviePath = @"C:\files\Movies.txt";

        public MovieDB()
        {
            LoadMoviesFile();
        }

        public List<Movies> GetMovies()
        {
            return movies;
        }

        public void LoadMoviesFile()
        {
            using StreamReader textLoad = new(new FileStream(moviePath, FileMode.OpenOrCreate, FileAccess.Read));
            while (textLoad.Peek() != -1)
            {
                string row = textLoad.ReadLine() ?? "";
                string[] fields = row.Split('|');
                if (fields.Length == 5)
                {
                    int id = int.Parse(fields[0]);
                    string title = fields[1];
                    int year = int.Parse(fields[2]);
                    string rating = fields[3];
                    string director = fields[4];
                    Movies m = new Movies(id, title, year, rating, director);
                    movies.Add(m);
                }
            }
        }

        public void SaveMoviesFile()
        {
            using StreamWriter movieSave = new(new FileStream(moviePath, FileMode.Create, FileAccess.Write));
            foreach (Movies m in movies)
            {
                movieSave.Write(m.Id + "|");
                movieSave.Write(m.Title + "|");
                movieSave.Write(m.Year + "|");
                movieSave.Write(m.Rating + "|");
                movieSave.WriteLine(m.Director);
                //could also do textSave.WriteLine($"{p.Code}|{p.Description}|{p.Price}");
            }
        }



    }
}
