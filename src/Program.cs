using System;
using System.Text;

namespace FunctionChallenges
{
    class Program
    {
        static void StringNumberProcessor(params dynamic[] inputs)
        {
            try
            {
                if (inputs.Length == 0) throw new Exception("Invalid Input. Zero inputs found.");

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SwapObjects(object r1, object r2)
        {
            try
            {
                if (r1?.GetType() != r2?.GetType()) throw new Exception("Error: Objects must be of same types");

                if (r1 is not string and not int) throw new Exception("Error: Unsupported data type");

                switch (r1)
                {
                    case int:

                        int n1 = Convert.ToInt32(r1);
                        int n2 = Convert.ToInt32(r2);

                        if (n1 <= 18 || n2 <= 18) throw new Exception("Error: Value must be more than 18");

                        object temp = r1;
                        r1 = r2;
                        r2 = temp;

                        break;

                    case string:

                        string s1 = Convert.ToString(r1) ?? "";
                        string s2 = Convert.ToString(r2) ?? "";

                        if (s1.Length <= 5 || s2.Length <= 5) throw new Exception("Error: Length must be more than 5");

                        temp = r1;
                        r1 = r2;
                        r2 = temp;

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SwapObjects<T>(ref T r1, ref T r2)
        {
            try
            {

                if (r1?.GetType() != r2?.GetType()) throw new Exception("Error: Objects must be of same types");

                if (r1 is not string and not int) throw new Exception("Error: Unsupported data type");

                switch (r1)
                {
                    case int:

                        int n1 = Convert.ToInt32(r1);
                        int n2 = Convert.ToInt32(r2);

                        if (n1 <= 18 || n2 <= 18) throw new Exception("Error: Value must be more than 18");

                        T temp = r1;
                        r1 = r2;
                        r2 = temp;

                        break;

                    case string:

                        string s1 = Convert.ToString(r1) ?? "";
                        string s2 = Convert.ToString(r2) ?? "";

                        if (s1.Length <= 5 || s2.Length <= 5) throw new Exception("Error: Length must be more than 5");

                        temp = r1;
                        r1 = r2;
                        r2 = temp;

                        break;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        static string ReverseWords(string sentence)
        {
            try
            {
                if (string.IsNullOrEmpty(sentence)) throw new Exception("Invalid Input. no sentence was provided");

                string[] words = sentence.Split(" ");
                StringBuilder reversed = new StringBuilder();

                foreach (string word in words)
                {
                    char[] cArray = word.ToCharArray();
                    Array.Reverse(cArray);
                    reversed.Append(cArray);
                    reversed.Append(' ');
                }

                return reversed.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sentence;
        }

        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";

            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(str1, str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(str3, str4); // Error: Length must be more than 5

            SwapObjects(true, false); // Error: Unsupported data type
            SwapObjects(num1, str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"

        }
    }
}
