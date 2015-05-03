namespace TeamworkProject.Models.Items
{
    using System;

    [Serializable]
    public abstract class GameObject
    {
        private string name;

        protected GameObject(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Object id cannot be null or empty.");
                }

                if (value.Contains(" "))
                {
                    throw new ArgumentException("Id cannot contain empty spaces.");
                }

                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("Id length must be in range 3 to 15 symbols.");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\n", this.Id);
        }
    }
}