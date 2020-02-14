using System.Collections.Generic;

namespace Crowdfund.Core.Model.Options
{
    class UpdateProjectOptions
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
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Goal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Update { get; set; }
    }
}
