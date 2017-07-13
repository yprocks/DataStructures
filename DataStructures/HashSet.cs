using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    public class Set
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Set(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }

    public class HashSet
    {
        public Set[] set;
        public int size;

        public HashSet(int? size)
        {
            this.size = size == null ? int.MaxValue : (int)size;
            set = new Set[this.size];
        }

        public bool HasKey(string Key)
        {
            if (IsSetEmpty())
                return false;

            foreach (var s in set)
            {
                if (s == null)
                    break;

                if (s.Key == Key)
                    return true;
            }

            return false;
        }

        private bool IsSetEmpty()
        {
            foreach (var s in set)
                if (s != null)
                    return false;

            return true;
        }

        public string GetValue(string Key)
        {
            if (IsSetEmpty())
                return null;

            foreach (var s in set)
            {
                if (s == null)
                    break;

                if (s.Key == Key)
                    return s.Value;
            }
            return null;
        }

        public string GetKey(string Value)
        {
            if (IsSetEmpty())
                return null;

            foreach (var s in set)
            {
                if (s == null)
                    break;

                if (s.Value == Value)
                    return s.Key;
            }
            return null;
        }

        public void Add(string Key, string Value)
        {

            if (HasKey(Key))
                return;

            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] == null)
                {
                    set[i] = new Set(Key, Value);
                    break;
                }
            }
        }

        public void Remove(string Key)
        {
            if (IsSetEmpty())
                return;

            bool remove = false;
            for (int i = 0; i < set.Length; i++)
            {
                if (set[i].Key == Key)
                {
                    set[i] = null;
                    remove = true;
                }

                if (remove && set[i + 1] == null)
                {
                    set[i] = null;
                    break;
                }
                if (remove && set[i + 1] != null)
                    set[i] = set[i + 1];

            }
        }

        public void PrintSet()
        {
            if (IsSetEmpty())
                return;

            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] == null)
                    break;

                Console.WriteLine("Key : " + set[i].Key + " <==> Value : " + set[i].Value);
            }
        }
    }
}
