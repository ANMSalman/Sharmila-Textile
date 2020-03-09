using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;

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
    }
}