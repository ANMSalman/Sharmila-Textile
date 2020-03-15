using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            var data = _mapper.Map<List<SummaryViewModel>>(_context.Summaries.Where(x => x.Status == 1).ToList());
            return View(data);
        }

        public IActionResult SummaryDetailView(string breadCumValue, long sumId) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = sumId > 0 ? "true" : "false";

            SummaryViewModel viewModel = new SummaryViewModel();

            if (sumId > 0) {
                viewModel = _mapper.Map<SummaryViewModel>(_context.Summaries.SingleOrDefault(s => s.SummaryId == sumId));
            }
            else {
                viewModel.Date = DateTime.Now;
                viewModel.TotalCollection = _context.Collections.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableCollection = _context.Collections.Where(x => x.Status == 1 && x.CollectionType == 8).Sum(s => s.TotalAmount);

                viewModel.TotalPayment = _context.SupplierPayments.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountablePayment =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join [dbo].[SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join [dbo].[SUPPLIER_PAYMENT] c on b.SUPPLIER_PAYMENT_ID = c.SUPPLIER_PAYMENT_ID
                                where(c.PAYMENT_TYPE = 7 OR c.PAYMENT_TYPE = 8) and CAST(a.DATE as date) = CAST(GETDATE() as date)");

                viewModel.TotalExpense = _context.Expenses.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableExpense =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join [dbo].[EXPENSE_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join [dbo].[EXPENSE] c on b.EXPENSE_ID = c.EXPENSE_ID
                                where CAST(a.DATE as date) = CAST(GETDATE() as date)");

                viewModel.TotalBankDeposit = _context.BankDeposits.Where(x => x.Status == 1).Sum(s => s.TotalAmount);
                viewModel.AccountableBankDeposit =
                    GetAccountablePayment(@"select sum(c.CASH) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join [dbo].[BANK_DEPOSIT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join [dbo].[BANK_DEPOSIT] c on b.BANK_DEPOSIT_ID = c.BANK_DEPOSIT_ID
                                where CAST(a.DATE as date) = CAST(GETDATE() as date)");
                viewModel.ChequeBalance = _context.ThirdPartyCheques.Where(x => x.Status == 1 && x.Date == DateTime.Today).Sum(s => s.Amount);

                viewModel.AccountableCustomerAccount =
                    GetAccountablePayment(@"select sum(c.AMOUNT) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join [dbo].[CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join [dbo].[CUSTOMER_ACCOUNT] c on b.CUSTOMER_ACCOUNTS_ID = c.CUSTOMER_ACCOUNTS_ID
                                where c.ACCOUNT_TYPE = 'Loan' and CAST(a.DATE as date) = CAST(GETDATE() as date)");

                viewModel.AccountableSupplierAccount =
                    GetAccountablePayment(@"select sum(c.AMOUNT) as cashSum, sum(a.AMOUNT) as amountSum from [dbo].[THIRD_PARTY_CHEQUE] a
                                inner join [dbo].[SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE] b on a.THIRD_PARTY_CHEQUE_ID = b.THIRD_PARTY_CHEQUE_ID
                                inner join [dbo].[SUPPLIER_ACCOUNT] c on b.SUPPLIER_ACCOUNTS_ID = c.SUPPLIER_ACCOUNTS_ID
                                where CAST(a.DATE as date) = CAST(GETDATE() as date)"); // didn't include loan filter

                viewModel.CollectionViewModels = (from a in _context.Collections
                                                  join b in _context.ChequeStatuses on a.CollectionType equals b.ChequeStatusId
                                                  join c in _context.Customers on a.CustomerId equals c.CustomerId
                                                  where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                                  select new CollectionViewModel {
                                                      CollectionId = a.CollectionId, Description = a.Description, TotalAmount = a.TotalAmount,
                                                      CollectionTypeName = b.StatusName, CustomerName = c.CustomerName
                                                  }).ToList();

                viewModel.CustomerAccountViewModels = (from a in _context.CustomerAccounts
                                                       join b in _context.Customers on a.CustomerId equals b.CustomerId
                                                       where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                                       select new CustomerAccountViewModel {
                                                           CustomerAccountId = a.CustomerAccountId, Description = a.Description, Amount = a.Amount,
                                                           AccountType = a.AccountType
                                                       }).ToList();

                viewModel.SupplierPaymentViewModels = (from a in _context.SupplierPayments
                                                       join b in _context.ChequeStatuses on a.PaymentType equals b.ChequeStatusId
                                                       join c in _context.Suppliers on a.SupplierId equals c.SupplierId
                                                       where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                                       select new SupplierPaymentViewModel() {
                                                           SupplierPaymentId = a.SupplierPaymentId, Description = a.Description, TotalAmount = a.TotalAmount,
                                                           PaymentTypeName = b.StatusName, SupplierName = c.SupplierName
                                                       }).ToList();

                viewModel.SupplierAccountViewModels = (from a in _context.SupplierAccounts
                                                       join b in _context.Suppliers on a.SupplierId equals b.SupplierId
                                                       where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                                       select new SupplierAccountViewModel {
                                                           SupplierAccountId = a.SupplierAccountId, Description = a.Description, Amount = a.Amount,
                                                           AccountType = a.AccountType
                                                       }).ToList();

                viewModel.ExpenseViewModels = (from a in _context.Expenses
                                               where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                               select new ExpenseViewModel() {
                                                   ExpenseId = a.ExpenseId, Description = a.Description, TotalAmount = a.TotalAmount,
                                                   PaymentType = a.PaymentType
                                               }).ToList();

                viewModel.BankDepositViewModels = (from a in _context.BankDeposits
                                                   where a.Status == 1 && a.Date.Date == DateTime.Now.Date
                                                   select new BankDepositViewModel() {
                                                       BankDepositId = a.BankDepositId, TotalAmount = a.TotalAmount
                                                   }).ToList();

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