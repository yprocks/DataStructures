using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class Trie
    {
        private TrieNode Root;

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = Root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.Childern.ContainsKey(word[i]))
                {
                    TrieNode newNode = new TrieNode();
                    current.Childern.Add(word[i], newNode);
                }
                current = current.Childern[word[i]];
            }
            current.EndOfWord = true;
        }

        public bool SearchFullWord(string word)
        {
            return SearchRecursive(Root, word, 0);
        }

        private bool SearchRecursive(TrieNode current, string word, int index)
        {
            if (index == word.Length)
                return current.EndOfWord;

            foreach (var ch in current.Childern)
            {
                //Console.Write(ch.Key + " ");
                if (ch.Key == word[index])
                    return SearchRecursive(ch.Value, word, index + 1);
                //PrintNodes(ch.Value);
            }

            return false;
        }

        public bool SearchPartialWord(string word)
        {
            var current = Root;

            for (int i = 0; i < word.Length; i++)
            {
                TrieNode node = null;
                current.Childern.TryGetValue(word[i], out node);
                if (node == null)
                    return false;
                current = node;
            }

            return true;
        }

        public void Delete(string word)
        {
            Delete(Root, word, 0);
        }

        private bool Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.EndOfWord)
                    return false;
                current.EndOfWord = false;

                return current.Childern.Count == 0;
            }

            TrieNode node = null;
            current.Childern.TryGetValue(word[index], out node);
            if (node == null)
                return false;

            bool shouldRemoveNode = Delete(node, word, index + 1);

            if (shouldRemoveNode)
            {
                current.Childern.Remove(word[index]);
                return current.Childern.Count == 0;
            }

            return false;
        }

        //public void Print()
        //{
        //    PrintNodes(Root);
        //}

        private void PrintNodes(TrieNode current)
        {
            var item = current.Childern;
            foreach (var ch in item)
            {
                Console.Write(ch.Key + " ");
                PrintNodes(ch.Value);
            }
            if (current.EndOfWord)
                Console.WriteLine();


        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Childern { get; set; }
            public bool EndOfWord { get; set; }

            public TrieNode()
            {
                Childern = new Dictionary<char, TrieNode>();
                EndOfWord = false;

            }
        }
    }


}
