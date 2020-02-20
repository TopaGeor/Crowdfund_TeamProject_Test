using Crowdfund_TeamProject.Model;
using System.Collections.Generic;

namespace Crowdfund.Core.Model
{
    public  class Backer
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Project> FundedProject { get; set; }

        public Backer()
        {
            FundedProject = new List<Project>();
        }
    }
}
