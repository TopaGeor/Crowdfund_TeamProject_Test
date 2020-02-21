using Crowdfund_TeamProject.Core.Model;
using Crowdfund_TeamProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Backer Backer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExplirationDate { get; set; }

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
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<UpdatePost> UpdatePost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Project()
        {
            Tiers = new List<Tier>();
            UpdatePost = new List<UpdatePost>();
        }

    }
}
