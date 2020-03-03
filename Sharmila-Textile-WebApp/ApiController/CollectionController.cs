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
    public class CollectionController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CollectionController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create(CollectionViewModel model) {

            Collection collection = _mapper.Map<Collection>(model);
            collection.CreatedDate = DateTime.Now;
            collection.Status = 1;

            var collectionOwnCheques = new List<CollectionOwnCheque>();
            var collectionThirdPartyCheques = new List<CollectionThirdPartyCheque>();
            model.OwnChequesId.ForEach(item => {
                collectionOwnCheques.Add(new CollectionOwnCheque() { OwnChequeId = item });
            });
            model.ThirdPartyChequesId.ForEach(item => {
                collectionThirdPartyCheques.Add(new CollectionThirdPartyCheque() { ThirdPartyChequeId = item });
            });

            collection.CollectionOwnCheques = collectionOwnCheques;
            collection.CollectionThirdPartyCheques = collectionThirdPartyCheques;

            _context.Collections.Add(collection);
            var flag = _context.SaveChanges();
            var colId = collection.CollectionId;

            if (flag > 0) {
                var single = _context.Customers.Single(x => x.CustomerId == model.CustomerId);
                single.CurrentBalance -= model.TotalAmount;
                _context.SaveChanges();
            }

            return Ok(flag > 0);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id, long cusId, string remark, decimal totalAmount) {

            var singleCustomer = _context.Customers.Single(x => x.CustomerId == cusId);
            singleCustomer.CurrentBalance += totalAmount;

            var singleCollection = _context.Collections.Single(x => x.CollectionId == id);
            singleCollection.Status = 0;

            int flag = _context.SaveChanges();
            return Ok(flag > 0);
        }

    }
}