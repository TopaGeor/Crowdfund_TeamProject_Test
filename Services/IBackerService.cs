using System;
using System.Collections.Generic;
using System.Text;
using Crowdfund.Core.Model;
using Crowdfund.Core.Model.Options;

namespace Crowdfund.Core.Services
{
  public  interface IBackerService
    {
        bool AddBacker(AddBackerOptions options);

        bool UpdateBacker(int id, UpdateBackerOptions options);

        ICollection<Backer> SearchBacker(SearchBackerOptions options);

        //ICollection<Project> SelectProject(int projectid);

       
    }
}
