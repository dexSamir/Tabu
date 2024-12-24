using System;
namespace TabuProject.Exceptions
{
	public interface IBaseException 
	{
		int StatusCode { get; }
		string ErrorMessage { get;  }
	}
}

