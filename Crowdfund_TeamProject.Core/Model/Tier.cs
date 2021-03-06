﻿using System.Text.Json.Serialization;

namespace Crowdfund_TeamProject.Core.Model
{
    public class Tier
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
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
