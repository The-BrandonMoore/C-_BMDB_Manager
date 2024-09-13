using BMDB_manager.DB;
using BMDB_manager.Models;

namespace BMDB_manager
{
    internal class Program
    {

        public static MovieDB MovieDB = new MovieDB();


        static List<Actor> actors = new List<Actor>();
        static void Main(string[] args)
        {


            //intial movies into the list
            //movies.Add(new Movies(1, "The Princess Bride", 1987, "PG", "Rob Reiner"));
            //movies.Add(new Movies(2, "The Mummy", 1999, "PG-13", "Stephen Sommers"));
            //movies.Add(new Movies(3, "The Great Outdoors", 1988, "PG", "Howard Deutch"));
            //movies.Add(new Movies(4, "Lord of the Rings: The Fellowship of the Ring", 2001, "PG-13", "Peter Jackson"));
            //movies.Add(new Movies(5, "National Lampoon's Christmas Vacation", 1989, "PG-13", "Jeremiah S. Chechik"));

            //initial actors into the list
            actors.Add(new Actor(1, "Cary", "Elwes", "M", new DateOnly(1962, 10, 26)));
            actors.Add(new Actor(2, "Brendan", "Frasier", "M", new DateOnly(1968, 12, 03)));
            actors.Add(new Actor(3, "John", "Candy", "M", new DateOnly(1950, 10, 31)));
            actors.Add(new Actor(4, "Viggo", "Mortensen", "M", new DateOnly(1959, 10, 20)));
            actors.Add(new Actor(5, "Chevy", "Chase", "M", new DateOnly(1943, 10, 08)));
            actors.Add(new Actor(6, "Mandy", "Patinkin", "M", new DateOnly(1952, 11, 30)));
            actors.Add(new Actor(7, "Rachel", "Weisz", "F", new DateOnly(1970, 03, 07)));
            actors.Add(new Actor(8, "Dan", "Aykroyd", "M", new DateOnly(1952, 07, 01)));
            actors.Add(new Actor(9, "Ian", "McKellan", "M", new DateOnly(1939, 05, 25)));
            actors.Add(new Actor(10, "Randy", "Quaid", "M", new DateOnly(1950, 10, 01)));

            Console.WriteLine("  Welcome to the BootCamp Movie Database!");
            Console.WriteLine("===========================================");

            //MovieDB.LoadMoviesFile();

            // DisplayMenu();
            string command = "";
            while (command != "exit")
            {
                //get string for the command
                DisplayMenu();
                command = GetString("Please Enter a Menu Keyword: ");
                Console.WriteLine($"You have chosen: '{command}'.");
                //switch function
                switch (command)
                {
                    case ("menu"):
                        DisplayMenu();
                        break;

                    case ("movies"):
                    case ("movie"):
                        string movieCommand = "";
                        Console.WriteLine("\nYou have Entered the Movie Information Menu");
                        Console.WriteLine("To go back to the main menu, enter the command 'back'\n");
                        while (movieCommand != "back")
                        {
                            MovieMenu();
                            Console.Write("Enter a Movie Menu Keyword: ");
                            movieCommand = Console.ReadLine().ToLower();
                            switch (movieCommand)
                            {
                                case ("menu"):
                                    MovieMenu();
                                    break;
                                case ("list"):
                                    ListMovies();
                                    break;
                                case ("get"):
                                    GetMovieInfo();
                                    break;
                                case ("update"):
                                    UpdateMovieTitle();
                                    break;
                                case ("add"):
                                    AddMovie();
                                    break;
                                case ("del"):
                                    DeleteMovie();
                                    break;
                                case ("back"):
                                    break;
                                default:
                                    Console.WriteLine("Invalid keyword entered. Please enter a valid Menu keyword.");
                                    break;

                            }

                        }
                        break;

                    case ("actors"):
                    case ("actor"):
                        string actorCommand = "";
                        Console.WriteLine("\nYou Have Entered the Actor Information Menu");
                        Console.WriteLine("To go back to the main menu, enter the command 'back'\n");
                        while (actorCommand != "back")
                        {
                            ActorSubMenu();
                            Console.Write("Enter an Actor Menu Keyword: ");
                            actorCommand = Console.ReadLine().ToLower();
                            switch (actorCommand)
                            {
                                case ("menu"):
                                    ActorSubMenu();
                                    break;
                                case ("list"):
                                    ListActors();
                                    break;
                                case ("get"):
                                    GetActorInfo();
                                    break;
                                case ("add"):
                                    AddActor();
                                    break;
                                case ("del"):
                                    DeleteActor();
                                    break;
                                case ("back"):
                                    break;
                                default:
                                    Console.WriteLine("Invalid keyword. Please enter a valid Menu keyword.");
                                    break;
                            }
                        }
                        break;
                    case ("exit"):
                        break;
                    default:
                        Console.WriteLine("Invalid keyword entered. Please enter a valid Menu keyword.");
                        break;



                }
            }
            Console.WriteLine("Come back!");



        }

