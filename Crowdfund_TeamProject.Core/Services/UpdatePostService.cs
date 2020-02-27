using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using Crowdfund_TeamProject.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund_TeamProject.Core.Services
{
    public class UpdatePostService : IUpdatePostService
    {
        private readonly Crowdfund_TeamProjectDbContext context_;
        private readonly ILoggerService logger_;

        public UpdatePostService(
            Crowdfund_TeamProjectDbContext context,
            ILoggerService logger)
        {
            context_ = context;
            logger_ = logger;
        }

        public async Task<ApiResult<UpdatePost>> AddUpdatePostAsync(int id, AddUpdatePostOptions options)
        {
            if(options == null) {
                return new ApiResult<UpdatePost>(
                    StatusCode.BadRequest, $"null {options}");
            }

            if (string.IsNullOrWhiteSpace(options.Post)) {
                return new ApiResult<UpdatePost>(
                    StatusCode.BadRequest, $"not valid  {options.Post}");
            }

            var newUpdPost = new UpdatePost()
            {
                Post = options.Post,
                DatePost = DateTime.Now,
                
            };

            await context_.AddAsync(newUpdPost);
            try {
                await context_.SaveChangesAsync();
            } catch (Exception) {

                logger_.LogError(StatusCode.InternalServerError,
                    $"Error Save Project with Title {newUpdPost.DatePost}");

                return new ApiResult<UpdatePost>(
                    StatusCode.InternalServerError,
                    "Error Save Project");
            }

            return ApiResult<UpdatePost>
                    .CreateSuccess(newUpdPost);
        }

        public IQueryable<UpdatePost> SearchUpdatePost(SearchUpdatePostOptions options)
        {
            if(options == null) {
                return null;
            }

            var query = context_
                .Set<UpdatePost>()
                .AsQueryable();

            if (options.Id > 0) {
                query = query
                       .Where(p => p.Id == options.Id);
            }

            if (options.DatePost != (default)) {
                query = query
                        .Where(p => p.DatePost == options.DatePost);
            }

            return query.Take(500);
        }      
    }
}
