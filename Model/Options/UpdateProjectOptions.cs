using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model.Options
{
    class UpdateProjectOptions
    {
        public ICollection<string> Photo { get; set; }

        public ICollection<string> Video { get; set; }
        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        public decimal Goal { get; set; }

        public string Update { get; set; }
        

    }
}