        private static void DeleteActor()
        {
            Console.WriteLine("Delete Actor from Database");
            Console.WriteLine("==========================");
            int deleteActorNum = GetInt("Desired Actor ID Number: ", 1, actors.Count());
            var deleteActor = actors[deleteActorNum - 1];
            string deleteActorFirstName = actors[deleteActorNum - 1].FirstName;
            string deleteActorLastName = actors[deleteActorNum - 1].LastName;
            actors.Remove(deleteActor);
            Console.WriteLine($"You have deleted {deleteActorFirstName} {deleteActorLastName} from the Actor Information Database");
        }

        private static void AddActor()
        {
            Console.WriteLine("Add an Actor to the database.");
            Console.WriteLine("============================+\n");
            int newActorId = actors.Count() + 1;
            Console.Write("Enter New Actor's First Name:  ");
            string newActorFirstName = Console.ReadLine();
            Console.Write("Enter New Actor's Last Name:  ");
            string newActorLastName = Console.ReadLine();

            DateOnly newActorDOB;
            while (true)
            {
                Console.Write("Enter New Actor's Date of Birth (yyyy-mm-dd): ");
                string inputDOB = Console.ReadLine();

                if (DateOnly.TryParse(inputDOB, out newActorDOB))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Date of Birth. Please enter a valid date of birth in the following format: yyyy-mm-dd");
                }
            }

            string newActorGender = "";
            while (true)
            {
                Console.Write("Enter New Actor's Gender (M or F): ");
                newActorGender = Console.ReadLine().ToUpper();

                if (newActorGender == "M" || newActorGender == "F")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Gender. Please Enter a valid gender input.");
                }


            }

