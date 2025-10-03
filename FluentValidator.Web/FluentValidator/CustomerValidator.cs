using FluentValidation;
using FluentValidator.Web.Models;

namespace FluentValidator.Web.FluentValidator
{
	public class CustomerValidator : AbstractValidator<Customer>
	{
		public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";

		public CustomerValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
			RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress()
				.WithMessage("Email alanı dogru formatta olmalıdır");

			RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60)
				.WithMessage("Age alanı 18 ile 60 arasında olmalıdır");

			RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
			{
				return DateTime.Now.AddYears(-18) >= x;
			}).WithMessage("Yaşınız 18 yaşından büyük olmalıdır");

			RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1,Kadın=2 olmalıdır");

			RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
		}
	}
}
