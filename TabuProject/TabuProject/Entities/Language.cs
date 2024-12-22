using System;
namespace TabuProject.Entities
{
	public class Language
	{
		public string Code{ get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public IEnumerable<Game> Games { get; set; }
		public IEnumerable<Word> Words { get; set; }

 	}
}

