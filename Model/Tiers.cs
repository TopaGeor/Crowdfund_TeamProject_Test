﻿namespace Crowdfund.Core.Model
{
    public class Tiers
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public int TotalTiers;
        //I do not see a value to that

        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}
