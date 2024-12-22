using System;
namespace TabuProject.DTOs.BannedWord
{
	public class BannedWordUpdateDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int WordId { get; set; }
    }
}

