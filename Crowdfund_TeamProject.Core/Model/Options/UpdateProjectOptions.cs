using System;
using System.Collections.Generic;
using Crowdfund_TeamProject.Core.Model;

namespace Crowdfund_TeamProject.Core.Model.Options
{
   public class UpdateProjectOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> Video { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Goal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExplirationDate { get; set; }

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
        public UpdatePost UpdatePost { get; set; }

    }
}
