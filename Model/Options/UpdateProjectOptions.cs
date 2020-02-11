namespace Crowdfund.Core.Model.Options
{
    class UpdateProjectOptions
    {
        public string Photo { get; set; }

        public string Video { get; set; }

        public string Description { get; set; }

        public ProjectStatus Status { get; set; }

        public decimal Goal { get; set; }

        public string Update { get; set; }
    }
}
