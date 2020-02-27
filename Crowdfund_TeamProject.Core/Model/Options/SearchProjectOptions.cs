namespace Crowdfund_TeamProject.Core.Model.Options
{
    public class SearchProjectOptions
    {
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
        public string ExplirationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ProjectCategory Category { get; set; }
    }
}
