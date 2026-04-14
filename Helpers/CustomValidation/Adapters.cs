using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace PracticeModelValidation.Helpers.CustomValidation
{
    public class ClassicMovieAttributeAdapter(ClassicMovieAttribute attribute, IStringLocalizer? stringLocalizer) : AttributeAdapterBase<ClassicMovieAttribute>(attribute, stringLocalizer)
    {
        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-classicmovie", GetErrorMessage(context));

            var year = Attribute.Year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-classicmovie-year", year);
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext) => Attribute.GetErrorMessage();
    }
}
