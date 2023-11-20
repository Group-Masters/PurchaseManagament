using ArxOne.MrAdvice.Advice;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    internal class ExceptionHandlingAttribute : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            try
            {
                context.Proceed();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
