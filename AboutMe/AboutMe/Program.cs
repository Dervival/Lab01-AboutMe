using System;

namespace AboutMe
{
    class Program
    {
        //keeping these public as counters
        public static int correct = 0;
        public static int incorrect = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Here's a quick quiz about me!");
            UpdateCounters(SibNum());
            UpdateCounters(BirthMonth());
            UpdateCounters(BirthState());
            UpdateCounters(CurrentAge());
            UpdateCounters(WalkDistance());

            //debug questions - check to make sure that correct/incorrect values are appropriately updating
            //UpdateCounters(QuestionsCorrect());
            //UpdateCounters(QuestionsIncorrect());
            //Using the ternary operator (https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator) for practice 
            Console.WriteLine("You got " + correct + " question" + (UsePlural(correct) ? "s" : "") + " right and " + incorrect + " question" + (UsePlural(incorrect) ? "s" : "") + " incorrect.");
            Console.ReadLine();
        }

        /*---------------Functions for updating global state------------------*/
        static void UpdateCounters(bool questionResult)
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

        /*---------------Functions for asking questions and receiving/evaluating input------------------*/

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
            return (UserInt(userInput) == correctVal);
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

        static bool CurrentAge()
        {
            int correctVal = GetMyAgeInYears();
            WriteQuestionNumber();
            Console.WriteLine("How old am I (in years)?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == correctVal);
        }

        static bool WalkDistance()
        {
            double correctVal = 1.25;
            WriteQuestionNumber();
            Console.WriteLine("How far do I walk to get to CodeFellows each day, one way?");
            string userInput = Console.ReadLine();
            double parsedInput = UserDouble(userInput);
            return (parsedInput == correctVal);
        }

        /*---------------Functions for testing state of "global" variables------------------*/
        static bool QuestionsCorrect()
        {
            WriteQuestionNumber();
            Console.WriteLine("How many questions have you answered correctly?");
            string userInput = Console.ReadLine();
            return (UserInt(userInput) == correct);
        }

        static bool QuestionsIncorrect()
        {
            WriteQuestionNumber();
            Console.WriteLine("How many questions have you answered incorrectly?");
            string userInput = Console.ReadLine();
            int parsedInput = UserInt(userInput);
            return (parsedInput == incorrect);
        }

        /*---------------Helper Methods------------------*/
        //this is probably one of the most specific and least useful helper functions ever written
        static bool UsePlural(int count)
        {
            if (count == 1 || count == -1)
            {
                return false;
            }
            return true;
        }

        static void WriteQuestionNumber()
        {
            try
            {
                Console.WriteLine("Question #" + (correct + incorrect + 1) + ": ");
            }
            catch(Exception e)
            {
                Console.WriteLine("Unexpected exception in WriteQuestionNumber:");
                Console.WriteLine(e.Message);
            }
            
        }
        /*---------------Getter Methods------------------*/
        static int GetMyAgeInYears()
        {
            //using the Today property of the DateTime object from here https://docs.microsoft.com/en-us/dotnet/api/system.datetime.today?view=netframework-4.7.2
            try
            {
                if (DateTime.Today.Month > 3 || DateTime.Today.Month == 3 && DateTime.Today.Day >= 25)
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
            catch(Exception e)
            {
                Console.WriteLine("Hit an unexpected exception in GetMyAgeInYears:");
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        /*---------------Normalization/Parsing Methods------------------*/
        static string NormalizeString(string userInput)
        {
            //for this normalization, I'm just removing whitespace padding to the left and right of the given string and converting it all to lower case
            try
            {
                return userInput.Trim().ToLower();
            }
            catch (FormatException)
            {
                Console.WriteLine("Format exception thrown for NormalizeString - make sure we're still taking in a string for normalization.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hit an unexpected exception in NormalizeString:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                //No resources opened up in the try - no need to close them in the finally statement
                //Console.WriteLine("User input for a string has been normalized.");
            }
            //if all else fails, return the original input
            return userInput;
        }

        static int UserInt(string userInput)
        {
            //if an exception is thrown, just return 0
            int parsedInt = 0;
            try
            {
                return Convert.ToInt32(userInput);
            }
            catch(FormatException)
            {
                Console.WriteLine("That input was not convertable to an integer - discarding it and replacing it with a default value of 0.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Hit an unexpected exception in UserInt:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                //No resources opened up in the try - no need to close them in the finally statement
                //Console.WriteLine("User input for an integer has been normalized.");
            }
            return parsedInt;
        }

        static double UserDouble(string userInput)
        {
            //if an exception is thrown, just return 0.0
            double parsedDouble = 0.0;
            try
            {
                return Convert.ToDouble(userInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("That input was not convertable to a double - discarding it and replacing it with a default value of 0.0.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hit an unexpected exception in UserInt:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                //No resources opened up in the try - no need to close them in the finally statement
                //Console.WriteLine("User input for a double has been normalized.");
            }
            return parsedDouble;
        }

    }
}
