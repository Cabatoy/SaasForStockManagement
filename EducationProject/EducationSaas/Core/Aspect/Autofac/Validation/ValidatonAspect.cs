using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspect.Autfac.Validation
{
    public class ValidatonAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidatonAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType)) //gonderilen validatortype Ivalidator degilse 
            {
                throw new Exception(message: AspectMessages.WrongValidatonType);
            }

            _validatorType = validationType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //git methodun argumanlarina bak. birden fazla arguman olabilir tabi

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
