namespace ProjectStructureSolutionAuthor.Interfaces
{
    using System;
    using System.Collections.Generic;

    interface IItem
    {
        string Id { get; }
        string Title { get; }
        decimal Price { get; }
        List<string> Genres { get; }
    }
}
