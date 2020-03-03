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
    public class SupplierPaymentController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SupplierPaymentController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult PaymentListView() {
            var data = (from a in _context.SupplierPayments
                        join b in _context.ChequeStatuses on a.PaymentType equals b.ChequeStatusId
                        join c in _context.Suppliers on a.SupplierId equals c.SupplierId
                        join d in _context.Users on a.CreatedBy equals d.UserId
                        join e in _context.Staffs on d.StaffId equals e.StaffId
                        where a.Status == 1
                        select new SupplierPaymentViewModel {
                            SupplierPaymentId = a.SupplierPaymentId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque, Returns = a.Returns,
                            Purchase = a.Purchase, TotalAmount = a.TotalAmount, Date = a.Date, CreatedDate = a.CreatedDate, PaymentType = a.PaymentType,
                            PaymentTypeName = b.StatusName, SupplierId = a.SupplierId, SupplierName = c.SupplierName, CreatedBy = a.CreatedBy,
                            UserName = e.StaffName, Remark = a.Remark
                        }).ToList();

            return View(data);
        }

        public IActionResult PaymentDetailView(string breadCumValue, long paymentId) {
            ViewBag.breadCumValue = breadCumValue;
            ViewBag.IsUpdate = paymentId > 0 ? "true" : "false";


            SupplierPaymentViewModel supplierPaymentViewModel = new SupplierPaymentViewModel();

            if (paymentId > 0) {
                supplierPaymentViewModel = (from a in _context.SupplierPayments where a.SupplierPaymentId == paymentId
                               select new SupplierPaymentViewModel {
                                   SupplierPaymentId = a.SupplierPaymentId, Description = a.Description, Cash = a.Cash, Cheque = a.Cheque, 
                                   Returns = a.Returns, Purchase = a.Purchase, TotalAmount = a.TotalAmount, PaymentType = a.PaymentType,
                                   SupplierId = a.SupplierId, CreatedBy = a.CreatedBy, Remark = a.Remark, Date = a.Date,
                                   OwnChequesId = a.SupplierPaymentOwnCheques.Select(cid => cid.OwnChequeId).ToList(),
                                   ThirdPartyChequesId = a.SupplierPaymentThirdPartyCheques.Select(cid => cid.ThirdPartyChequeId).ToList()
                               }).Single();
            }

            supplierPaymentViewModel.PaymentTypeList = _mapper.Map<List<ChequeStatusViewModel>>(_context.ChequeStatuses.Where(x => x.StatusType.Contains("PC")).ToList());
            supplierPaymentViewModel.SupplierList = _context.Suppliers.Where(s => s.CurrentStatus == 1).Select(x => new Supplier() {
                SupplierId = x.SupplierId, SupplierName = x.SupplierName
            }).ToList();
            supplierPaymentViewModel.OwnChequesList = _context.OwnCheques.Select(x => new OwnCheque() {
                OwnChequeId = x.OwnChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();
            supplierPaymentViewModel.ThirdPartyChequesList = _context.ThirdPartyCheques.Select(x => new ThirdPartyCheque() {
                ThirdPartyChequeId = x.ThirdPartyChequeId, ChequeCode = x.ChequeCode, Amount = x.Amount
            }).ToList();

            return View(supplierPaymentViewModel);
        }
    }
}