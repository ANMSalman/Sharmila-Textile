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
    public class BankDepositController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public BankDepositController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(BankDepositViewModel model) {
            BankDeposit bankDeposit = _mapper.Map<BankDeposit>(model);
            bankDeposit.CreatedDate = DateTime.Now;
            bankDeposit.Status = 1;

            var bankDepositThirdPartyCheques = new List<BankDepositThirdPartyCheque>();
            model.ThirdPartyChequesId.ForEach(item => {
                bankDepositThirdPartyCheques.Add(new BankDepositThirdPartyCheque() { ThirdPartyChequeId = item });
            });
            bankDeposit.BankDepositThirdPartyCheques = bankDepositThirdPartyCheques;
            _context.BankDeposits.Add(bankDeposit);

            var balanceSheets = _context.BalanceSheets.SingleOrDefault(c => c.BalanceSheetId == 1);

            if (balanceSheets == null) return Ok();

            balanceSheets.InHandCash -= bankDeposit.InHandCash;
            balanceSheets.BankBalance += bankDeposit.Cash + bankDeposit.InHandCash;
            balanceSheets.InHold += model.ChequeTotal;

            var thirdPartyCheques = _context.ThirdPartyCheques.Where(x => model.ThirdPartyChequesId.Contains(x.ThirdPartyChequeId)).ToList();
            thirdPartyCheques.ForEach(x => x.Status = 5);

            _context.ThirdPartyCheques.UpdateRange(thirdPartyCheques);
            var flag = _context.SaveChanges();

            List<ThirdPartyChequeActionLog> actionLog = new List<ThirdPartyChequeActionLog>();
            thirdPartyCheques.ForEach(y => {
                actionLog.Add(new ThirdPartyChequeActionLog {
                    UserId = model.CreatedBy, ChequeStatusId = 5, ThirdPartyChequeId = y.ThirdPartyChequeId, ReferenceId = bankDeposit.BankDepositId
                });
            });
            _context.ThirdPartyChequeActionLogs.AddRange(actionLog);
            _context.SaveChanges();

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id, decimal cash, decimal inHandCash, decimal chequeTotal) {

            var bankDeposit = _context.BankDeposits.SingleOrDefault(x => x.BankDepositId == id);
            if (bankDeposit != null) {
                bankDeposit.Status = 0;

                var balanceSheets = _context.BalanceSheets.SingleOrDefault(c => c.BalanceSheetId == 1);

                if (balanceSheets != null) {
                    balanceSheets.InHandCash += inHandCash;
                    balanceSheets.BankBalance -= cash + inHandCash;
                    balanceSheets.InHold -= chequeTotal;
                    _context.BalanceSheets.Update(balanceSheets);
                }
                _context.BankDeposits.Update(bankDeposit);
            }

            var flag = _context.SaveChanges();

            return Ok(flag > 0);
        }


    }
}