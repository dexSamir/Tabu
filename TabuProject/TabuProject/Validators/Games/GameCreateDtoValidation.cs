using System;
using FluentValidation;
using TabuProject.DTOs.Games;

namespace TabuProject.Validators.Games
{
	public class GameCreateDtoValidation : AbstractValidator<GameCreateDto>
	{
		public GameCreateDtoValidation()
		{
            RuleFor(x => x.LangCode)
                .NotEmpty()
                    .WithMessage("Code bosh ola bilmez!")
                .NotNull()
                    .WithMessage("Code Null ola bilmez!")
                .Length(2)
                    .WithMessage("Code 2 simvol uzunlunda olmalidir!");

            RuleFor(x => x.Second)
                .NotEmpty()
                    .WithMessage("Vaxt bos ola bilmez!")
                .NotNull()
                    .WithMessage("Vaxt Null ola bilmez!");


            RuleFor(x => x.BannedWordCount)
                .NotEmpty()
                    .WithMessage("banned word Count bos ola bilmez!")
                .NotNull()
                    .WithMessage("banned word Count Null ola bilmez!");
        }
	}
}

