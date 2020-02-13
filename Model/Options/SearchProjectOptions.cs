using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model.Options
{
    class SearchProjectOptions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Creator Creator { get; set; }
        public ProjectStatus Status { get; set; }

        public ProjectCategory Category { get; set; }
    }
}
