using System;
namespace TabuProject.DTOs.Games
{
	public class GameCreateDto
	{
		public int BannedWordCount { get; set; }
		public int FailCount { get; set; }
		public int SkipCount { get; set; }
		public int Second { get; set; }
		public string LangCode { get; set; }

	}
}

