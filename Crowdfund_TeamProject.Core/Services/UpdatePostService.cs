using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crowdfund.Core.Services;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Data;
using Microsoft.EntityFrameworkCore;

namespace Crowdfund_TeamProject.Core.Services
{
    public class UpdatePostService : IUpdatePostService
    {
        private readonly Crowdfund_TeamProjectDbContext context_;
        private readonly ILoggerService logger_;
        private readonly IProjectService project_;


        public UpdatePostService(
            Crowdfund_TeamProjectDbContext context,
            IProjectService project,
            ILoggerService logger)
        {
            context_ = context;
            logger_ = logger;
            project_ = project;
        }

        public async Task<ApiResult<UpdatePost>> AddUpdatePostAsync(AddUpdatePostOptions options)
        {
            if(options == null) {
                return new ApiResult<UpdatePost>
                     (StatusCode.BadRequest, $"null {options}");
            }
            if(options.ProjectId <= 0) {
                return new ApiResult<UpdatePost>
                   (StatusCode.BadRequest, $"not valid  {options.ProjectId}");
            }

            var proj = await project_
                .SearchProjectByIdAaync(
                options.ProjectId);

            if(proj.Data == null) {
                return proj.GetApi<UpdatePost>();

            }

            if (string.IsNullOrWhiteSpace(options.Post)) {
                return new ApiResult<UpdatePost>
                   (StatusCode.BadRequest, $"not valid  {options.Post}");
            }

            var newUpdPost = new UpdatePost()
            {
                Post = options.Post,
                DatePost = DateTime.Now,
                Project = proj.Data
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

        public async Task<ApiResult<UpdatePost>> UpdatePostAsync(int postId, UpdatePostOptions options)
        {
            if(options == null) {
                return new ApiResult<UpdatePost>
                     (StatusCode.BadRequest, $"null {options}");
            }

            if(postId <= 0) {
               return new ApiResult<UpdatePost>
                   (StatusCode.BadRequest, $"not valid Project {postId}");
            }

            var post = await SearchUpdatePost(
                new SearchUpdatePostOptions()
                {
                    Id = postId
                }).SingleOrDefaultAsync();
            
            if(post == null) {
                return new ApiResult<UpdatePost>
                     (StatusCode.NotFound, $"not exist {post}");
            }

            if (string.IsNullOrWhiteSpace(options.Post)) {
                post.Post = options.Post;
            }
            if (options.DatePost != (default)) {
                post.DatePost = DateTimeOffset.Now;
            }

            return ApiResult<UpdatePost>
                    .CreateSuccess(post);
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
