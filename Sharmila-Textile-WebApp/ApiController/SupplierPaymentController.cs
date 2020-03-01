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
    public class SupplierPaymentController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SupplierPaymentController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Create(SupplierPaymentViewModel model) {

            SupplierPayment supplierPayment = _mapper.Map<SupplierPayment>(model);
            supplierPayment.CreatedDate = DateTime.Now;
            supplierPayment.Status = 1;

            var supplierPaymentOwnCheques = new List<SupplierPaymentOwnCheque>();
            var supplierPaymentThirdPartyCheque = new List<SupplierPaymentThirdPartyCheque>();
            model.OwnChequesId.ForEach(item => {
                supplierPaymentOwnCheques.Add(new SupplierPaymentOwnCheque() { OwnChequeId = item });
            });
            model.ThirdPartyChequesId.ForEach(item => {
                supplierPaymentThirdPartyCheque.Add(new SupplierPaymentThirdPartyCheque() { ThirdPartyChequeId = item });
            });

            supplierPayment.SupplierPaymentOwnCheques = supplierPaymentOwnCheques;
            supplierPayment.SupplierPaymentThirdPartyCheques = supplierPaymentThirdPartyCheque;

            _context.SupplierPayments.Add(supplierPayment);

            var balanceSheets = _context.BalanceSheets.SingleOrDefault(c => c.BalanceSheetId == 1);
            if (balanceSheets != null) balanceSheets.InHandCash -= supplierPayment.InHandCash;

            var flag = _context.SaveChanges();
            var paymentId = supplierPayment.SupplierPaymentId;
             
            if (flag > 0) {
                var single = _context.Suppliers.Single(x => x.SupplierId == model.SupplierId);
                single.CurrentBalance -= model.TotalAmount;
                _context.SaveChanges();
            }

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id, long supplierId, string remark, decimal totalAmount) {

            var singleSupplier = _context.Suppliers.Single(x => x.SupplierId == supplierId);
            singleSupplier.CurrentBalance += totalAmount;

            var singlePayment = _context.SupplierPayments.Single(x => x.SupplierPaymentId == id);
            singlePayment.Status = 0;

            int flag = _context.SaveChanges();
            return Ok(flag > 0);
        }

    }
}