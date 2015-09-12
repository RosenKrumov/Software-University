namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BiDictionary<K1, K2, T>
    {
        private readonly IDictionary<K1, List<T>> valuesByFirstKey;
        private readonly IDictionary<K2, List<T>> valuesBySecondKey;
        private readonly IDictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            var compositeKey = Tuple.Create(firstKey, secondKey);

            if (!this.valuesByFirstKey.ContainsKey(firstKey))
            {
                this.valuesByFirstKey[firstKey] = new List<T>();
            }

            if (!this.valuesBySecondKey.ContainsKey(secondKey))
            {
                this.valuesBySecondKey[secondKey] = new List<T>();
            }

            if (!this.valuesByBothKeys.ContainsKey(compositeKey))
            {
                this.valuesByBothKeys[compositeKey] = new List<T>();
            }

            this.valuesByFirstKey[firstKey].Add(value);
            this.valuesBySecondKey[secondKey].Add(value);
            this.valuesByBothKeys[compositeKey].Add(value);
        }

        public IEnumerable<T> FindByCompositeKey(K1 firstKey, K2 secondKey)
        {
            if (this.valuesByBothKeys.ContainsKey(Tuple.Create(firstKey, secondKey)))
            {
                return this.valuesByBothKeys[Tuple.Create(firstKey, secondKey)];
            }
            return Enumerable.Empty<T>();
        }

        public IEnumerable<T> FindByFirstKey(K1 firstKey)
        {
            return this.valuesByFirstKey[firstKey];
        }

        public IEnumerable<T> FindBySecondKey(K2 secondKey)
        {
            return this.valuesBySecondKey[secondKey];
        }

        public bool Remove(K1 firstKey, K2 secondKey)
        {
            return this.valuesByBothKeys.Remove(Tuple.Create(firstKey, secondKey));
        }
    }
}
