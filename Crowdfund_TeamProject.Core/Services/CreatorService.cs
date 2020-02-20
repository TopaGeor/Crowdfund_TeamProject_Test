using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
       
        public async Task<ApiResult<Creator>> AddCreatorAsync(AddCreatorOptions options)
        {
            if (options == null) {
                return new ApiResult<Creator>
                    (StatusCode.BadRequest, $"null {options}");
            }

            if (string.IsNullOrWhiteSpace(options.Email)) {
                return new ApiResult<Creator>
                   (StatusCode.BadRequest, $"null {options.Email} ");
            }

            if (string.IsNullOrWhiteSpace(options.Name)) {
                return new ApiResult<Creator>
                   (StatusCode.BadRequest, $"null {options.Name}");
            }

            var existName =  await SearchCreator(
                new SearchCreatorOptions()
                {
                    Name= options.Name
                }).AnyAsync();

            if (existName) {
                return new ApiResult<Creator>
                    (StatusCode.Conflict, "creator already exist");
            }

            var existEmail = await SearchCreator(
                new SearchCreatorOptions() { 
                Email = options.Email
                }).AnyAsync();

            if(existEmail) {
                return new ApiResult<Creator>
                     (StatusCode.Conflict, "this email address already used");
            }

            var newCreator = new Creator()
            {
                Email = options.Email,
                Name = options.Name,
            };

           await context_.AddAsync(newCreator);

            try {
               await context_.SaveChangesAsync();
            } catch (Exception) {

                return new ApiResult<Creator>
                    (StatusCode.InternalServerError,
                      "Error Save creator account");
            }

            return ApiResult<Creator>
                    .CreateSuccess(newCreator);

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

        public async Task<ApiResult<Creator>> UpdateCreatorAsync(int id, UpdateCreatorOptions options)
        {
            if (options == null) {
                return new ApiResult<Creator>
                   (StatusCode.BadRequest, $"null {options}");
            }

            if (id <= 0) {
                return new ApiResult<Creator>
                   (StatusCode.BadRequest, $"not valid creator {id}");
            }

            var user = await GetCreatorByIdAsync(id);

            if (user == null) {
                return new ApiResult<Creator>
                   (StatusCode.NotFound, $"not found {user}");
            }

            var exist = await SearchCreator(
               new SearchCreatorOptions()
               {
                   Name = options.Name
               }).AnyAsync();

            if (exist) {
                return new ApiResult<Creator>
                       (StatusCode.Conflict, "this name already used");
            }

            if (!string.IsNullOrWhiteSpace(options.Name)) {
                user.Data.Name = options.Name;
            }

            return ApiResult<Creator>
                    .CreateSuccess(user.Data);
        }

        public async Task<ApiResult<Creator>> GetCreatorByIdAsync(int id)
        {
            if (id <= 0) {
                return new ApiResult<Creator>(
                   StatusCode.BadRequest, $"not valid {id}");
            }

            var result =  await context_
                .Set<Creator>()
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            if (result == null) {
                return new ApiResult<Creator>(
                     StatusCode.NotFound, $"this {result} dont exist");
            }

            return ApiResult<Creator>.CreateSuccess(result);


        }

        
    }
}
