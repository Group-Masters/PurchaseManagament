using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class GetByIdDepartmanValidator : AbstractValidator<GetByIdDepartmentRM>
    {
        public GetByIdDepartmanValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");

        }
    }
}
