using FluentValidation;
using TabuProject.DTOs.BannedWord;

namespace TabuProject.Validators.BannedWords
{
    public class BannedWordsCreateDtoValidator : AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordsCreateDtoValidator()
        {

        }
    }
}
