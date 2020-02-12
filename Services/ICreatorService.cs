using System;
using System.Collections.Generic;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
   public interface ICreatorService
    {
     bool AddCreator(AddCreatorOptions options);

     bool UpdateCreator(int id, UpdateCreatorOptions options);

     ICollection<Creator> SearchCreator(SearchCreatorOptions options);

    }
}
