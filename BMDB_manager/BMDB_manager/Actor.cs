
namespace BMDB_manager
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
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.BirthDate = birthdate;
        }
    }
}
