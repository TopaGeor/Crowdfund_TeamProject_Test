using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Core.Model.Options
{
    public class AddUpdatePostOptions
    {
        public string Post { get; set; }

        public DateTimeOffset DatePost { get; set; }

        public int ProjectId { get; set; }
    }
}
