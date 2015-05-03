namespace CompanyHierarchy
{
    using System;
    using Interfaces;

    class Project : IProject
    {
        private string name;
        private string startDate;
        private string details;
        private ProjectState state;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name must not be empty");
                }
                this.name = value;
            }
        }

        public string StartDate
        {
            get { return this.startDate; }
            private set { this.startDate = value; }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Details must not be empty.");
                }
                this.details = value;
            }
        }

        public ProjectState State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Project(string name, string startDate, string details, ProjectState state)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }

        public void CloseProject()
        {
            if (this.State == ProjectState.Closed)
            {
                throw new ArgumentException("Project is already closed.");
            }
            this.State = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format("Project name: {0}\nProject start date: {1}\nProject details: {2}\nProject state: {3}\n",
                this.Name, this.StartDate, this.Details, this.State);
        }
    }
}
