using System;
using System.Collections.Generic;

namespace Aufgabe5
{
    class Program
    {
        static string reversedWordsAndLettersSentence;
        static string reversedWordsSentence;
        static string reversedLettersSentence;

        static void Main(string[] args)
        {
            reversedWordsAndLettersSentence = reverseSentenceAndLetters(args[0]);
            reversedWordsSentence = reverseSentenceWordOrder(args[0]);
            reversedLettersSentence = reverseLetterOrderOfWords(args[0]);

            Console.WriteLine("Original: " + args[0]);
            Console.WriteLine("Reversed Wordsorder and Letterorder: " + reversedWordsAndLettersSentence);
            Console.WriteLine("Reversed Wordorder: " + reversedWordsSentence);
            Console.WriteLine("Reversed Letters: " + reversedLettersSentence);


        }

        #region Umgekehrte Wort und Buchstabenreihenfolge
        static string reverseSentenceAndLetters(string sentenceAndLettersToReverse)
        {
            char[] cache = sentenceAndLettersToReverse.ToCharArray();
            Array.Reverse(cache);
            return new string(cache);
        }
        #endregion

        #region Umgekehrte Wortreihenfolge
        static string reverseSentenceWordOrder(string sentenceToReverse)
        {
            string[] cache = splitSentenceIntoWords(sentenceToReverse);
            Array.Reverse(cache);

            return remakeWordArrayAsSentence(cache);
        }

        static string[] splitSentenceIntoWords(string stringToSplit)
        {
            string[] wordArray = stringToSplit.Split(null);

            return wordArray;
        }

        static string remakeWordArrayAsSentence(string[] wordArray)
        {
            return string.Join(" ", wordArray);
        }
        #endregion

        #region Umgekehrte Buchstabenreihenfolge
        static string reverseLetterOrderOfWords(string sentenceWhoseLettersToReverse)
        {
            List<string> cache = new List<string>();
            foreach (string word in splitSentenceIntoWords(sentenceWhoseLettersToReverse))
                cache.Add(reverseWord(word));   

            string[] sentenceHolder = cache.ToArray();
            string because = remakeWordArrayAsSentence(sentenceHolder);
            return because;
        }

        static string reverseWord(string word)
        {
            char[] cache = word.ToCharArray();
            Array.Reverse(cache);

            return new string(cache);
        }
        #endregion

    }
}
