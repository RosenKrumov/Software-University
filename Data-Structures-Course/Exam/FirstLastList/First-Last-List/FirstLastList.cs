using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private readonly OrderedDictionary<int, T> elements = 
        new OrderedDictionary<int, T>(); 
    private readonly OrderedDictionary<T, List<int>> indexes = 
        new OrderedDictionary<T, List<int>>(); 
    private readonly OrderedBag<T> sortedElements = 
        new OrderedBag<T>(); 
    private readonly OrderedBag<T> sortedElementsReversed = 
        new OrderedBag<T>((p1, p2) => -p1.CompareTo(p2));

    private int id = 1;

    public void Add(T newElement)
    {
        this.elements.Add(id, newElement);

        if (!this.indexes.ContainsKey(newElement))
        {
            this.indexes[newElement] = new List<int>();
        }

        this.indexes[newElement].Add(id);
        this.sortedElements.Add(newElement);
        this.sortedElementsReversed.Add(newElement);
        this.id++;
    }

    public int Count
    {
        get { return this.elements.Count; }
    }

    public IEnumerable<T> First(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var counter = 1;

        foreach (var pair in this.elements)
        {
            if (counter > count)
            {
                break;
            }

            yield return pair.Value;
            counter++;
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        var counter = 1;
        
        foreach (var pair in this.elements.Reversed())
        {
            if (counter > count)
            {
                break;
            }

            yield return pair.Value;
            counter++;
        }
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.sortedElements.Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.elements.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.sortedElementsReversed.Take(count);
    }

    public int RemoveAll(T element)
    {
        if (this.indexes.ContainsKey(element))
        {
            var indexesToRemove = this.indexes[element];
            this.elements.RemoveMany(indexesToRemove);
        }
        
        this.indexes.Remove(element);
        
        this.sortedElementsReversed.RemoveAllCopies(element);
        return this.sortedElements.RemoveAllCopies(element);
    }

    public void Clear()
    {
        this.indexes.Clear();
        this.elements.Clear();
        this.sortedElements.Clear();
        this.sortedElementsReversed.Clear();
        this.id = 1;
    }
}
