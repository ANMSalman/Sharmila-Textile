﻿using System;
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
    public class ThirdPartyChequeController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public ThirdPartyChequeController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Create(ThirdPartyChequeViewModel model) {

            ThirdPartyCheque thirdPartyCheque = _mapper.Map<ThirdPartyCheque>(model);
            ThirdPartyChequeActionLog actionLog = model.ActionLog;
            actionLog.ThirdPartyCheque = thirdPartyCheque;
            _context.ThirdPartyChequeActionLogs.Add(actionLog);
            var flag = _context.SaveChanges();

            if (thirdPartyCheque.Status == 1) { // if cheque is in hand 
                var single = _context.BalanceSheets.Single(x => x.BalanceSheetId == 1);
                single.InHandCheque += thirdPartyCheque.Amount;
                flag = _context.SaveChanges();
            }

            if (thirdPartyCheque.Status == 5) { // if cheque is banked 
                var single = _context.BalanceSheets.Single(x => x.BalanceSheetId == 1);
                single.InHold += thirdPartyCheque.Amount;
                flag = _context.SaveChanges();
            }

            return Ok(flag > 0);
        }

        public IActionResult Update(ThirdPartyChequeViewModel model) {

            ThirdPartyCheque thirdPartyCheque = _mapper.Map<ThirdPartyCheque>(model);
            _context.ThirdPartyCheques.Update(thirdPartyCheque);
            //            _context.SaveChanges();

            ThirdPartyChequeActionLog actionLog = model.ActionLog;
            actionLog.ThirdPartyChequeId = model.ThirdPartyChequeId;
            _context.ThirdPartyChequeActionLogs.Add(actionLog);
            var flag = _context.SaveChanges();

            if (thirdPartyCheque.Status == 5) { // if cheque is banked 
                var single = _context.BalanceSheets.Single(x => x.BalanceSheetId == 1);
                single.InHold += thirdPartyCheque.Amount;
                flag = _context.SaveChanges();
            }

            if (thirdPartyCheque.Status == 6) { // if cheque is passed 
                var single = _context.BalanceSheets.Single(x => x.BalanceSheetId == 1);
                single.InHold -= thirdPartyCheque.Amount;
                single.BankBalance += thirdPartyCheque.Amount;
                flag = _context.SaveChanges();
            }

            if (thirdPartyCheque.Status == 2) { // if cheque is returned 
                var single = _context.BalanceSheets.Single(x => x.BalanceSheetId == 1);
                single.InHold -= thirdPartyCheque.Amount; 
                flag = _context.SaveChanges();
            }

            return Ok(flag > 0);
        }
    }
}