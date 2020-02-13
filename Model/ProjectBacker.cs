using Crowdfund.Core.Model;

namespace Crowdfund_TeamProject.Model
{
    public class ProjectBacker
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int BackerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Backer Backer { get; set; }
    }
}
