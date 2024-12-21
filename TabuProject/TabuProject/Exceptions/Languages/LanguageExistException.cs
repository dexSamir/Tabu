using System;
namespace TabuProject.Exceptions.Languages
{
	public class LanguageExistException : Exception, IBaseException
	{

        public int StatusCode => StatusCodes.Status409Conflict; 

        public string ErrorMessage { get; }

        public LanguageExistException()
        {
            ErrorMessage = "this language already exists"; 
        }
        public LanguageExistException(string message) : base(message)
        {
            ErrorMessage = message; 
        }
    }
}

