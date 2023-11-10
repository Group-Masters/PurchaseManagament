﻿using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class GetByIdDepartmanValidator : AbstractValidator<GetByIdDepartmentRM>
    {
        public GetByIdDepartmanValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
