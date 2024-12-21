using System;
using FluentValidation;
using TabuProject.DTOs.Languages;
using TabuProject.Entities;

namespace TabuProject.Validators.Languages
{
	public class LanguageCreateDtoValidator : AbstractValidator<CreateLanguageDto>
	{
		public LanguageCreateDtoValidator()
		{
			RuleFor(x => x.Code)
				.NotEmpty()
					.WithMessage("Code bosh ola bilmez!")
				.NotNull()
					.WithMessage("Code Null ola bilmez!")
				.Length(2)
					.WithMessage("Code 2 simvol uzunlunda olmalidir!");

			RuleFor(x => x.Name)
				.MaximumLength(32)
				.MinimumLength(3);
			RuleFor(x => x.IconUrl)
				.MaximumLength(128)
				.Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
					.WithMessage("Url Link olmalidir!"); 
		}
	}
}

