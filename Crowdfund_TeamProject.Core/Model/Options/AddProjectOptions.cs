﻿using System;
using System.Collections.Generic;

namespace Crowdfund.Core.Model.Options
{
   public class AddProjectOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string Description { get;  set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Goal { get; set; }

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
        public ProjectCategory Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<int> TiersId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ExplirationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string>  Video { get; set; }
    }
}