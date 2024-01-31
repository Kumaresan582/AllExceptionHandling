using AllExceptionHandling.Service;
using ExceptionHandling.Service;

namespace AllExceptionHandling
{
    internal class program
    {
        private static void Main(string[] args)
        {
            IErrorHandling obj = new ErrorHandlingClass();
            obj.Error();
            obj.stringerror();
        }
    }
}