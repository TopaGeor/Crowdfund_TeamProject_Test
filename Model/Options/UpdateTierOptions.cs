using Crowdfund.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund_TeamProject.Model.Options
{
    public class UpdateTierOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id;

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
