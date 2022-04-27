namespace ShangSolutionInc.WebAPIExam.DependencyInjection
{
    public class Main
    {
        public void main() 
        {
            ClientAUser clientAUser = new ClientAUser();
            ClientBUser clientBUser = new ClientBUser();

            checkUser(clientAUser); //Accepts ClientAUser object

            checkUser(clientBUser); //Accepts ClientBUser object
        }

        public void checkUser(IUser user)
        {
            //code here
        }
    }

    public interface IUser
    { 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class ClientAUser : IUser
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
    }

    public class ClientBUser : IUser
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Level { get; set; }
    }
}
