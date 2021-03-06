﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class CustomerAccountController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CustomerAccountController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(CustomerAccountViewModel model) {

            var customerAccount = _mapper.Map<CustomerAccount>(model);
            customerAccount.CreatedDate = DateTime.Now;
            customerAccount.Status = 1;

            var customerAccountOwnCheques = new List<CustomerAccountOwnCheque>();
            var customerAccountThirdPartyCheques = new List<CustomerAccountThirdPartyCheque>();
            model.OwnChequesId.ForEach(item => {
                customerAccountOwnCheques.Add(new CustomerAccountOwnCheque() { OwnChequeId = item });
            });
            model.ThirdPartyChequesId.ForEach(item => {
                customerAccountThirdPartyCheques.Add(new CustomerAccountThirdPartyCheque() { ThirdPartyChequeId = item });
            });

            customerAccount.CustomerAccountOwnCheques = customerAccountOwnCheques;
            customerAccount.CustomerAccountThirdPartyCheques = customerAccountThirdPartyCheques;

            _context.CustomerAccounts.Add(customerAccount);

            var balanceSheets = _context.BalanceSheets.SingleOrDefault(c => c.BalanceSheetId == 1);
            if (balanceSheets != null) balanceSheets.InHandCash -= customerAccount.InHandCash;


            var flag = _context.SaveChanges();
            var lastId = customerAccount.CustomerAccountId;

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {

            var single = _context.CustomerAccounts.Single(x => x.CustomerAccountId == id);
            single.Status = 0;

            var flag = _context.SaveChanges();
            return Ok(flag > 0);
        }

        [HttpGet("{id}/{skip}")]
        public IActionResult GetList(long id, int skip) {
            Thread.Sleep(500);
            var data =
                _context.CustomerAccounts.Where(x => x.Status == 1 && x.CustomerId == id)
                    .Select(f => new CustomerAccountViewModel {
                        CustomerAccountId = f.CustomerAccountId, Date = f.Date, AccountType = f.AccountType, Amount = f.Amount
                    }).Skip(skip).Take(50).OrderByDescending(c => c.Date).ToList();

            return Ok(data);
        }
    }
}