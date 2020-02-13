using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model.Options
{
    class AddProjectOptions
    {
        public int Id;
        public string Description { get;  set; }

        public decimal Goal { get; set; }

        public string Title { get; set; }

        public Creator Creator { get; set; }

        public ProjectCategory Category { get; set; }


        public ICollection<string> Photo { get; set; }

        public ICollection<string>  Video { get; set; }





    }
}
