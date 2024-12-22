using System;
namespace TabuProject.Entities
{
	public class Word
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string LangCode { get; set; }
		public Language Language { get; set; }
		public ICollection<BannedWord> BannedWords { get; set; }
	}
}

