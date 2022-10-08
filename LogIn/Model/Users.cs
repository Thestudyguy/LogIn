using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogIn.App;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace LogIn.Model
{
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task<string> DeleteData()
        {
            try
            {
                await client
                    .Child($"Users/{key}")
                    .DeleteAsync(); 
                     return "Removed";
            }
            catch(Exception ex)
            {
                return "Error";
            }
        }

        public async Task<bool> EditData(string fname, string lname, string pwrd)
        {
            try
            {
                var evaluateuser = (await client
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Email == email);

                if(evaluateuser != null)
                {
                    Users user = new Users
                    {
                        Email = email,
                        FirstName = fname,
                        LastName = lname,
                        Password = pwrd
                    };
                    await client
                        .Child("Users")
                        .Child(key)
                        .PatchAsync(user);
                         client.Dispose();
                         return true;
                }
                client.Dispose();
                return false;
            }
            catch(Exception e)
            {
                client.Dispose();
                return false;
            }
        }

        public async Task<bool> AddUser(string fname, string lname, string email, string password)
        {
            try
            {
                var evaluateEmail = (await client
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Email == email);
                if (evaluateEmail == null)
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
        public async Task<bool> UserLogIn(string email, string password)
        {
            try
            {
                var evaluateEmail = (await client
               .Child("Users")
               .OnceAsync<Users>())
               .FirstOrDefault
               (a => a.Object.Email == email && a.Object.Password == password);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }


        }

        public ObservableCollection<Users> GetUserList()
        {
            var userList = client
                .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userList;
        }

        public async Task<string> GetUserKey(string mail)
        {
            try
            {
                var getuserkey = (await client
                    .Child("Users")
                    .OnceAsync<Users>()).FirstOrDefault
                    (a => a.Object.Email == mail);
                if (getuserkey == null) return null;
                firstname = getuserkey.Object.FirstName;
                lastname = getuserkey.Object.LastName;
                password = getuserkey.Object.Password;
                    return getuserkey?.Key;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
  
}
   
