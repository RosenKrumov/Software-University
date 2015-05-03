namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projects;

        public List<Project> Projects
        {
            get
            {
                return new List<Project>(this.projects);
            }
            set { this.projects = value; }
        }

        public Developer(int id, string firstName, string lastName, decimal salary, Department department, List<Project> projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public override string ToString()
        {
            string output = "Projects:\n";
            foreach (var project in this.Projects)
            {
                output += project.ToString();
                output += "\n";
            }
            return base.ToString() + output;
        }
    }
}
