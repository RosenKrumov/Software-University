namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private readonly IDictionary<string, Person> peopleByEmail = 
            new Dictionary<string, Person>();
        
        private readonly IDictionary<string, SortedSet<Person>> peopleByDomain = 
            new Dictionary<string, SortedSet<Person>>(); 
        
        private readonly IDictionary<string, SortedSet<Person>> peopleByNameAndTown = 
            new Dictionary<string, SortedSet<Person>>();
        
        private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAge = 
            new OrderedDictionary<int, SortedSet<Person>>();
        
        private readonly IDictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByAgeAndTown = 
            new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>(); 

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.FindPerson(email) != null)
            {
                return false;
            }

            var person = new Person()
            {
                Age = age,
                Email = email,
                Name = name,
                Town = town
            };

            this.peopleByEmail.Add(email, person);

            var emailDomain = this.ExtractEmailDomain(email);
            this.peopleByDomain.AppendValueToKey(emailDomain, person);

            var nameAndTown = this.CombineNameAndTown(name, town);
            this.peopleByNameAndTown.AppendValueToKey(nameAndTown, person);

            this.peopleByAge.AppendValueToKey(age, person);

            this.peopleByAgeAndTown.EnsureKeyExists(town);
            this.peopleByAgeAndTown[town].AppendValueToKey(age, person);

            return true;
        }

        public int Count
        {
            get { return this.peopleByEmail.Count; }
        }

        public Person FindPerson(string email)
        {
            Person person;
            this.peopleByEmail.TryGetValue(email, out person);
            return person;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            this.peopleByEmail.Remove(email);

            var emailDomain = this.ExtractEmailDomain(email);
            this.peopleByDomain[emailDomain].Remove(person);

            var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
            this.peopleByNameAndTown[nameAndTown].Remove(person);

            this.peopleByAge[person.Age].Remove(person);

            this.peopleByAgeAndTown[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            return this.peopleByDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            var nameAndTown = this.CombineNameAndTown(name, town);
            return this.peopleByNameAndTown.GetValuesForKey(nameAndTown);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            var peopleInAgeRange = this.peopleByAge.Range(startAge, true, endAge, true);

            foreach (var peopleByAgeCollection in peopleInAgeRange)
            {
                foreach (var person in peopleByAgeCollection.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            if (!this.peopleByAgeAndTown.ContainsKey(town))
            {
                yield break;
            }

            var peopleInRange = this.peopleByAgeAndTown[town].Range(startAge, true, endAge, true);

            foreach (var peopleByAgeCollection in peopleInRange)
            {
                foreach (var person in peopleByAgeCollection.Value)
                {
                    yield return person;
                }
            }
        }

        private string ExtractEmailDomain(string email)
        {
            var domain = email.Split('@')[1];
            return domain;
        }

        private string CombineNameAndTown(string name, string town)
        {
            const string separator = "|!|";
            return name + separator + town;
        }
    }
}
