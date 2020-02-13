using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model.Options;
using Crowdfund.Core.Model;
using Crowdfund_TeamProject.Data;


namespace Crowdfund.Core.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly Crowdfund_TeamProjectDbContext context_;

        public CreatorService( Crowdfund_TeamProjectDbContext context)
        {
            context_ = context ??
                throw new ArgumentException(nameof(context));
        }
       
        
        public Creator AddCreator(AddCreatorOptions options)
        {
            if (options == null) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return null;
            }
            var existName = SearchCreator(
                new SearchCreatorOptions()
                {
                    Name= options.Name
                }).Any();
           
            if (existName) {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Password)) {
                return null;
            }

            var existEmail = SearchCreator(
                new SearchCreatorOptions() { 
                Email = options.Email
                }).Any();

            if(existEmail) {
                return null;
            }

            var newCreator = new Creator()
            {
                Email = options.Email,
                Name = options.Name,
                Password = options.Password
            };

            context_.Add(newCreator);
            try {
                context_.SaveChanges();
            } catch (Exception) {
                return null;
            }

            return newCreator;

        }

        public IQueryable<Creator> SearchCreator(SearchCreatorOptions options)
        { 

            if (options == null) {
                return null;
            }

            var query = context_
                .Set<Creator>()
                .AsQueryable();

            if (options.Id != 0 && options.Id > 0) {
                query = query
                    .Where(c => c.Id == options.Id);
            }
            if (string.IsNullOrWhiteSpace(options.Name)) {
                query = query
                    .Where(c => c.Name == options.Name);
            }
            if (string.IsNullOrWhiteSpace(options.Email)) {
                query = query
                    .Where(c => c.Email == options.Email);
            }
            return query.Take(500);
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

          return context_
                 .Set<Creator>()
                 .Where(s => s.Id == id)
                 .SingleOrDefault();
        }
    }
}
