using System;
namespace AccountLibraryService
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordCheck { get; set; }

        public User(string userName, string email, string password, string passwordCheck)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PasswordCheck = passwordCheck;
        }

        //test

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public User()
        {
        }
    }
}
