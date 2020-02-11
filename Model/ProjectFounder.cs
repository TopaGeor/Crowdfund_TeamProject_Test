using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model
{
    public class ProjectFounder
    {
        /// <summary>
        /// 
        /// </summary>
        public int FounderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User Founder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Project Project {get; set;}
    }
}
