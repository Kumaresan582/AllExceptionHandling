using AllExceptionHandling.Directories;
using AllExceptionHandling.Service;

namespace ExceptionHandling.Service
{
    public class ErrorHandlingClass : IErrorHandling
    {
        public void Error()
        {
            string firstName;
            string ageText;
            int age;
            int result = 0;

            Console.Write("Enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("Enter your age: ");
            ageText = Console.ReadLine();

            try
            {
                age = int.Parse(ageText);
                Console.WriteLine($"Hi {firstName}! You are {age * 12} months old.");
            }
            catch (FormatException ex)
            {
                string errorMessage = $"The age entered, {ageText}, is not valid.";
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(ex, errorMessage);
            }
            catch (Exception exception)
            {
                string errorMessage = $"Unexpected error:  {exception.Message}";
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(exception, errorMessage);
            }
            finally
            {
                Console.WriteLine($"Goodbye {firstName}");
            }
        }

        public void stringerror()
        {
            try
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                int stringLength = GetStringLength(input);
                Console.WriteLine("Length of the string: " + stringLength);
            }
            catch (ArgumentNullException ex)
            {
                string errorMessage = "The input string is null.";
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(ex, errorMessage);
            }
            catch (ArgumentException ex)
            {
                string errorMessage = "The input string is empty.";
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(ex, errorMessage);
            }
            catch (OverflowException ex)
            {
                string errorMessage = "The input string length exceeds the maximum limit.";
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(ex, errorMessage);
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred: " + ex.Message;
                Console.WriteLine(errorMessage);
                Common.WriteToLogFile(ex, errorMessage);
            }
        }

        private static int GetStringLength(string input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException();
                }

                if (input == string.Empty)
                {
                    throw new ArgumentException();
                }

                return checked(input.Length);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("An overflow occurred while calculating the string length.", ex);
            }
        }
    }
}