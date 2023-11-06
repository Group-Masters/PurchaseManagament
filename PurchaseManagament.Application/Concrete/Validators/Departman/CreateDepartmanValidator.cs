using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class CreateDepartmanValidator : AbstractValidator<CreateDepartmentRM>
    {
        public CreateDepartmanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen departman ismini boş bırakmayınız");
        }
    }
}
