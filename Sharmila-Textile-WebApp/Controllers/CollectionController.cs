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
    public class CollectionController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CollectionController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult CollectionListView() {
            var data = (from a in _context.Collections
                        join b in _context.ChequeStatuses on a.CollectionType equals b.ChequeStatusId
                        join c in _context.Customers on a.CustomerId equals c.CustomerId
                        join d in _context.Users on a.CreatedBy equals d.UserId
                        join e in _context.Staffs on d.StaffId equals e.StaffId
                        where a.Status == 1
                        select new CollectionViewModel {
                            CollectionId = a.CollectionId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque, Returns = a.Returns,
                            TotalAmount = a.TotalAmount, CreatedDate = a.CreatedDate, CollectionType = a.CollectionType, Date = a.Date,
                            CollectionTypeName = b.StatusName, CustomerId = a.CustomerId, CustomerName = c.CustomerName, CreatedBy = a.CreatedBy,
                            UserName = e.StaffName, Remark = a.Remark
                        }).ToList();

            return View(data);
        }

        public IActionResult CollectionDetailView(string breadCumValue, long collectionId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = collectionId > 0 ? "true" : "false";


            CollectionViewModel collectionViewModel = new CollectionViewModel();

            if (collectionId > 0) {
                collectionViewModel = (from a in _context.Collections where a.CollectionId == collectionId
                                       select new CollectionViewModel {
                                           CollectionId = a.CollectionId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque,
                                           Returns = a.Returns, TotalAmount = a.TotalAmount, CollectionType = a.CollectionType,
                                           CustomerId = a.CustomerId, CreatedBy = a.CreatedBy, Remark = a.Remark, Date = a.Date,
                                           OwnChequesId = a.CollectionOwnCheques.Select(x => x.OwnChequeId).ToList(),
                                           ThirdPartyChequesId = a.CollectionThirdPartyCheques.Select(x => x.ThirdPartyChequeId).ToList()
                                       }).Single();
            }

            collectionViewModel.CollectionTypeList = _mapper.Map<List<ChequeStatusViewModel>>(_context.ChequeStatuses.Where(x => x.StatusType.Contains("PC")).ToList());
            collectionViewModel.CustomerList = _context.Customers.Where(s => s.CurrentStatus == 1).Select(x => new Customer() {
                CustomerId = x.CustomerId, CustomerName = x.CustomerName
            }).ToList();
            collectionViewModel.OwnChequesList = _context.OwnCheques.Select(x => new OwnCheque() {
                OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();
            collectionViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(collectionViewModel);
        }
    }
}