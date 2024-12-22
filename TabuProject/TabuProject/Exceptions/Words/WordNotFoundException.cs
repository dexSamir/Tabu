using System;
namespace TabuProject.Exceptions.Words
{
    public class WordNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public WordNotFoundException()
        {
            ErrorMessage = "The word is not found!"; 
        }

        public WordNotFoundException(string msg) : base (msg)
        {
            ErrorMessage = msg; 
        }
    }
}

