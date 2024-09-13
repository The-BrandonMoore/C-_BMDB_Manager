namespace BMDB_manager.Models
{
    internal class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateOnly BirthDate { get; set; }


        public Actor(int id, string firstName, string lastName, string gender, DateOnly birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthdate;
        }
    }
}
