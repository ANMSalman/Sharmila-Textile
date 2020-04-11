using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.ApiController {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public DashboardController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult CollectionPending() {
            var result = _context.Customers.Where(x => x.CurrentStatus == 1).Sum(s => s.CurrentBalance);
            return Ok(result);
        }

        public IActionResult PaymentPending() {
            var result = _context.Suppliers.Where(x => x.CurrentStatus == 1).Sum(s => s.CurrentBalance);
            return Ok(result);
        }

        public IActionResult InHandTotalCash() {
            var result = _context.BalanceSheets.Select(x => x.InHandCash).SingleOrDefault();
            return Ok(result);
        }

        public IActionResult InHandTotalCheque() {
            var result = _context.BalanceSheets.Select(x => x.InHandCheque).SingleOrDefault();
            return Ok(result);
        }

        public IActionResult CurrentBankBalance() {
            var result = _context.BalanceSheets.Select(x => x.BankBalance).SingleOrDefault();
            return Ok(result);
        }

        public IActionResult AverageBusiness() {
            var data = _context.Summaries
                .Where(a => a.Date.Date >= DateTime.Now.Date && a.Date.Date <= DateTime.Now.AddMonths(1).Date && a.Status == 1)
                .Select(k => new { k.Date.Day, k.TotalAmount })
                .GroupBy(x => new { x.Day }, (key, group) => new { day = key.Day, total = group.Sum(k => k.TotalAmount) })
                .ToList();

            return Ok(data);
        }

        public IActionResult PaymentTrend() {
            var data = _context.Summaries
                .Where(a => a.Date.Date >= DateTime.Now.Date && a.Date.Date <= DateTime.Now.AddMonths(1).Date && a.Status == 1)
                .Select(k => new { k.Date.Day, k.TotalPayment, k.AccountablePayment })
                .GroupBy(x => new { x.Day }, (key, group) => new { day = key.Day, total = group.Sum(k => k.TotalPayment), accountable = group.Sum(k => k.AccountablePayment) })
                .ToList();

            return Ok(data);
        }

        public IActionResult CollectionTrend() {
            var data = _context.Summaries
                .Where(a => a.Date.Date >= DateTime.Now.Date && a.Date.Date <= DateTime.Now.AddMonths(1).Date && a.Status == 1)
                .Select(k => new { k.Date.Day, k.TotalCollection, k.AccountableCollection })
                .GroupBy(x => new { x.Day }, (key, group) => new { day = key.Day, total = group.Sum(k => k.TotalCollection), accountable = group.Sum(k => k.AccountableCollection) })
                .ToList();

            return Ok(data);
        }

        public IActionResult ExpenseTrend() {
            var data = _context.Summaries
                .Where(a => a.Date.Date >= DateTime.Now.Date && a.Date.Date <= DateTime.Now.AddMonths(1).Date && a.Status == 1)
                .Select(k => new { k.Date.Day, k.TotalExpense, k.AccountableExpense })
                .GroupBy(x => new { x.Day }, (key, group) => new { day = key.Day, total = group.Sum(k => k.TotalExpense), accountable = group.Sum(k => k.AccountableExpense) })
                .ToList();

            return Ok(data);
        }

        public IActionResult UpcomingOwnCheque() {
            var today = DateTime.Today;
            var data = _context.OwnCheques
                .Where(x => x.Status == 1 && x.DueDate.Date >= today && x.DueDate.Date < today.AddDays(30)).Select(
                    x => new OwnChequeViewModel {
                        OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Bank = x.Bank, Branch = x.Branch, Amount = x.Amount, Date = x.Date, DueDate = x.DueDate
                    }).ToList();

            return Ok(data);
        }

        public IActionResult AgingCustomers() {
            var data = (from a in _context.Customers
                join b in _context.Users on a.CreatedBy equals b.UserId where a.CurrentStatus == 1 orderby a.LastCollectionDate
                select new CustomerViewModel {
                    CustomerId = a.CustomerId, CustomerName = a.CustomerName, NIC = a.NIC, HomeAddress = a.HomeAddress, HomeLandline = a.HomeLandline,
                    OfficeAddress = a.OfficeAddress, OfficeLandline = a.OfficeLandline, Mobile = a.Mobile, OpeningBalance = a.OpeningBalance, CurrentBalance = a.CurrentBalance,
                    CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy, CurrentStatus = a.CurrentStatus, LastCollectionDate = a.LastCollectionDate, UserName = b.UserName
                }).ToList() ;


            return Ok(data);
        }



    }
}