using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model.Options
{
    class AddProjectOptions
    {
        public int Id;
        public string Description { get;  set; }

        public decimal Goal;

        public string Title;

        public User Creator;

        public ProjectCategory Category;

        public ProjectStatus Status;

        public string Photo;

        public string Video;

        public string Update;



    }
}
