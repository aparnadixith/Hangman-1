// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class HangmanGame
{
    static void Main(string[] args)
    {
        string[] words = { "rose", "lilly", "cat", "boat", "kiwi" };
        Random random = new Random();
        string wordToGuess = words[random.Next(words.Length)];
        char[] guessedWord = new char[wordToGuess.Length];
        bool[] letterGuessed = new bool[26];
        int attemptsLeft = 6;
        bool wordGuessed = false;

        Console.WriteLine("Welcome to Hangman!");

       
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedWord[i] = '_';
        }

        while (!wordGuessed && attemptsLeft > 0)
        {
            Console.WriteLine("Attempts left: " + attemptsLeft);
            Console.WriteLine("Current word: " + string.Join(" ", guessedWord));

            Console.Write("Enter a letter to guess: ");
            char letter = Console.ReadLine().ToLower()[0];

            
            if (letterGuessed[letter - 'a'])
            {
                Console.WriteLine("You've already guessed this letter.");
                continue;
            }

            letterGuessed[letter - 'a'] = true;

            
            bool correctGuess = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter)
                {
                    guessedWord[i] = letter;
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                attemptsLeft--;
                Console.WriteLine("Incorrect guess!");
            }

            if (string.Join("", guessedWord) == wordToGuess)
            {
                wordGuessed = true;
            }
        }

        if (wordGuessed)
        {
            Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("Sorry, you ran out of attempts. The word was: " + wordToGuess);
        }
    }
}