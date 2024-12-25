using System;
using TabuProject.Entities;

namespace TabuProject.DTOs.Games
{
	public class GameStatusDto
	{
		public int Success { get; set; }
		public int Fail{ get; set; }
		public int Skip { get; set; }
		public Stack<Word> Words { get; set; }
		public int[] UsedWordsId { get; set; }

	}
}

