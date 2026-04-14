using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PracticeModelValidation.Helpers
{
    public class ClassicMovieAttribute(int year) : ValidationAttribute, IClientModelValidator
    {
        public int Year { get; } = year;

        public void AddValidation(ClientModelValidationContext context)
        {
            CustomValidationHelpers.MergeAttribute(context.Attributes, "data-val", "true");
            CustomValidationHelpers.MergeAttribute(context.Attributes, "data-val-classicmovie", GetErrorMessage());

            var year = Year.ToString(CultureInfo.InvariantCulture);
            CustomValidationHelpers.MergeAttribute(context.Attributes, "data-val-classicmovie-year", year);
        }

        public string GetErrorMessage() => ErrorMessage ?? $"Classic movies must have a release year no later than {Year}.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var releaseYear = ((DateTime)value!).Year;

            if (releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
