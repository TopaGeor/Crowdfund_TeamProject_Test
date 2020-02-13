using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model
{
   public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Goal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Creator Creator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Backer> Backers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Tier> Tiers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Photos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Videos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<String> Updates { get; set; }

        public Project()
        {
            Tiers = new List<Tier>();
            Photos = new List<String>();
            Videos = new List<String>();
            Updates = new List<String>();
            Backers = new List<Backer>();
        }

    }
}
