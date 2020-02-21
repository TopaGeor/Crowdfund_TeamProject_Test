using System;

namespace Crowdfund.Core.Model.Options
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
        public string ExplirationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category { get; set; }
    }
}
