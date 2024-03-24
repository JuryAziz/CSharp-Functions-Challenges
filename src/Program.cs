using System;

namespace FunctionChallenges
{
    class Program
    {
        static void StringNumberProcessor(params dynamic[] inputs)
        {
            if (inputs.Length == 0) throw new ArgumentException("Invalid Input. Zero inputs found.");

            string text = "";
            int total = 0;

            foreach (var input in inputs)
            {
                switch (input)
                {
                    case string:
                        text += input + " ";
                        break;
                    case int:
                        total += input;
                        break;
                }
            }

            Console.WriteLine($"Result: {text.Trim()}; {total}");
        }

        static void GuessingGame()
        {
            int number = new Random().Next(1, 51);
            bool won = false;
            do
            {
                try
                {
                    Console.WriteLine("Guess a number, or enter 'Quit' to exit the game: ");
                    string input = Console.ReadLine() ?? "";

                    if (input.ToUpper().Equals("QUIT"))
                    {
                        Console.WriteLine("Hope you enjoyed the game! BYE.");
                        break;
                    }

                    if (input == "" || !input.All(char.IsNumber)) throw new Exception("Invalid Input. Please enter a number or enter 'Quit' to exit the game");

                    int guess = Convert.ToInt32(input);

                    switch (guess)
                    {
                        case int f when guess == number:
                            won = true;
                            Console.WriteLine("Your guess is correct!");
                            break;
                        case int f when guess > number:
                            Console.WriteLine("Your guess is high, try a smaller number");
                            break;
                        case int f when guess < number:
                            Console.WriteLine("Your guess is low, try a bigger number");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (!won);

        }


        static void Main(string[] args)
        {
            try
            {
                // Challenge 1: String and Number Processor
                Console.WriteLine("Challenge 1: String and Number Processor");
                StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

                // Challenge 2: Object Swapper
                // Console.WriteLine("\nChallenge 2: Object Swapper");
                // int num1 = 25, num2 = 30;
                // int num3 = 10, num4 = 30;
                // string str1 = "HelloWorld", str2 = "Programming";
                // string str3 = "Hi", str4 = "Programming";

                // SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25
                // SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

                // SwapObjects(str1, str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
                // SwapObjects(str3, str4); // Error: Length must be more than 5

                // SwapObjects(true, false); // Error: Unsupported data type
                // SwapObjects(ref num1, str1); // Error: Objects must be of same types

                // Console.WriteLine($"Numbers: {num1}, {num2}");
                // Console.WriteLine($"Strings: {str1}, {str2}");

                // Challenge 3: Guessing Game
                Console.WriteLine("\nChallenge 3: Guessing Game");
                // Uncomment to test the GuessingGame method
                GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

                // Challenge 4: Simple Word Reversal
                // Console.WriteLine("\nChallenge 4: Simple Word Reversal");
                // string sentence = "This is the original sentence!";
                // string reversed = ReverseWords(sentence);
                // Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
