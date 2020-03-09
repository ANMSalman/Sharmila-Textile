using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
  
    public class BankDepositController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public BankDepositController(AppDBContext context, IMapper mapper) {
             
            _context = context;
            _mapper = mapper;
        } 
         

        public IActionResult BankDepositListView(string date) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            List<BankDepositViewModel> data;
            if (date != null) {
                data = (from a in _context.BankDeposits
                        join b in _context.Users on a.CreatedBy equals b.UserId
                        join c in _context.Staffs on b.StaffId equals c.StaffId
                        where a.Status == 1 && a.Date == Convert.ToDateTime(date)
                        select new BankDepositViewModel {
                            BankDepositId = a.BankDepositId, Cash = a.Cash, InHandCash = a.InHandCash, Date = a.Date, CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy,
                            UserName = c.StaffName
                        }).ToList();
            }
            else {

                data = (from a in _context.BankDeposits
                        join b in _context.Users on a.CreatedBy equals b.UserId
                        join c in _context.Staffs on b.StaffId equals c.StaffId
                        where a.Status == 1
                        select new BankDepositViewModel {
                            BankDepositId = a.BankDepositId, Cash = a.Cash, InHandCash = a.InHandCash, Date = a.Date, CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy,
                            UserName = c.StaffName
                        }).ToList();
            }

            return View(data);
        }

        public IActionResult BankDepositDetailView(string breadCumValue, long bankDepositId) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = bankDepositId > 0 ? "true" : "false";

            BankDepositViewModel bankDepositViewModel = new BankDepositViewModel();

            if (bankDepositId > 0) {
                bankDepositViewModel = (from a in _context.BankDeposits where a.BankDepositId == bankDepositId

                                        select new BankDepositViewModel() {
                                            BankDepositId = a.BankDepositId, Cash = a.Cash, InHandCash = a.InHandCash, Date = a.Date, CreatedBy = a.CreatedBy,
                                            ThirdPartyChequesId = a.BankDepositThirdPartyCheques.Select(x => x.ThirdPartyChequeId).ToList()
                                        }).Single();
                bankDepositViewModel.ChequeTotal = _context.ThirdPartyCheques
                    .Where(x => bankDepositViewModel.ThirdPartyChequesId.Contains(x.ThirdPartyChequeId)).Sum(s => s.Amount);
            }

            bankDepositViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(bankDepositViewModel);
        }
    }
}