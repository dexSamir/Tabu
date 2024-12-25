using System;
namespace TabuProject.DTOs.Words
{
	public class WordUpdateDto
	{
		public string? Text { get; set; }
		public string? LangCode { get; set; }
		public HashSet<string> BannedWords { get; set; }
    }
}

