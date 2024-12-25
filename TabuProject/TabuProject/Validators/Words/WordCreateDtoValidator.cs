using System;
using FluentValidation;
using TabuProject.DTOs.Words;

namespace TabuProject.Validators.Words
{
	public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
	{
		public WordCreateDtoValidator()
		{
			RuleForEach(x => x.BannedWords)
				.NotNull()
				.MinimumLength(2)
					.WithMessage("Soz minimum 2 simvol uzunlugunda olmalidir!")
				.MaximumLength(32)
					.WithMessage("Soz maximum 32 simvol uzunlugunda olmalidir!");

			RuleFor(x => x.BannedWords)
				.NotNull()
				.Must(x => x.Count == 6);

			RuleFor(x => x.LangCode)
				.NotEmpty()
					.WithMessage("Dil bosh ola bilmez!")
				.NotNull()
					.WithMessage("Dil kodu null ola bilmez!")
				.Length(2)
					.WithMessage("Dil kodu maximum 2 simvol uzunlugunda olmalidir!");

			RuleFor(x=> x.Text)
                .NotNull()
                    .WithMessage("Soz null ola bilmez!")
				.MaximumLength(32)
					.WithMessage("Soz maximum 32 simvol uzunlugunda olmalidir!")
				.MinimumLength(2)
                    .WithMessage("Soz minimum 2 simvol uzunlugunda olmalidir!");
        }
    }
}

