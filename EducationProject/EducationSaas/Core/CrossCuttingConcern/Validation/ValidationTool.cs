﻿

using FluentValidation;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                // return new ErrorResult(message: result.Errors.ToString());
                throw new ValidationException(result.Errors);
            }

        }
    }
}
