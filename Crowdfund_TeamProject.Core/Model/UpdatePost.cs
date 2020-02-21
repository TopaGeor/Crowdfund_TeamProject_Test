using System;
using System.Collections.Generic;
using System.Text;
using Crowdfund.Core.Model;

namespace Crowdfund_TeamProject.Core.Model
{
   public  class UpdatePost
    {
        public int Id { get; set; }

        public string Post { get; set; }

        public DateTimeOffset DatePost { get; set; }

        public Project Project { get; set; }
    }
}
