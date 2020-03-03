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
    public class CustomerAccountController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CustomerAccountController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult CustomerAccountListView() {
            var data = (from a in _context.CustomerAccounts
                        join b in _context.Customers on a.CustomerId equals b.CustomerId
                        join c in _context.Users on a.CreatedBy equals c.UserId
                        join d in _context.Staffs on c.StaffId equals d.StaffId
                        where a.Status == 1
                        select new CustomerAccountViewModel {
                            CustomerAccountId = a.CustomerAccountId, Description = a.Description, Date = a.Date, Amount = a.Amount, AccountType = a.AccountType,
                            CreatedDate = a.CreatedDate, CustomerName = b.CustomerName, UserName = d.StaffName
                        }).ToList();

            return View(data);
        }

        public IActionResult CustomerAccountDetailView(string breadCumValue, long cusAccId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = cusAccId > 0 ? "true" : "false";

            CustomerAccountViewModel customerAccountViewModel = new CustomerAccountViewModel();

            if (cusAccId > 0) {
                customerAccountViewModel = (from a in _context.CustomerAccounts where a.CustomerAccountId == cusAccId
                                            select new CustomerAccountViewModel {
                                                CustomerAccountId = a.CustomerAccountId, Description = a.Description, Amount = a.Amount, AccountType = a.AccountType,
                                                CreatedDate = a.CreatedDate, Remark = a.Remark, CustomerId = a.CustomerId, CreatedBy = a.CreatedBy, Date = a.Date,
                                                OwnChequesId = a.CustomerAccountOwnCheques.Select(x => x.OwnChequeId).ToList(),
                                                ThirdPartyChequesId = a.CustomerAccountThirdPartyCheques.Select(x => x.ThirdPartyChequeId).ToList()
                                            }).Single();
            }

            customerAccountViewModel.CustomerList = _context.Customers.Where(s => s.CurrentStatus == 1).Select(x => new Customer() {
                CustomerId = x.CustomerId, CustomerName = x.CustomerName
            }).ToList();
            customerAccountViewModel.OwnChequesList = _context.OwnCheques.Select(x => new OwnCheque() {
                OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();
            customerAccountViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(customerAccountViewModel);

        }
    }
}