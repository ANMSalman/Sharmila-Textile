using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.ApiController {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SummaryController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SummaryController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(SummaryViewModel model) {

            var summary = _mapper.Map<Summary>(model);
            summary.CreatedDate = DateTime.Now;
            summary.Status = 1;

            _context.Summaries.Add(summary);

            var balanceSheet = _context.BalanceSheets.SingleOrDefault(x => x.BalanceSheetId == 1);
            if (balanceSheet != null) balanceSheet.InHandCash += summary.CashBalance;

            var flag = _context.SaveChanges();

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {

            var single = _context.Summaries.Single(x => x.SummaryId == id);
            single.Status = 0;

            var flag = _context.SaveChanges();
            return Ok(flag > 0);
        }
    }
}