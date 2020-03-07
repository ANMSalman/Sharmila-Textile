using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
    public class SummaryController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SummaryController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult SummaryListView() {
            var data = _mapper.Map<List<SummaryViewModel>>(_context.Summaries.Where(x => x.Status == 1).ToList());
            return View(data);
        }


        public IActionResult SummaryDetailView(string breadCumValue, long sumId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = sumId > 0 ? "true" : "false";

            SummaryViewModel viewModel = new SummaryViewModel();

            if (sumId > 0) {
                viewModel = _mapper.Map<SummaryViewModel>(_context.Summaries.SingleOrDefault(s=>s.SummaryId == sumId));
            }
            else {
                viewModel.TotalCollection = _context.Collections.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableCollection = _context.Collections.Where(x => x.Status == 1 && x.CollectionType == 8).Sum(s => s.TotalAmount);

                viewModel.TotalPayment = _context.SupplierPayments.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountablePayment =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join[dbo].[SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join[dbo].[SUPPLIER_PAYMENT] c on b.SUPPLIER_PAYMENT_ID = c.SUPPLIER_PAYMENT_ID
                                where(c.PAYMENT_TYPE = 7 OR c.PAYMENT_TYPE = 8) and CAST(a.DATE as date) = CAST(GETDATE() as date)");

                viewModel.TotalExpense = _context.Expenses.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableExpense =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join[dbo].[EXPENSE_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join[dbo].[EXPENSE] c on b.EXPENSE_ID = c.EXPENSE_ID
                                where CAST(a.DATE as date) = CAST(GETDATE() as date)");

                viewModel.TotalBankDeposit = _context.BankDeposits.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableBankDeposit =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join[dbo].[BANK_DEPOSIT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join[dbo].[BANK_DEPOSIT] c on b.BANK_DEPOSIT_ID = c.BANK_DEPOSIT_ID
                                where CAST(a.DATE as date) = CAST(GETDATE() as date)");
                viewModel.ChequeBalance = _context.ThirdPartyCheques.Where(x => x.Status == 1 && x.Date == DateTime.Today).Sum(s => s.Amount);
            }

            
            return View(viewModel);
        }

        private decimal GetAccountablePayment(string sql) {
            var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = sql;
            _context.Database.OpenConnection();
            var result = command.ExecuteReader();
            if (result.Read()) {
                if (!result.IsDBNull(0) && !result.IsDBNull(1)) {
                    return Convert.ToDecimal(result["cashSum"].ToString()) +
                           Convert.ToDecimal(result["amountSum"].ToString());
                } 
            }

            return 0;
        }



    }
}