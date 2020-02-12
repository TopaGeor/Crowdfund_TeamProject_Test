using System;
using System.Collections.Generic;

namespace Crowdfund.Core.Model
{
    public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id;

        /// <summary>
        /// 
        /// </summary>
        public decimal Goal;

        /// <summary>
        /// 
        /// </summary>
        public string Title;

        /// <summary>
        /// 
        /// </summary>
        public string Description;

        /// <summary>
        /// 
        /// </summary>
        public User Creator;

        /// <summary>
        /// 
        /// </summary>
        public ProjectStatus Status;

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Tier> Tiers;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Photos;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Videos;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Updates;

        public Project()
        {
            Tiers = new List<Tier>();
            Photos = new List<String>();
            Videos = new List<String>();
            Updates = new List<String>();
        }
    }
}
