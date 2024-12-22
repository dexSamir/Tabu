using System;
namespace TabuProject.Exceptions.Languages
{
	public class LanguageNotFoundException : Exception, IBaseException
	{

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

		public LanguageNotFoundException()
		{
			ErrorMessage = "Verilen Code-a uygun dil tapilmadi!"; 
		}
		public LanguageNotFoundException(string message) : base(message)
		{
			ErrorMessage = message;
		}
    }
}

