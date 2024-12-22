using System;
namespace TabuProject.Exceptions.Words
{
	public class WordExitsException : Exception, IBaseException
	{
        public int StatusCode => StatusCodes.Status409Conflict; 

        public string ErrorMessage { get; }

        public WordExitsException()
        {
            ErrorMessage = "The word is already exists!"; 
        }
        public WordExitsException(string message) : base(message)
        {
            ErrorMessage = message; 
        }
    }
}

