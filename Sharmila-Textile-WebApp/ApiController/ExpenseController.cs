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
    public class ExpenseController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public ExpenseController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(ExpenseViewModel model) {

            Expense expense = _mapper.Map<Expense>(model);
            expense.CreatedDate = DateTime.Now;
            expense.Status = 1;

            var expenseOwnCheques = new List<ExpenseOwnCheque>();
            var expenseThirdPartyCheques = new List<ExpenseThirdPartyCheque>();
            model.OwnChequesId.ForEach(item => {
                expenseOwnCheques.Add(new ExpenseOwnCheque() { OwnChequeId = item });
            });
            model.ThirdPartyChequesId.ForEach(item => {
                expenseThirdPartyCheques.Add(new ExpenseThirdPartyCheque() { ThirdPartyChequeId = item });
            });

            expense.ExpenseOwnCheques = expenseOwnCheques;
            expense.ExpenseThirdPartyCheques = expenseThirdPartyCheques;

            _context.Expenses.Add(expense);

            var balanceSheets = _context.BalanceSheets.SingleOrDefault(c => c.BalanceSheetId == 1);
            if (balanceSheets != null) balanceSheets.InHandCash -= expense.InHandCash;

            var flag = _context.SaveChanges();
            var colId = expense.ExpenseId;

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {
             
            var single = _context.Expenses.Single(x => x.ExpenseId == id);
            single.Status = 0;

            int flag = _context.SaveChanges();
            return Ok(flag > 0);
        }

    }
}