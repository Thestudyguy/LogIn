using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogIn.App;
using Firebase.Database.Query;

namespace LogIn.Model
{
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public async Task<bool> AddUser(string fname, string lname, string email, string password)
        {
            try
            {
                var evaluateEmail = (await client
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Email == email);
                if(evaluateEmail == null)
                {
                    var users = new Users()
                    {
                        FirstName = fname,
                        LastName = lname,
                        Email = email,
                        Password = password
                    };
                    await client
                        .Child("Users")
                        .PostAsync(users);
                    client.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {

                return false;
            }
        }
    }
}
