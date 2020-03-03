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
    public class SupplierAccountController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SupplierAccountController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult SupplierAccountListView() {
            var data = (from a in _context.SupplierAccounts
                        join b in _context.Suppliers on a.SupplierId equals b.SupplierId
                        join c in _context.Users on a.CreatedBy equals c.UserId
                        join d in _context.Staffs on c.StaffId equals d.StaffId
                        where a.Status == 1
                        select new SupplierAccountViewModel {
                            SupplierAccountId = a.SupplierAccountId, Description = a.Description, Amount = a.Amount, AccountType = a.AccountType,
                            CreatedDate = a.CreatedDate, SupplierName = b.SupplierName, Date = a.Date, UserName = d.StaffName
                        }).ToList();

            return View(data);
        }

        public IActionResult SupplierAccountDetailView(string breadCumValue, long supAccId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = supAccId > 0 ? "true" : "false";

            SupplierAccountViewModel supplierAccountViewModel = new SupplierAccountViewModel();

            if (supAccId > 0) {
                supplierAccountViewModel = (from a in _context.SupplierAccounts where a.SupplierAccountId == supAccId
                                            select new SupplierAccountViewModel {
                                                SupplierAccountId = a.SupplierAccountId, Description = a.Description, Amount = a.Amount, AccountType = a.AccountType,
                                                CreatedDate = a.CreatedDate, Remark = a.Remark, SupplierId = a.SupplierId, CreatedBy = a.CreatedBy, Date = a.Date,
                                                OwnChequesId = a.SupplierAccountOwnCheques.Select(x => x.OwnChequeId).ToList(),
                                                ThirdPartyChequesId = a.SupplierAccountThirdPartyCheques.Select(x => x.ThirdPartyChequeId).ToList()
                                            }).Single();
            }

            supplierAccountViewModel.SupplierList = _context.Customers.Where(s => s.CurrentStatus == 1).Select(x => new Supplier() {
                SupplierId = x.CustomerId, SupplierName = x.CustomerName
            }).ToList();
            supplierAccountViewModel.OwnChequesList = _context.OwnCheques.Select(x => new OwnCheque() {
                OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();
            supplierAccountViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(supplierAccountViewModel);

        }

    }
}