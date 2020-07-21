using System;
using System.Text.RegularExpressions;

namespace pig_latin_minproject
{
    class Program
    {
        static void wordPlay(string word)
        {
            if (Regex.IsMatch(word, @"^[a-zA-Z /s]+$")) //only accept letters, no numbers, symbols
            {
                string stringBegin = word.Substring(0, 1);
                string stringBegin2 = word.Substring(0, 2);

                if (stringBegin == "a" || stringBegin == "e" || stringBegin == "i" || stringBegin == "o" || stringBegin == "u")
                //any word that begins with a vowel goes through here
                {
                    word = word + "way";
                    Console.Write($"{word} ");
                    return;                    
                }
                if (stringBegin2.Contains("ch") || stringBegin2.Contains("th") || stringBegin2.Contains("ph") || stringBegin2.Contains("sh") || stringBegin2.Contains("wh") || stringBegin2.Contains("my"))
                //any words that begin with a digraph flow through here
                {
                    word = word.Remove(0, 2);
                    word = word + stringBegin2 + "ay";
                    Console.Write($"{word} ");
                    return;
                }
                if (!stringBegin.Contains("a") || !stringBegin.Contains("e") || !stringBegin.Contains("i") || !stringBegin.Contains("o") || !stringBegin.Contains("u"))
                //any word with a consinant as the first letter (and not the second letter) go here
                {
                    word = word.Remove(0, 1);
                    word = word + stringBegin + "ay";
                    Console.Write($"{word} ");
                    return;

                }
            }
            else
            {
                Console.WriteLine("You may only enter letters, please try again");
                Console.WriteLine("");
                Main();
            }
        }
        static void Main()
        {
            Console.WriteLine("Would you like to convert a word or several words? (1/2)");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Console.WriteLine("Please enter your word");
                string word = Console.ReadLine().ToLower();
                wordPlay(word);
                Console.WriteLine("");
                doAgain();
            }
            else if (userChoice == "2")
            {
                Console.WriteLine("Please enter your sentence");
                string word = Console.ReadLine().ToLower();
                string[] words = word.Split(" ");

                foreach (string word1 in words)
                {
                    wordPlay(word1);                    
                }
                Console.WriteLine("");
                doAgain();
            }
            else
            {
                Console.WriteLine("Invalid input please try again");
                Main();
            }

        }
        static void doAgain()
        {

            Console.WriteLine("Would you like to continue? (y/n)");
            string doAgainChoice = Console.ReadLine();
            doAgainChoice.ToLower();

            if (doAgainChoice == "y")
            {
                Console.Clear();
                Main();
            }
            else if (doAgainChoice == "n")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing");
            }
            else
            {
                Console.WriteLine("This is not valid input please try again");
                doAgain();
            }            
        }
    }
}