            actors.Add(new Actor(newActorId, newActorFirstName, newActorLastName, newActorGender, newActorDOB));
            Console.WriteLine($"You have added {newActorFirstName} {newActorLastName} to the Boot Camp Movie Database.\n");
        }

        private static void GetActorInfo()
        {
            Console.WriteLine("Retrieve Actor Information by Actor ID");
            Console.WriteLine("=============================\n");
            int actorNumber = GetInt("Input desired Actor's ID number: ", 0, actors.Count());
            int actorNumber2 = actorNumber - 1;
            var actorChoice = actors[actorNumber2];
            Console.WriteLine($"Selected Actor information: ID#: {actorChoice.Id}, {actorChoice.FirstName} {actorChoice.LastName}, {actorChoice.Gender}, {actorChoice.BirthDate}\n");
        }

        private static void ListActors()
        {
            Console.WriteLine("List of all Actors");
            Console.WriteLine("++++++++++++++++++\n");
            for (int i = 0; i < actors.Count(); i++)
            {
                Console.WriteLine($"{actors[i].Id}. {actors[i].FirstName}, {actors[i].LastName}, {actors[i].Gender}, {actors[i].BirthDate}");
            }
        }

        private static void DeleteMovie()
        {
            Console.WriteLine("Delete Movie from Database");
            Console.WriteLine("==========================");

            bool getMovieCode = true;
            while (getMovieCode)
            {
                string checkerString = "n";
                int deleteNum = GetInt("Desired Movie ID Number: ", 1, MovieDB.GetMovies().Count()) -1;
                //  foreach (Movies m in MovieDB.GetMovies())
                // {
                Movies movieToDelete = MovieDB.GetMovies()[deleteNum];
                if (movieToDelete != null)
                {
                    getMovieCode = false;
                    string deletedTitle = MovieDB.GetMovies()[deleteNum].Title;
                    
                    MovieDB.GetMovies().Remove(movieToDelete);
                    for (int j = deleteNum; j < MovieDB.GetMovies().Count(); j++)
                    {
                        MovieDB.GetMovies()[j].Id = MovieDB.GetMovies()[j].Id - 1;//here is the issue
                    }
                    Console.WriteLine($"{deletedTitle} successfully deleted");
                    MovieDB.SaveMoviesFile();
                    checkerString = "y";
                    
                }
                //  }
                if (checkerString == "n")
                {
                    Console.WriteLine($"Movie ID {deleteNum} not found.");
                    Console.WriteLine("Please Enter a Valid Movie ID");
                    getMovieCode = true;
                }

            }
        }

        private static void AddMovie()
        {
            Console.WriteLine("Add a movie to the database.");
            Console.WriteLine("============================\n");
            int newMovieId = MovieDB.GetMovies().Count() + 1;
            Console.Write("Enter New Movie Title:  ");
            string newMovieTitle = Console.ReadLine();
            Console.Write("Enter New Movie Year: ");
            int newMovieYear = Int32.Parse(Console.ReadLine());

            string newMovieRating = "";
            while (true)
            {
                Console.Write("Enter New Movie Rating (G, PG, PG-13, R, NC-17): ");
                newMovieRating = Console.ReadLine().ToUpper();

                if (newMovieRating == "G" || newMovieRating == "PG" || newMovieRating == "PG-13" || newMovieRating == "R" || newMovieRating == "NC-17")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Rating. Please Enter a valid movie rating.");
                }


            }

            Console.Write("Enter New Movie Director: ");
            string newMovieDirector = Console.ReadLine();
            MovieDB.GetMovies().Add(new Movies(newMovieId, newMovieTitle, newMovieYear, newMovieRating, newMovieDirector));
            Console.WriteLine($"You have added {newMovieTitle} to the Boot Camp Movie Database.\n");
            MovieDB.SaveMoviesFile();
        }

        private static void UpdateMovieTitle()
        {
            int getNumber = GetInt("Input desired movie ID number: ", 0, MovieDB.GetMovies().Count()) - 1;
            Console.Write("Input the Updated Title:  ");
            string updatedTitle = Console.ReadLine();
            var movieChoice = MovieDB.GetMovies()[getNumber];
            movieChoice.Title = updatedTitle;
            Console.WriteLine($"You have successfully updated the title for {movieChoice.Title}.");
            MovieDB.SaveMoviesFile();

        }

        private static void GetMovieInfo()
        {
            Console.WriteLine("Retrieve a movie by ID Number");
            Console.WriteLine("=============================\n");
            int getNumber = GetInt("Input desired movie ID number: ", 0, MovieDB.GetMovies().Count());
            int getNumber2 = getNumber - 1;
            var movieChoice = MovieDB.GetMovies()[getNumber2];
            Console.WriteLine($"Selected Movie information: ID#: {movieChoice.Id}, {movieChoice.Title}, {movieChoice.Year}, {movieChoice.Rating}, {movieChoice.Director}\n");
        }

        private static string GetString(string prompt)
        {
            string command;
            Console.Write(prompt);
            command = Console.ReadLine().ToLower();
            return command;
        }

        private static void ActorSubMenu()
        {
            Console.WriteLine("  Actor Information Menu");
            Console.WriteLine("++++++++++++++++++++++++++++++");
            Console.WriteLine("Menu - Display Actor Info Menu");
            Console.WriteLine("List -- list all actors");
            Console.WriteLine("Get -- get actor information by ID");
            Console.WriteLine("Add -- add an actor");
            Console.WriteLine("Del -- delete an actor");
            Console.WriteLine("Back -- back to the main menu\n");
        }

        private static void MovieMenu()
        {
            Console.WriteLine("  Movie Information Menu");
            Console.WriteLine("++++++++++++++++++++++++++");
            Console.WriteLine("Menu - Display Movie Info Menu");
            Console.WriteLine("List -- list all movies");
            Console.WriteLine("Get -- get a movie by id");
            Console.WriteLine("Add -- add a movie");
            Console.WriteLine("Update -- Update a movie's title");
            Console.WriteLine("Del -- delete a movie");
            Console.WriteLine("Back -- back to the main menu\n");
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("\n  Main Menu");
            Console.WriteLine("+++++++++++++");
            Console.WriteLine("Menu - Display Main Menu");
            Console.WriteLine("Movies -- Enter the Movie Information Sub-Menu");
            Console.WriteLine("Actors -- Enter the Actor Information Sub-Menu");
            Console.WriteLine("Exit -- exit the app\n");
        }

        private static void ListMovies()
        {
            Console.WriteLine("List of all Movies.");
            Console.WriteLine("+++++++++++++++++++\n");
            for (int i = 0; i < MovieDB.GetMovies().Count; i++)
            {
                Console.WriteLine($"{MovieDB.GetMovies()[i].Id}. {MovieDB.GetMovies()[i].Title}, {MovieDB.GetMovies()[i].Year}, {MovieDB.GetMovies()[i].Rating}, {MovieDB.GetMovies()[i].Director}");
            }
            Console.WriteLine("");
        }

        private static int GetInt(string prompt, int min, int max)
        {
            int number = 0;
            Boolean isValid = false;

            while (!isValid)
            {
                try
                {
                    Console.Write(prompt);
                    number = Int32.Parse(Console.ReadLine());
                    if (number < min)
                    {
                        Console.WriteLine($"Invalid entry: number less than min ({min})");
                        continue;
                    }
                    else if (number > max)
                    {
                        Console.WriteLine($"Invalid entry: number greater than max ({max})");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid entry: please enter a valid integer.");
                    continue;
                }
            }
            return number;
        }
    }
}
