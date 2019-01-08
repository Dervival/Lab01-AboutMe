using System;

namespace AboutMe
{
    class Program
    {
        public static int correct = 0;
        public static int incorrect = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Here's a quick quiz about me!");
            updateCounters(SibNum(correct + incorrect));
            Console.WriteLine("You got " + correct + " questions right and " + incorrect + " questions incorrect.");
            Console.ReadLine();
        }
        static void updateCounters(bool questionResult)
        {
            if (questionResult)
            {
                Console.WriteLine("That's correct!");
                correct++;
            }
            else
            {
                Console.WriteLine("That's incorrect, sorry.");
                incorrect++;
            }
        }

        static bool SibNum(int questionNumber)
        {
            int correctVal = 1;
            WriteQuestionNumber(questionNumber);
            Console.WriteLine("How many siblings do I have?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == correctVal);
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
                parsedInt = Convert.ToInt32(userInput);
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
