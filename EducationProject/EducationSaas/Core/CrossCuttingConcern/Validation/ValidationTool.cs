using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.CrossCuttingConcern.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            
            var result = validator.Validate((IValidationContext) entity);
            if (!result.IsValid)
            {
               // return new ErrorResult(message: result.Errors.ToString());
                throw new ValidationException(result.Errors);
            }

        }
    }
}
