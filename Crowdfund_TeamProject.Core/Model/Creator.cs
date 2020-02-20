using System.Collections.Generic;

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

        ICollection<Project> CreatedProject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Creator()
        {
            CreatedProject = new List<Project>();
        }
    }
}
