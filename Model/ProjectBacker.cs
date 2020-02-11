using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model
{
    public class ProjectBacker
    {    
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId;

        /// <summary>
        /// 
        /// </summary>
        public Project Project;

        /// <summary>
        /// 
        /// </summary>
        public int BackerId;

        /// <summary>
        /// 
        /// </summary>
        public User User;

        /// <summary>
        /// 
        /// </summary>
        public decimal FundAmount;
    }
}
