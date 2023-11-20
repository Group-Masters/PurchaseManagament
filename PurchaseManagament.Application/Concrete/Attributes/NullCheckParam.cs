using ArxOne.MrAdvice.Advice;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class NullCheckParam : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            if (context.Arguments.Any())
            {
                if (context.Arguments[0] is null)
                {
                    throw new Exception("Nesne oluşturulamadı.");
                }
                else
                {
                    context.Proceed();
                }
            }
            else
            {
                context.Proceed();
            }
        }
    }
}
