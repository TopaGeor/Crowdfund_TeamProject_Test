using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace TinyCrm.Core.Services
{
    class UserService : IUserService
    {
        ICollection<User> UsersList = new List<User>();

        public bool CreateUser(AddUserOptions options)
        {
            if(options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name) ||
                string.IsNullOrWhiteSpace(options.Email) ||
                string.IsNullOrWhiteSpace(options.Password)) {
                return false;
            }


            if(options.Id <= 0) {
                return false;
            }

            if(UsersList.Where(u =>u.Id == options.Id ) != null) {
                return false;
            }

            var newUser = new User()
            {
                Id = options.Id,
                Name = options.Name,
                Email = options.Email,
                Password = options.Password
            };


            if (UsersList.Contains(newUser)) {
                return false;
            }

            UsersList.Add(newUser);

            return true;
        }

        public ICollection<User> SearchByUser(SearchUserOptions options)
        {
            var result = UsersList.Take(100);
            
            if(options == null) {
                return null;
            }

            if(options.Id != 0 && options.Id >0) {
              result = UsersList.Where(u => u.Id == options.Id);
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
               result = UsersList.Where(u => u.Name == options.Name);
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
               result = UsersList.Where(u => u.Email == options.Email);
            }
            return result.ToList();
        }

        public bool UpdateUser(int id,UpdateUserOptions options)
        {
            if (options == null) {
                return false;
            }

            if(id <= 0) {
                return false;
            }

            var user = GetCustomerById(id);
             
            if(user == null) {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(options.Password)) {
                user.Password = options.Password;
            }

            if (!string.IsNullOrWhiteSpace(options.Name)) {
                user.Name = options.Name;
            }

            return true; 
        }

        public User GetCustomerById(int id)
        {
            if (id <= 0) {
                return null;
            }

            return UsersList.Where(s => s.Id == id)
                 .SingleOrDefault();
        }
    }
}
