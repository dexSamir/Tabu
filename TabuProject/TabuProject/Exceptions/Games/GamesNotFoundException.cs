using System;
namespace TabuProject.Exceptions.Games
{
	public class GamesNotFoundException : Exception, IBaseException
	{
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public GamesNotFoundException()
        {
            ErrorMessage = "The game is not found!"; 
        }
        public GamesNotFoundException(string msg) : base (msg)
        {
            ErrorMessage = msg; 
        }
    }
}

