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
            updateCounters(SibNum());
            updateCounters(BirthMonth());
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

        //static bool GenericQuestion(int questionNumber)
        //{
        //    //type correctVal = (correct answer for this question)
        //    //WriteQuestionNumber(questionNumber)
        //    //Console.WriteLine((Question body here))
        //    //string userInput = Console.ReadLine();
        //    //only if answer should be int: int parsedInput = UserInt(userInput);
        //    //return (parsedInput == correctVal);
        //}

        static bool SibNum()
        {
            int correctVal = 1;
            WriteQuestionNumber();
            Console.WriteLine("How many siblings do I have?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == correctVal);
        }

        static bool BirthMonth()
        {
            string correctVal = "March";
            WriteQuestionNumber();
            Console.WriteLine("What month was I born in?");
            string userInput = Console.ReadLine();
            //int parsedInput = UserInt(userInput);
            return (NormalizeString(userInput) == NormalizeString(correctVal));
        }

        static void WriteQuestionNumber()
        {
            Console.WriteLine("Question #" + (correct + incorrect + 1) + ": ");
        }

        static string NormalizeString(string userInput)
        {
            return userInput.Trim().ToLower();
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
