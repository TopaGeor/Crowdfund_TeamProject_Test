using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Core.Model
{
   public  class UpdatePost
    {
        public int Id { get; set; }

        public string Post { get; set; }

        public DateTimeOffset DatePost { get; set; }
    }
}
