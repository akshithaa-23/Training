namespace BasicAuthentication.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }

        public bool isActive { get; set; }= true;
        public DateTime date { get; set; } = DateTime.Now;

    }
}
