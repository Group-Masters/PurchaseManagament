using ArxOne.MrAdvice.Advice;
using KingAOP.Aspects;
using System.Reflection;
using System.Text;

namespace PurchaseManagament.Application.Concrete.Attributes
{
    internal class ExceptionHandlingAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {

            Console.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        }
        // will be called when exception occurs.
        public override void OnException(MethodExecutionArgs args)
        {
            var str = new StringBuilder();
            str.AppendLine();
            str.Append(args.Exception.Message);
            str.AppendLine();

            if (args.Instance != null)
            {
                var instType = args.Instance.GetType();
                str.AppendFormat("Type = {0}; ", instType.Name);
                foreach (var property in instType.GetProperties(BindingFlags.Instance
                                         | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {
                    str.AppendFormat("{0} = {1}; ", property.Name,
                                                    property.GetValue(args.Instance, null));
                }
            }
            str.AppendLine();
            Console.WriteLine(str.ToString());
            Console.Write("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

            args.FlowBehavior = FlowBehavior.RethrowException; // set the flow behavior.
        }
    }
}
