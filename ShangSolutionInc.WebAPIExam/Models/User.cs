namespace ShangSolutionInc.WebAPIExam.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string State { get; set; }
    }

    public class UserWrapper
    {
        public User User { get; set; }
    }
}
