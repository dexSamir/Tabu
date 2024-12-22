using System;
using FluentValidation;
using TabuProject.DTOs.Languages;

namespace TabuProject.Validators.Languages
{
	public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
	{
		public LanguageUpdateDtoValidator()
		{
			RuleFor(x => x.Name)
				.MaximumLength(32)
					.WithMessage("Olke adi maximum 32 simvol uzunlugunda olmalidir!")
				.MinimumLength(3)
					.WithMessage("Olke adi minimum 3 simvol uzunlugunda olmalidir!");
			RuleFor(x => x.Icon)
				.MaximumLength(128)
					.WithMessage("Icon URL-i maximum 128 simvol uzunlugunda olmalidir!")
				.Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
					.WithMessage("URL-i duzgun daxil edin"); 
		}
	}
}

