using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Mayordomo.Transversal.Validator.Extensions
{
    public class GenericValueValidator : AbstractValidator<object>
    {
        public GenericValueValidator(IStringLocalizer<Mayordomo.Transversal.Resources.Mayordomo> localizer)
        {
            RuleFor(x => x)
            .NotNull()
            .WithMessage(localizer["LABEL_DATA_EMPTY"]);

            // STRING
            When(x => x is string, () =>
            {
                RuleFor(x => x as string)
                    .NotEmpty().WithMessage(localizer["LABEL_DATA_EMPTY"]);
            });

            // INT
            When(x => x is int, () =>
            {
                RuleFor(x => (int)(object)x)
                    .GreaterThanOrEqualTo(0).WithMessage(localizer["LABEL_ERROR_NUMBER"]);
            });

            // LONG
            When(x => x is long, () =>
            {
                RuleFor(x => (long)(object)x)
                    .GreaterThanOrEqualTo(0);
            });

            // DECIMAL
            When(x => x is decimal, () =>
            {
                RuleFor(x => (decimal)(object)x)
                    .GreaterThanOrEqualTo(0).WithMessage(localizer["LABEL_POSITIVE_DECIMAL"]);
            });

            // DOUBLE
            When(x => x is double, () =>
            {
                RuleFor(x => (double)(object)x)
                    .Must(v => !double.IsNaN(v) && !double.IsInfinity(v))
                    .WithMessage(localizer["LABEL_ERROR_NUMBER"]);
            });

            // FLOAT
            When(x => x is float, () =>
            {
                RuleFor(x => (float)(object)x)
                    .Must(v => !float.IsNaN(v) && !float.IsInfinity(v))
                    .WithMessage(localizer["LABEL_ERROR_NUMBER"]);
            });

            // BOOL
            When(x => x is bool, () =>
            {
                RuleFor(x => (bool)(object)x)
                    .NotNull()
                    .WithMessage(localizer["LABEL_DATA_EMPTY"]);
            });

            // DATETIME
            When(x => x is DateTime, () =>
            {
                RuleFor(x => (DateTime)(object)x)
                    .GreaterThan(new DateTime(1900, 1, 1))
                    .WithMessage(localizer["LABEL_INVALID_DATETIME"]);
            });

            // GUID
            When(x => x is Guid, () =>
            {
                RuleFor(x => (Guid)(object)x)
                    .Must(g => g != Guid.Empty)
                    .WithMessage(localizer["LABEL_DATA_EMPTY"]);
            });
        }
    }
}
