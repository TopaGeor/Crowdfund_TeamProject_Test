using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Model;

namespace Crowdfund.Core.Services
{
    public class CreatorService : ICreatorService
    {
        ICollection<Creator> CreatorList = new List<Creator>();
        public bool AddCreator(AddCreatorOptions options)
        {
            if (options == null) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return false;
            }

            if (string.IsNullOrWhiteSpace(options.Password)) {
                return false;
            }

            var exist = SearchCreator(
                new SearchCreatorOptions() { 
                Email = options.Email
                }).Any();

            if(exist) {
                return false;
            }

            var newCreator = new Creator()
            {
                Email = options.Email,
                Name = options.Name,
                Password = options.Password
            };

            if (CreatorList.Contains(newCreator)) {
                return false;
            }

            CreatorList.Add(newCreator);
            return true;

        }

        public ICollection<Creator> SearchCreator(SearchCreatorOptions options)
        {
            var result = CreatorList.Take(100);

            if (options == null) {
                return null;
            }
            if (options.Id != 0 && options.Id > 0) {
                result = CreatorList.Where(u => u.Id == options.Id);
            }
            if (string.IsNullOrWhiteSpace(options.Name)) {
                result = CreatorList.Where(u => u.Name == options.Name);
            }
            if (string.IsNullOrWhiteSpace(options.Email)) {
                result = CreatorList.Where(u => u.Email == options.Email);
            }
            return result.ToList();
        }

        public bool UpdateCreator(int id, UpdateCreatorOptions options)
        {
            if (options == null) {
                return false;
            }
            if (id <= 0) {
                return false;
            }
            var user = GetCustomerById(id);

            if (user == null) {
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

        public Creator GetCustomerById(int id)
        {
            if (id <= 0) {
                return null;
            }
            return CreatorList.Where(s => s.Id == id)
                 .SingleOrDefault();
        }
    }
}
