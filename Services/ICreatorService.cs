using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
   public interface ICreatorService
    {
     Creator AddCreator(AddCreatorOptions options);

     bool UpdateCreator(int id, UpdateCreatorOptions options);

        IQueryable<Creator> SearchCreator(SearchCreatorOptions options);

    }
}
