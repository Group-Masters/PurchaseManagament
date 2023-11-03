namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class UpdatePasswordVM
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string RepeateNewPassword { get; set; }
    }
}
