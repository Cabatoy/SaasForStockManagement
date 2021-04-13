using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttiribute
    {

        protected virtual void OnBefore(IInvocation invocation)
        {


        }

        protected virtual void OnAfter(IInvocation invocation)
        {


        }
        protected virtual void OnException(IInvocation invocation)
        {


        }
        protected virtual void OnSuccess(IInvocation invocation)
        {


        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed(); //operasyonu calistir
            }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
