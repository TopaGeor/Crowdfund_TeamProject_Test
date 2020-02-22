using System;

namespace Crowdfund_TeamProject.Core.Model.Options
{
    public class SearchProjectOptions
    {

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Creator Creator { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ExplirationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category { get; set; }
    }
}
