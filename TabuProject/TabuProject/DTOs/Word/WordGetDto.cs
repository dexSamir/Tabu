using System;
namespace TabuProject.DTOs.Word
{
	public class WordGetDto
	{
		public int Id{ get; set; }
		public string Text { get; set; }
		public string LangCode { get; set; }
		public IList<string> BannedWords{ get; set; }

	}
}

