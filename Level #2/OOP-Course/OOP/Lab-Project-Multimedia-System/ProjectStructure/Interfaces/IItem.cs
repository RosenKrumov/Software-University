namespace ProjectStructure.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IItem
    {
        public string Id { get; }
        public string Title { get; }
        public decimal Price { get; }
        public List<string> Genres { get; }
    }
}
