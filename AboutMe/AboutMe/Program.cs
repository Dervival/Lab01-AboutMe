using System;

namespace AboutMe
{
    class Program
    {
        static void Main(string[] args)
        {
            int correct = 0;
            int incorrect = 0;
            Console.WriteLine("Here's a quick quiz about me!");
            if (SibNum(correct+incorrect))
            {
                correct++;
            }
            else
            {
                incorrect++;
            }
            Console.WriteLine("You got " + correct + " questions right and " + incorrect + " questions incorrect.");
            Console.ReadLine();
        }

        static bool SibNum(int questionNumber)
        {
            WriteQuestionNumber(questionNumber);
            Console.WriteLine("How many siblings do I have?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == 1);
        }

        static void WriteQuestionNumber(int questionNumber)
        {
            Console.WriteLine("Question #" + (questionNumber + 1) + ": ");
        }

        static int UserInt(string userInput)
        {
            int parsedInt = 0;
            try
            {
                parsedInt = Convert.ToInt32(parsedInt);
            }
            catch(FormatException)
            {
                Console.WriteLine("Format exception thrown - are you sure that string was convertable to an integer?");
            }
            catch(Exception e)
            {
                Console.WriteLine("Hit an unexpected exception:");
                Console.WriteLine(e.Message);
            }
            return parsedInt;
        }
    }
}
