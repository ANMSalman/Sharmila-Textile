using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.HtmlEntities;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.ApiController {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public CustomerController(AppDBContext context, IMapper mapper, IHostingEnvironment hostingEnvironment) {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(CustomerViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            /**************** Saving Customer **************/
            Customer customer = _mapper.Map<Customer>(model);
            customer.CurrentStatus = 1;
            customer.CreatedDate= DateTime.Now;
            _context.Customers.Add(customer);
            var flag = _context.SaveChanges();
            var customerId = customer.CustomerId;


            if (flag > 0) {
                /**************** Creating Customer Attachments and Saving **************/
                Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
                IList<CustomerAttachmentViewModel> customerAttachmentList = model.CustomerAttachmentList;
                foreach (var item in customerAttachmentList) {
                    string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                    string base64 = item.AttachmentFile.Substring(item.AttachmentFile.IndexOf(',') + 1);
                    byte[] data = Convert.FromBase64String(base64);
                    string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                    System.IO.File.WriteAllBytes(path, data.ToArray());
                    CustomerAttachment customerAttachment = new CustomerAttachment() {
                        AttachmentName = item.AttachmentName,
                        AttachmentPath = randName,
                        CustomerId = customerId,
                        MimeType = item.AttachmentFile.Split(",")[0]
                    };
                    _context.CustomerAttachments.Add(customerAttachment);
                    _context.SaveChanges();
                } 
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(CustomerViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            /**************** Updating Customer **************/

            var single = _context.Customers.Single(x => x.CustomerId == model.CustomerId);
            single.CustomerName = model.CustomerName;
            single.NIC = model.NIC;
            single.HomeAddress = model.HomeAddress;
            single.HomeLandline = model.HomeLandline;
            single.OfficeAddress = model.OfficeAddress;
            single.OfficeLandline = model.OfficeLandline;
            single.Mobile = model.Mobile;
            single.OpeningBalance = model.OpeningBalance;
            single.CurrentBalance = model.CurrentBalance; 
            single.LastCollectionDate = model.LastCollectionDate; 

            var flag = _context.SaveChanges();
            var cusId = single.CustomerId;


            /**************** Updating Customer Attachments and Saving **************/
            DeleteFiles(model.CustomerId);
            Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
            IList<CustomerAttachmentViewModel> customerAttachmentList = model.CustomerAttachmentList;

            foreach (var item in customerAttachmentList) {
                string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                string base64 = item.AttachmentFile.Split(",")[1];
                byte[] data = Convert.FromBase64String(base64);
                string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                System.IO.File.WriteAllBytes(path, data.ToArray());
                CustomerAttachment customerAttachment = new CustomerAttachment() {
                    AttachmentName = item.AttachmentName,
                    AttachmentPath = randName,
                    CustomerId = cusId,
                    MimeType = item.AttachmentFile.Split(",")[0]
                };
                _context.CustomerAttachments.Add(customerAttachment);
                _context.SaveChanges();
            } 

            return Ok(true);
        }

        private void DeleteFiles(long customerId) {
            string rootFolder = _hostingEnvironment.WebRootPath + @"\files\";

            IEnumerable<CustomerAttachment> customerAttachments = _context.CustomerAttachments.Where(x => x.CustomerId == customerId).ToList();
            _context.CustomerAttachments.RemoveRange(customerAttachments);
            _context.SaveChanges();

            try {
                foreach (var item in customerAttachments) {
                    if (System.IO.File.Exists(Path.Combine(rootFolder, item.AttachmentPath))) {
                        System.IO.File.Delete(Path.Combine(rootFolder, item.AttachmentPath));
                        Console.WriteLine("File deleted.");
                    }
                    else Console.WriteLine("File not found");
                }

            }
            catch (IOException ioExp) {
                Console.WriteLine(ioExp.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {
            var model = _context.Customers.Single(x => x.CustomerId == id);
            model.CurrentStatus = 0;
            int flag = _context.SaveChanges();

            return Ok(flag > 0);
        }

    }
}