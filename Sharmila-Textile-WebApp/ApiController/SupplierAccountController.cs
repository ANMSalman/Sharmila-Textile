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

namespace Sharmila_Textile_WebApp.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierAccountController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public SupplierAccountController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(SupplierAccountViewModel model) {

            var supplierAccount = _mapper.Map<SupplierAccount>(model);
            supplierAccount.CreatedDate = DateTime.Now;
            supplierAccount.Status = 1;

            var supplierAccountOwnCheques = new List<SupplierAccountOwnCheque>();
            var supplierAccountThirdPartyCheques = new List<SupplierAccountThirdPartyCheque>();
            model.OwnChequesId.ForEach(item => {
                supplierAccountOwnCheques.Add(new SupplierAccountOwnCheque() { OwnChequeId = item });
            });
            model.ThirdPartyChequesId.ForEach(item => {
                supplierAccountThirdPartyCheques.Add(new SupplierAccountThirdPartyCheque() { ThirdPartyChequeId = item });
            });

            supplierAccount.SupplierAccountOwnCheques = supplierAccountOwnCheques;
            supplierAccount.SupplierAccountThirdPartyCheques = supplierAccountThirdPartyCheques;

            _context.SupplierAccounts.Add(supplierAccount);
            var flag = _context.SaveChanges();
            var lastId = supplierAccount.SupplierAccountId;

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {

            var single = _context.SupplierAccounts.Single(x => x.SupplierAccountId == id);
            single.Status = 0;

            var flag = _context.SaveChanges();
            return Ok(flag > 0);
        }

        [HttpGet("{id}/{skip}")]
        public IActionResult GetList(long id, int skip) { 
            var data =
                _context.SupplierAccounts.Where(x => x.Status == 1 && x.SupplierId == id)
                    .Select(f => new SupplierAccountViewModel() {
                        SupplierAccountId = f.SupplierAccountId, Date = f.Date, AccountType = f.AccountType, Amount = f.Amount
                    }).Skip(skip).Take(50).OrderByDescending(c => c.Date).ToList();

            return Ok(data);
        }

    }
}