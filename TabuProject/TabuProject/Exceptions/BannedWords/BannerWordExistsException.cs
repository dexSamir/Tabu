using System;
namespace TabuProject.Exceptions.BannedWords
{
	public class BannerWordExistsException : Exception, IBaseException
	{
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public BannerWordExistsException()
        {
            ErrorMessage = "The banned Word is not found!";
        }
        public BannerWordExistsException(string msg) : base(msg)
        {
            ErrorMessage = msg;
        }
    }
}

