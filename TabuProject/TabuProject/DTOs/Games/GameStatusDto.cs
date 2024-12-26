 using System;
using TabuProject.DTOs.Words;
using TabuProject.Entities;

namespace TabuProject.DTOs.Games
{
	public class GameStatusDto
	{
		public int Success { get; set; }
		public int Fail{ get; set; }
		public int Skip { get; set; }
		public Stack<WordForGameDto> Words { get; set; }
		public IEnumerable<int> UsedWordsId { get; set; }
		public int MaxSkipCount { get; set; }

	}
}

