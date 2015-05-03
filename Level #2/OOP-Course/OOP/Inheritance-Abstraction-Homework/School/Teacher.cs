namespace School
{
    using System;
    using System.Collections.Generic;

    class Teacher : People
    {
        private IList<Disciplines> disciplines;

        public IList<Disciplines> Disciplines
        {
            get
            {
                return new List<Disciplines>(this.disciplines);
            }

            private set
            {
                this.disciplines = value;
            }
        }

        public Teacher(string name, IList<Disciplines> disciplines, string details)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public Teacher(string name, IList<Disciplines> disciplines)
            : base(name)
        {
            this.Disciplines = disciplines;
        }
    }
}
