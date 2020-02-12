namespace Crowdfund.Core.Model.Options
{
    class AddProjectOptions
    {
        public int Id { get; set; }

        public string Description { get;  set; }

        public decimal Goal { get; set; }

        public string Title { get; set; }

        public User Creator { get; set; }
        
        public ProjectCategory Category { get; set; }

        public ProjectStatus Status { get; set; }

        public string Photo { get; set; }

        public string Video { get; set; }

        public string Update { get; set; }
    }
}
