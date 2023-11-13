﻿using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentRM>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'sini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen departman ismini boş bırakmayınız").MaximumLength(50).WithMessage("Departman Adı Bilgisi 50 Karakterden Fazla Olamaz");
        }
    }
}
