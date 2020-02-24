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
    public class OwnChequeController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public OwnChequeController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OwnChequeList() {
            List<OwnChequeViewModel> data = (from a in _context.OwnCheques
                                             join b in _context.ChequeStatuses on a.Status equals b.ChequeStatusId
                                             select new OwnChequeViewModel {
                                                 OwnChequeId = a.OwnChequeId, ChequeCode = a.ChequeCode, Bank = a.Bank, Branch = a.Branch, Amount = a.Amount,
                                                 DueDate = a.DueDate, StatusId = b.ChequeStatusId, Status = b.StatusName, Remark = a.Remark
                                             }).ToList();

            return View(data);
        }

        public IActionResult OwnChequeDetailView(string breadCumValue, long ownChequeId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = ownChequeId > 0 ? "true" : "false";

            OwnChequeViewModel ownChequeViewModel = new OwnChequeViewModel();

            if (ownChequeId > 0)
                ownChequeViewModel = _mapper.Map<OwnChequeViewModel>(_context.OwnCheques.SingleOrDefault(x => x.OwnChequeId == ownChequeId));

            ownChequeViewModel.ChequeStatusesVm = _mapper.Map<List<ChequeStatusViewModel>>(_context.ChequeStatuses.ToList());
            ownChequeViewModel.BankList = _context.OwnCheques.Select(x => x.Bank).Distinct().ToList();
            ownChequeViewModel.BranchList = _context.OwnCheques.Select(x => x.Branch).Distinct().ToList();

            return View(ownChequeViewModel);
        }
    }
}