using quiz_project.Models;

namespace quiz_project.Services
{
    public class AuthService
    {
        public List<User> Users = new();

        public string CurrentUser = "";

        public bool Signup(string username, string password)
        {
            if (Users.Any(x => x.Username == username))
                return false;

            Users.Add(new User
            {
                Username = username,
                Password = password
            });

            return true;
        }
        public bool Login(string username, string password)
        {
            var user = Users.FirstOrDefault(x =>
                x.Username == username &&
                x.Password == password);

            if (user == null)
                return false;

            CurrentUser = username;
            return true;
        }

        public void Logout()
        {
            CurrentUser = "";
        }
    }
}
