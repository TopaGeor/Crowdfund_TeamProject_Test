using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;
using Crowdfund_TeamProject.Core.Services;
using Crowdfund_TeamProject.Data;
using Microsoft.EntityFrameworkCore;

namespace Crowdfund_TeamProject.Services
{
    class ProjectService : IProjectService
    {
        private readonly ICreatorService creator_;
        private readonly ITierService tiers_;
        private readonly ILoggerService logger_;
        private readonly IUpdatePostService updatePost_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public ProjectService(
           ICreatorService creator,
           ITierService tiers,
           ILoggerService logger,
           IUpdatePostService updatePost,
           Crowdfund_TeamProjectDbContext context)
        {
            creator_ = creator;
            context_ = context;
            tiers_ = tiers;
            logger_ = logger;
            updatePost_ = updatePost;
        }

        public async Task<ApiResult<Project>> CreateProjectAsync(int creatorId, AddProjectOptions options)
        {
            if(options == null) {
                return new ApiResult<Project>
                    (StatusCode.BadRequest, $"null {options}");
            }

            if(creatorId <= 0) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid creator {creatorId}");
            }

            var creator = await creator_.SearchCreator(
               new SearchCreatorOptions()
               {
                   Id = creatorId
               }).SingleOrDefaultAsync();
               

            if(creator == null) {
                return new ApiResult<Project>
                    (StatusCode.NotFound, $"not valid  {creator}");
            }

            if (string.IsNullOrWhiteSpace(options.Title)) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest,
                   $"not valid  {options.Title}");
            }

            if(options.TiersId == null ||
              options.TiersId.Count == 0) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid  {options.TiersId}");
            }

            var tierList = new List<Tier>();

            foreach (var t in options.TiersId) {
                var result = await tiers_.GetTierByIdAsync(t);

                if (result.ErrorCode != StatusCode.OK) {
                    return result.GetApi<Project>();
                }

                tierList.Add(result.Data);
            }

            if (options.Goal <= 0.00M) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid {options.Goal}");
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Project>
                  (StatusCode.BadRequest, $"not valid  {options.Description}");
            }

            if (string.IsNullOrWhiteSpace(options.PhotoUrl)) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid  {options.PhotoUrl}");
            }

            if (string.IsNullOrWhiteSpace(options.VideoUrl)) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid  {options.VideoUrl}");
            }

            if (string.IsNullOrWhiteSpace(options.UpdatePost)) {
                return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid  {options.UpdatePost}");
            }

            if (options.Category == ProjectCategory.Invalid) {
                return new ApiResult<Project>
                  (StatusCode.BadRequest, $"not valid  {options.Category}");
            }

            var newProj = new Project() {
                Description = options.Description,
                Title = options.Title,
                Creator = creator,
                Category = options.Category,
                ExplirationDate = options.ExplirationDate,
                Goal = options.Goal,
                //PhotoUrl = options.PhotoUrl,
                //VideoUrl = options.VideoUrl
            };

            newProj.Tiers = tierList;

            await context_.AddAsync(newProj);
            try {
                await  context_.SaveChangesAsync();
            } catch (Exception) {

                logger_.LogError(StatusCode.InternalServerError,
                    $"Error Save Project with Title {newProj.Title}");

                return new ApiResult<Project>(
                    StatusCode.InternalServerError,
                    "Error Save Project");
            }

            return ApiResult<Project>
                    .CreateSuccess(newProj);
        }

        public IQueryable<Project> SearchProject(int id, SearchProjectOptions options)
        {
            
            if(options == null) {
                return null;
            }

            var query = context_
                .Set<Project>()
                .AsQueryable();

            if (id > 0 ) {
                query = query
                     .Where(p => p.Id == id);
            }

            if (!string.IsNullOrWhiteSpace(options.Title)) {
                query = query
                    .Where(p => p.Title == options.Title);
            }

            var creator = creator_.SearchCreator(
                new SearchCreatorOptions()
                {
                    Id = options.Creator.Id
                }).SingleOrDefault();

            if(creator != null) {
                query = query
                    .Where(p => p.Creator == creator);
            }

            if(options.Category != ProjectCategory.Invalid) {
                query = query
                    .Where(p => p.Category == options.Category);
            }

            if(options.ExplirationDate != (default)) {
                query = query
                    .Where(p => p.ExplirationDate == options.ExplirationDate);
            }

            return query.Take(500);
        }

        public async Task<ApiResult<Project>> UpdateProjectAsync(int Projectid, 
                        UpdateProjectOptions options)
        {
            if (options == null) {
                return new ApiResult<Project>
                    (StatusCode.BadRequest, $"null {options}");
            }

            if (Projectid <= 0) {
               return new ApiResult<Project>
                   (StatusCode.BadRequest, $"not valid Project {Projectid}");
            }

            var project = await SearchProject(Projectid,
                new SearchProjectOptions())
                .SingleOrDefaultAsync();

            if (project == null) {
                return new ApiResult<Project>
                     (StatusCode.NotFound, $"not exist {project}");
            }

            if (string.IsNullOrWhiteSpace(options.Description)) {
                project.Description = options.Description;
            }

            if (string.IsNullOrWhiteSpace(options.PhotoUrl)) {
                project.PhotoUrl = options.PhotoUrl;
            }

            if (string.IsNullOrWhiteSpace(options.VideoUrl)) {
                project.PhotoUrl = options.VideoUrl;
            }

            if (options.ExplirationDate != (default)) {
                project.ExplirationDate = options.ExplirationDate;
            }

            var updPost = updatePost_.SearchUpdatePost(
                new SearchUpdatePostOptions()
                {
                    Id = options.UpdatePost.Id
                }).SingleOrDefault();

            if (updPost != null) {
                project.UpdatePost.Add(updPost);
            }

            return ApiResult<Project>
                    .CreateSuccess(project);
        }

        public async Task<ApiResult<Project>> SearchProjectByIdAaync(int id)
        {
            if (id <= 0) {
                return new ApiResult<Project>(
                   StatusCode.BadRequest, $"not valid {id}");
            }

            var result = await context_
                .Set<Project>()
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            if (result == null) {
                return new ApiResult<Project>(
                     StatusCode.NotFound, $"this {result} dont exist");
            }

            return ApiResult<Project>
                .CreateSuccess(result);
        }
    }
}
