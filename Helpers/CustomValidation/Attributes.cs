using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace PracticeModelValidation.Helpers.CustomValidation
{
    public class ClassicMovieAttribute(int year) : ValidationAttribute
    {
        public int Year { get; } = year;

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
