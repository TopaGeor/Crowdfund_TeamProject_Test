namespace Crowdfund.Core.Model.Options
{
    public class SearchProjectOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

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
        public ProjectStatus Status { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category { get; set; }
    }
}
