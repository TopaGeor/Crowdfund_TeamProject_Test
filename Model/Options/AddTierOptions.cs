using Crowdfund.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Model.Options
{
    public class AddTierOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Ammount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}
