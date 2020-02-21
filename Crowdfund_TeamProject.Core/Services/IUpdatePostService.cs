﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Core.Model.Options;

namespace Crowdfund_TeamProject.Core.Services
{
   public  interface IUpdatePostService
    {
        Task<ApiResult<UpdatePost>> AddUpdatePostAsync(AddUpdatePostOptions options);

        Task<ApiResult<UpdatePost>> UpdatePostAsync(int postId, UpdatePostOptions options);

        IQueryable<UpdatePost> SearchUpdatePost(SearchUpdatePostOptions options);


    }
}
