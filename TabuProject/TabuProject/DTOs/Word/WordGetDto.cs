﻿using System;
using TabuProject.DTOs.BannedWord;

namespace TabuProject.DTOs.Word
{
	public class WordGetDto
	{
		public string Text { get; set; }
		public string LangCode { get; set; }
		public List<BannedWordGetDto> BannedWords{ get; set; }

	}
}

