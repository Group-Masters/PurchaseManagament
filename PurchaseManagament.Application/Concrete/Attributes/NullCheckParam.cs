using ArxOne.MrAdvice.Advice;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    public class NullCheckParam : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            if (context.Arguments[0] == null)
            {
                throw new Exception("Nesne oluşturulamadı");
            }
            else
            {
                context.Proceed();
            }
        }
    }
}
