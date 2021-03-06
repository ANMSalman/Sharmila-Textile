﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.FluentValidation.Validators {
    public class OwnChequeViewModelValidator : AbstractValidator<OwnChequeViewModel> {
        private readonly AppDBContext _context;

        public OwnChequeViewModelValidator(AppDBContext context) {
            _context = context;

            RuleFor(x => x.ChequeCode)
                .NotEmpty().WithMessage("Cheque Code cannot be empty");

            When(model => model.IsUpdate == false, () => {
                RuleFor(x => x.ChequeCode)
                    .Must(UniqueChequeCode).WithMessage("Cheque Code already taken");
            });

            RuleFor(x => x.Bank)
                .NotEmpty().WithMessage("Bank Name cannot be empty");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch Name cannot be empty");

            RuleFor(x => x.Amount) 
                .ScalePrecision(2, 18).WithMessage("Numbers should be within 2 decimal place");

        }

        private bool UniqueChequeCode(string checkCode) {
            var codeCheque = _context.OwnCheques
                .SingleOrDefault(x => x.ChequeCode.ToLower() == checkCode.ToLower());

            return codeCheque == null;
        }
    }
}
