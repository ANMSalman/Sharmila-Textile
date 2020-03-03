using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;

namespace Sharmila_Textile_WebApp.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public DashboardController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult CollectionPending() {
            Thread.Sleep(1500);
            var result = _context.Customers.Where(x => x.CurrentStatus == 1).Sum(s => s.CurrentBalance);
            return Ok(result);
        }

        public IActionResult PaymentPending() {
            Thread.Sleep(1000);
            var result = _context.Suppliers.Where(x => x.CurrentStatus == 1).Sum(s => s.CurrentBalance); 
            return Ok(result);
        }

        public IActionResult InHandTotalCash() {
            Thread.Sleep(500);
            var result = _context.BalanceSheets.Select(x=>x.InHandCash).SingleOrDefault();
            return Ok(result);
        }

        public IActionResult InHandTotalCheque() {
            Thread.Sleep(1000);
            var result = _context.BalanceSheets.Select(x => x.InHandCheque).SingleOrDefault();
            return Ok(result);
        }

        public IActionResult CurrentBankBalance() {
            Thread.Sleep(1000);
            var result = _context.BalanceSheets.Select(x => x.BankBalance).SingleOrDefault();
            return Ok(result);
        }
    }
}