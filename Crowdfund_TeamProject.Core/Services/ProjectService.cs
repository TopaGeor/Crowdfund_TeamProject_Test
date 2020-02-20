using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;
using Crowdfund_TeamProject.Core;
using Crowdfund_TeamProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfund.Core.Services
{
    class ProjectService : IProjectService
    {
        private readonly ICreatorService creator_;
        private readonly IBackerService backers_;
        private readonly ITierService tiers_;
        private readonly Crowdfund_TeamProjectDbContext context_;

        public ProjectService(
           ICreatorService creator,
           IBackerService backers,
           TierService tiers,
           Crowdfund_TeamProjectDbContext context)
        {
            creator_ = creator;
            context_ = context;
            backers_ = backers;
            tiers_ = tiers;
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
                   (StatusCode.BadRequest, $"not valid  {options.Title}");
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

            //if (options.Photo.Count > 0) {
            //    foreach (var p in options.Photo) {
            //        if (string.IsNullOrWhiteSpace(p)) {
            //            return null;
            //        }
            //    }
            //}

            if (string.IsNullOrWhiteSpace(options.Description)) {
                return new ApiResult<Project>
                  (StatusCode.BadRequest, $"not valid  {options.Description}");
            }

            //if (options.Video.Count > 0) {
            //    foreach (var v in options.Video) {
            //        if (string.IsNullOrWhiteSpace(v)) {
            //            return null;
            //        }
            //    }
            //}

            if(options.Category == ProjectCategory.Invalid) {
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
                //Photos = options.Photo,
                //Videos = options.Video
            };

            newProj.Tiers = tierList;

           await context_.AddAsync(newProj);
            try {
              await  context_.SaveChangesAsync();
            } catch (Exception) {
                return new ApiResult<Project>
                     (StatusCode.InternalServerError,
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

            }

            return query.Take(500);
        }

        public async Task<ApiResult<Project>> UpdateProjectAsync(int Projectid, UpdateProjectOptions options)
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

            //foreach (var p in options.Photo) {
            //    if (string.IsNullOrWhiteSpace(p)) {
            //        project.Photos.Add(p);
            //    }
            //}

            //foreach (var v in options.Video) {
            //    if (string.IsNullOrWhiteSpace(v)) {
            //        project.Videos.Add(v);
            //    }
            //}
           

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
