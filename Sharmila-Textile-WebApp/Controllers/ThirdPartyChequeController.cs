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
    public class ThirdPartyChequeController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public ThirdPartyChequeController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult ThirdPartyChequeList() {
            List<ThirdPartyChequeViewModel> data = (from a in _context.ThirdPartyCheque
                                                    join b in _context.ChequeStatus on a.Status equals b.ChequeStatusId
                select new ThirdPartyChequeViewModel {
                    ThirdPartyChequeId = a.ThirdPartyChequeId, ChequeCode = a.ChequeCode, Bank = a.Bank, Branch = a.Branch, Amount = a.Amount,
                    DueDate = a.DueDate, StatusId = b.ChequeStatusId, Status = b.StatusName, Remark = a.Remark
                }).ToList();

            return View(data);
        }

        public IActionResult ThirdPartyChequeDetailView(string breadCumValue, long thirdPartyChequeId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = thirdPartyChequeId > 0 ? "true" : "false";

            ThirdPartyChequeViewModel thirdPartyChequeViewModel = new ThirdPartyChequeViewModel();

            if (thirdPartyChequeId > 0) {
                thirdPartyChequeViewModel = _mapper
                    .Map<ThirdPartyChequeViewModel>(_context.ThirdPartyCheque.SingleOrDefault(x => x.ThirdPartyChequeId == thirdPartyChequeId));
                 
            }
                

            thirdPartyChequeViewModel.ChequeStatusesVm = _mapper.Map<List<ChequeStatusViewModel>>(_context.ChequeStatus.ToList());
            thirdPartyChequeViewModel.BankList = _context.ThirdPartyCheque.Select(x => x.Bank).Distinct().ToList();
            thirdPartyChequeViewModel.BranchList = _context.ThirdPartyCheque.Select(x => x.Branch).Distinct().ToList();

            thirdPartyChequeViewModel.CustomerList = _context.Customers.Where(s => s.CurrentStatus == 1).Select(x => new Customer() {
                CustomerId = x.CustomerId, CustomerName = x.CustomerName
            }).ToList();            
            thirdPartyChequeViewModel.SupplierList = _context.Supplier.Where(s => s.CurrentStatus == 1).Select(x => new Supplier() {
                SupplierId = x.SupplierId, SupplierName = x.SupplierName
            }).ToList();

            return View(thirdPartyChequeViewModel);
        }
    }
}