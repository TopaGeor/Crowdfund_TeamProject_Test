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
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProjectBacker> FundedProject { get; set; }

        public Backer()
        {
            FundedProject = new List<ProjectBacker>();
        }
    }
}
