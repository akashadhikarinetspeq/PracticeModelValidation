// 1. Create the adapter to map HTML attributes to jQuery validation
jQuery.validator.unobtrusive.adapters.add("classicmovie", ["year"], function (options) {
    options.rules["classicmovie"] = options.params;
    options.messages["classicmovie"] = options.message;
});

// 2. Add the actual validation logic
jQuery.validator.addMethod("classicmovie", function (value, element, params) {
    if (!value) return true; // Let [Required] handle empty values

    const releaseDate = new Date(value);
    const limitYear = parseInt(params.year);

    // Ensure the year is not greater than the limit
    return releaseDate.getFullYear() <= limitYear;
});
