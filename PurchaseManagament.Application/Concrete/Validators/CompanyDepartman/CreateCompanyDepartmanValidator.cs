using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class CreateCompanyDepartmanValidator : AbstractValidator<CreateCompanyDepartmanRM>
    {
        public CreateCompanyDepartmanValidator()
        {
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız");
        }
    }
}
