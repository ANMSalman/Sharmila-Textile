using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class OwnChequeController : ControllerBase {

        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public OwnChequeController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Create(OwnChequeViewModel model) {
            
            OwnCheque ownCheque = _mapper.Map<OwnCheque>(model);
            OwnChequeActionLog actionLog = model.ActionLog;
            actionLog.OwnCheque = ownCheque;

            _context.OwnChequeActionLog.Add(actionLog);
            var flag = _context.SaveChanges();

            return Ok(flag > 0);
        }

        public IActionResult Update(OwnChequeViewModel model) {

            OwnCheque ownCheque = _mapper.Map<OwnCheque>(model);
            _context.OwnCheque.Update(ownCheque);
//            _context.SaveChanges();

            OwnChequeActionLog actionLog = model.ActionLog;
            actionLog.OwnChequeId = model.OwnChequeId;
            _context.OwnChequeActionLog.Add(actionLog);
            var flag = _context.SaveChanges();
            return Ok(flag > 0);
        }
    }
}