using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model
{
  public  class Creator 
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

        ICollection<Project> CreatedProject { get; set; }


        public Creator()
        {
            CreatedProject = new List<Project>();
        }

    }
}
