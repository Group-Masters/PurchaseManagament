using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleRM>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen Role Adı bilgisini boş bırakmayınız");
        }
    }
}
