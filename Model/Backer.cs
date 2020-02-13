using System;
using System.Collections.Generic;
using System.Text;

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
        ICollection<Project> FundedProject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FundAmount { get; set; }

        public Backer()
        {
            FundedProject = new List<Project>();
        }
    }
}
