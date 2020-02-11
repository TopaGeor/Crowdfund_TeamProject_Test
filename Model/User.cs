using System;
using System.Collections.Generic;
using System.Text;

namespace Crowdfund.Core.Model
{
    public class User
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
        public ICollection<ProjectBacker> Backer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProjectFounder> Founder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User()
        {
            Backer = new List<ProjectBacker>();
            Founder = new List<ProjectFounder>();
        }

    }
}
