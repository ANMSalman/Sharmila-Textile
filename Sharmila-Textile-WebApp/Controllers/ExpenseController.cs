using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
    public class ExpenseController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public ExpenseController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult ExpenseListView(string date) {
            List<ExpenseViewModel> data;
            if (date != null) {
                data = (from a in _context.Expenses
                    join b in _context.Users on a.CreatedBy equals b.UserId
                    join c in _context.Staffs on b.StaffId equals c.StaffId
                    where a.Status == 1 && a.Date == Convert.ToDateTime(date)
                        select new ExpenseViewModel {
                        ExpenseId = a.ExpenseId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque, TotalAmount = a.TotalAmount,
                        CreatedDate = a.CreatedDate, PaymentType = a.PaymentType, CreatedBy = a.CreatedBy, UserName = c.StaffName, Remark = a.Remark,
                        Date = a.Date
                    }).ToList();
            }
            else {
                data = (from a in _context.Expenses
                    join b in _context.Users on a.CreatedBy equals b.UserId
                    join c in _context.Staffs on b.StaffId equals c.StaffId
                    where a.Status == 1
                    select new ExpenseViewModel {
                        ExpenseId = a.ExpenseId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque, TotalAmount = a.TotalAmount,
                        CreatedDate = a.CreatedDate, PaymentType = a.PaymentType, CreatedBy = a.CreatedBy, UserName = c.StaffName, Remark = a.Remark,
                        Date = a.Date
                    }).ToList();
            } 

            return View(data);
        }

        public IActionResult ExpenseDetailView(string breadCumValue, long expId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = expId > 0 ? "true" : "false";


            ExpenseViewModel expenseViewModel = new ExpenseViewModel();

            if (expId > 0) {
                expenseViewModel = (from a in _context.Expenses where a.ExpenseId == expId
                                    select new ExpenseViewModel {
                                        ExpenseId = a.ExpenseId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque,
                                        TotalAmount = a.TotalAmount, PaymentType = a.PaymentType,
                                        CreatedBy = a.CreatedBy, Remark = a.Remark, Date = a.Date,
                                        OwnChequesId = a.ExpenseOwnCheques.Select(x => x.OwnChequeId).ToList(),
                                        ThirdPartyChequesId = a.ExpenseThirdPartyCheques.Select(x => x.ThirdPartyChequeId).ToList()
                                    }).Single();
            }

            expenseViewModel.OwnChequesList = _context.OwnCheques.Select(x => new OwnCheque() {
                OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();
            expenseViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(expenseViewModel);
        }
    }
}