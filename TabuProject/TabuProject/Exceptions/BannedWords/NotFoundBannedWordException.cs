using System;
namespace TabuProject.Exceptions.BannedWords
{
	public class NotFoundBannedWordException : Exception, IBaseException
	{
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public NotFoundBannedWordException()
        {
            ErrorMessage = "The banned Word is not found!"; 
        }
        public NotFoundBannedWordException(string msg) : base(msg)
        {
            ErrorMessage = msg; 
        }
    }
}

