namespace PurchaseManagament.Application.Exceptions
{
    public class AlreadyExistsException:Exception
    {
        public AlreadyExistsException(string message):base(message) 
        {
            
        }

        public AlreadyExistsException()
        {
            
        }
    }
}
