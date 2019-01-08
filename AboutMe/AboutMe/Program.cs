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
            updateCounters(BirthState());
            updateCounters(CurrentAge());
            updateCounters(QuestionsCorrect());
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

        static bool BirthState()
        {
            string correctVal = "Oregon";
            WriteQuestionNumber();
            Console.WriteLine("What US state was I born in?");
            string userInput = Console.ReadLine();
            //int parsedInput = UserInt(userInput);
            return (NormalizeString(userInput) == NormalizeString(correctVal));
        }

        static bool QuestionsCorrect()
        {
            WriteQuestionNumber();
            Console.WriteLine("How many questions have you answered correctly?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == correct);
        }

        static bool QuestionsIncorrect()
        {
            WriteQuestionNumber();
            Console.WriteLine("How many questions have you answered incorrectly?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == incorrect);
        }

        static bool CurrentAge()
        {
            int correctVal = GetMyAgeInYears();
            WriteQuestionNumber();
            Console.WriteLine("How old am I (in years)?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == correctVal);
        }

        static void WriteQuestionNumber()
        {
            Console.WriteLine("Question #" + (correct + incorrect + 1) + ": ");
        }

        static int GetMyAgeInYears()
        {
            if(DateTime.Today.Month > 3 || DateTime.Today.Month == 3 && DateTime.Today.Day >= 25)
            {
                //if today's month is later than March, or if today's month is March and the date is the 25th or later, I've had my birthday this year
                return DateTime.Today.Year - 1993;
            }
            else
            {
                //else I have not had this year's birthday
                return DateTime.Today.Year - 1993 - 1;
            }
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
