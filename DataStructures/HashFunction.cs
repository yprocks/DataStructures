using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class HashFunction
    {
        WordList[] theArray;
        int arraySize;

        public String[,] elementsToAdd = {
            { "ace", "Very good" },
            { "act", "Take action" },
            { "add", "Join (something) to something else" },
            { "age", "Grow old" },
            { "ago", "Before the present" },
            { "aid", "Help, assist, or support" },
            { "aim", "Point or direct" },
            { "air", "Invisible gaseous substance" },
            { "all", "Used to refer to the whole quantity" },
            { "amp", "Unit of measure for the strength of an electrical current" },
            { "and", "Used to connect words" }, { "ant", "A small insect" },
            { "any", "Used to refer to one or some of a thing" },
            { "ape", "A large primate" },
            { "apt", "Appropriate or suitable in the circumstances" },
            { "arc", "A part of the circumference of a curve" },
            { "are", "Unit of measure, equal to 100 square meters" },
            { "ark", "The ship built by Noah" },
            { "arm", "Two upper limbs of the human body" },
            { "art", "Expression or application of human creative skill" },
            { "ash", "Powdery residue left after the burning" },
            { "ask", "Say something in order to obtain information" },
            { "asp", "Small southern European viper" },
            { "ass", "Hoofed mammal" },
            { "ate", "To put (food) into the mouth and swallow it" },
            { "atm", "Unit of pressure" },
            { "awe", "A feeling of reverential respect" },
            { "axe", "Edge tool with a heavy bladed head" },
            { "aye", "An affirmative answer" },
            { "bye", "An affirmative answer" },
            { "zye", "An affirmative answer" }};


        public HashFunction(int size)
        {
            arraySize = size;
            theArray = new WordList[size];

            for (int i = 0; i < size; i++)
                theArray[i] = new WordList();

            addTheArray(elementsToAdd);
        }

        public int StringHashFunction(string wordToHash)
        {
            int hashkeyValue = 0;
            for (int i = 0; i < wordToHash.Length; i++)
            {
                int charCode = wordToHash[i] - 96;
                int temp = hashkeyValue;
                hashkeyValue = (hashkeyValue * 27 + charCode) % arraySize;
                Console.WriteLine("HashKeyValue " + temp + " * 27 + Character Code " +
                                  charCode + " % arraysize " + arraySize +
                                  " = " + hashkeyValue);
            }
            Console.WriteLine();
            return hashkeyValue;
        }


        public void addTheArray(String[,] elementsToAdd)
        {

            for (int i = 0; i < elementsToAdd.Length / 2; i++)
            {
                String word = elementsToAdd[i, 0];
                String definition = elementsToAdd[i, 1];
                // Create the Word with the word name and
                // definition
                Word newWord = new Word(word, definition);
                // Add the Word to theArray
                Insert(newWord);
            }
        }

        public void Insert(Word newWord)
        {
            String wordToHash = newWord.TheWord;

            // Calculate the hashkey for the Word

            int hashKey = StringHashFunction(wordToHash);

            // Add the new word to the array and set
            // the key for the word

            theArray[hashKey].Insert(newWord, hashKey);
        }

        public Word Find(string word)
        {
            int hashKey = StringHashFunction(word);
            Word theWord = theArray[hashKey].Find(hashKey, word);
            return theWord;
        }

        public void DisplayArray()
        {
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine("The Array Index " + i);
                theArray[i].Display();
            }
        }
    }

    class Word
    {
        public string TheWord { get; set; }
        public string Defination { get; set; }
        public int Key { get; set; }
        public Word Next { get; set; }

        public Word(string TheWord, string Defination)
        {
            this.Defination = Defination;
            this.TheWord = TheWord;
        }

        public override string ToString()
        {
            return TheWord + ": " + Defination;
        }
    }

    class WordList
    {
        public Word FirstWord { get; set; } = null;

        public void Insert(Word newWord, int HashKey)
        {
            Word previous = null;
            Word current = FirstWord;
            newWord.Key = HashKey;
            while (current != null && newWord.Key > current.Key)
            {
                previous = current;
                current = current.Next;
            }
            if (previous == null) FirstWord = newWord;
            else previous.Next = newWord;
            newWord.Next = current;
        }

        public void Display()
        {
            Word current = FirstWord;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Word Find(int HashKey, string word)
        {
            Word current = FirstWord;
            while (current != null && current.Key <= HashKey)
            {
                if (current.TheWord == word)
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}
