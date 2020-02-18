using System.Collections.Generic;
using System.Linq;
using Knewin.Domain.Entities;

namespace Knewin.API.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            if(!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password)){
                var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin", Role = "manager" });
            users.Add(new User { Id = 2, Username = "pedro", Password = "1234", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
            }

            return null;
        }
    }
}