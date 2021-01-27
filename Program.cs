using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace humanaCodingAssessment
{
    //Property and encapsulation to protect sensitive data
    class Input
    {
        private string _paragraph;
        public Input(string a)
        {
            _paragraph = a;
        }
        public string Paragraph
        {
            get => _paragraph;
            set => _paragraph = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                  
            Input paraInput = new Input("Murder for a jar of red rum. " +
                    "I like jam. You are cool. Was it a car or a cat I saw. " +
                    "Go hang a salami, I'm a lasagna hog. It Kayak. Do geese see God? Was it a car or a cat I saw?");
            
            Console.WriteLine("Example paragraph: \n" + paraInput.Paragraph);           
            Console.WriteLine("Palindrome words: " + numPalWords(paraInput.Paragraph));
            Console.WriteLine("Palindrome sentences: " + numPalSentences(paraInput.Paragraph));            
            Console.WriteLine("Unique words: ");
            uniqueList(paraInput.Paragraph, splitWords(paraInput.Paragraph));
            Console.WriteLine("\n");
            Console.WriteLine("Input a letter and I'll find all the words that contain that letter: ");           
            string input = Console.ReadLine();
            inputValidator(input, paraInput.Paragraph);
             
        }

        
        //Input validating function
        public static void inputValidator(string input, string paragraph)
        {
            Regex r = new Regex("^[a-zA-Z]$");
            Match m = r.Match(input);
            bool correct = false;
            while (!correct)
            {
                m = r.Match(input);
                if (m.Success)
                {
                    letterInputCounter(input, splitWords(paragraph));
                    correct = true;
                    break;
                }
                Console.WriteLine("Invalid input. Input only one letter.");
                input = Console.ReadLine();
            }
        }

        //Function to determine if a string is a palindrome or not
        public static bool isPalindrome(string a)
        {
            char[] newArray = a.ToCharArray();
            Array.Reverse(newArray);
            string reverseArray = new string(newArray);
            if (a == reverseArray) return true;
            else return false;
        }
        //Function that splits the paragraph by the spaces and places them into a string array to be checked if the word is a 
        //palindrome or not
        public static int numPalWords(string a)
        {

            int counter = 0; 
            string[] splitWords = a.Split(' ');
            for (int i = 0; i < splitWords.Length; i++)
            {

                if (isPalindrome(splitWords[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
        //regular expression used here to only lower case letters(not periods/commas/etc), splitting up the paragraph by sentance which is usually marked with a period
        // Then placing each of those sentances into a string array and checking those with the isPalindrome function I created before.
        public static int numPalSentences(string a)
        {
            a = a.ToLower();
            int counter = 0;
            Regex regex = new Regex("[^a-z]");
            string[] splitSentence = a.Split('.');
            for (int i = 0; i < splitSentence.Length; i++)
            {
                splitSentence[i] = splitSentence[i].Replace(" ", String.Empty);
                splitSentence[i] = regex.Replace(splitSentence[i], "");
                if (isPalindrome(splitSentence[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
        //nice little function to take the paragraph and split it up by spaces, creating an array of the words in the paragraph.
        public static string[] splitWords(string a)
        {
            a = a.ToLower();
            
            String[] splitString = a.Split(' ');
            return splitString;
        }
        //function that creates a new list with only the unique words and displays them, using the List methods such as Contains and Adds to easily search the list
        //for the particular word. If the list doesn't have the word then the word is added to the end of the list.
        public static void uniqueList(string a, string[] b)
        {
            Regex regex = new Regex("[^A-Za-z]");
            List<string> uniqueWords = new List<string>();
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = regex.Replace(b[i], "");
            }
            foreach (string i in b)
            {
                if (!uniqueWords.Contains(i))
                {
                    uniqueWords.Add(i);
                }

            }

            foreach (string j in uniqueWords)
            {
                Console.Write("(" + j + ", " + wordCounter(j, b) + ")");
            }
            


        }
        //function used in other functions to count words
        public static int wordCounter(string a, string[] b)
        {
            int counter = 0;
            foreach (string c in b)
            {
                if (c == a)
                {
                    counter++;
                }

            }
            return counter;
        }
        //Taking the letter given by the user and the split words function we turn each word in the string array into a char array and check each
        //of those letters in the char array. If we find a letter that matches the users input then we write that to the console and break so that we dont
        //display the same word multiple times if it contains multiple iterations of the letter
        public static void letterInputCounter(string b, string[] a)
        {
            int counter = 0;
            char d = Convert.ToChar(b);
            char[] charArr = new char[a.Length];
            Regex regex = new Regex("[^A-Za-z]");
            
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = regex.Replace(a[i], "");
            }

            for (int i = 0; i < a.Length; i++)
            {
                charArr = a[i].ToCharArray();
                
                for (int j = 0; j < charArr.Length; j++)
                {                   
                    if(d == charArr[j])
                    {
                        Console.WriteLine(charArr);
                        counter++;
                        break;
                    }                  
                    
                }
                
                
            }
            if (counter == 0)
            {
                Console.WriteLine("There are no words in this paragraph that contain this letter.");
            }
        }
    }
}
/*
using vs code, write a c# solution to take in an input of a paragraph and:
give the number of palindrome words
give the number of palindrome sentences
list the unique words of a paragraph with the count of the word instance
let the user also input a letter at some point and list all words containing that letter 

write up a short documentation explaining what your program does.

upload the program to github or alternative git repository hosting service. once you have done so, send that link to me to forward to the managers for review.  please send your link no later than sunday evening.
*/
