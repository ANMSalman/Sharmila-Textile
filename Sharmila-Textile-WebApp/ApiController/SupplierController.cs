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
    public class SupplierController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public SupplierController(AppDBContext context, IMapper mapper, IHostingEnvironment hostingEnvironment) {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(SupplierViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            /**************** Saving Suppliers **************/
            Supplier supplier = _mapper.Map<Supplier>(model);
            supplier.CurrentStatus = 1;
            supplier.CreatedDate = DateTime.Now;
            _context.Suppliers.Add(supplier);
            var flag = _context.SaveChanges();
            var supplierId = supplier.SupplierId;


            if (flag > 0) {
                /**************** Creating Supplier Attachments and Saving **************/
                Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
                IList<SupplierAttachmentViewModel> supplierAttachmentList = model.SupplierAttachmentList;
                foreach (var item in supplierAttachmentList) {
                    string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                    string base64 = item.AttachmentFile.Substring(item.AttachmentFile.IndexOf(',') + 1);
                    byte[] data = Convert.FromBase64String(base64);
                    string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                    System.IO.File.WriteAllBytes(path, data.ToArray());
                    SupplierAttachment supplierAttachment = new SupplierAttachment() {
                        AttachmentName = item.AttachmentName,
                        AttachmentPath = randName,
                        SupplierId = supplierId,
                        MimeType = item.AttachmentFile.Split(",")[0]
                    };
                    _context.SupplierAttachments.Add(supplierAttachment);
                    _context.SaveChanges();
                }
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Update(SupplierViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            /**************** Updating Suppliers **************/

            var single = _context.Suppliers.Single(x => x.SupplierId == model.SupplierId);
            single.SupplierName = model.SupplierName;
            single.Address = model.Address;
            single.Landline = model.Landline;
            single.Mobile = model.Mobile;
            single.OpeningBalance = model.OpeningBalance;
            single.CurrentBalance = model.CurrentBalance;

            var flag = _context.SaveChanges();
            var supplierId = single.SupplierId;

            /**************** Updating Suppliers Attachments and Saving **************/
            DeleteFiles(model.SupplierId);
            Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
            IList<SupplierAttachmentViewModel> supplierAttachmentList = model.SupplierAttachmentList;

            foreach (var item in supplierAttachmentList) {
                string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                string base64 = item.AttachmentFile.Split(",")[1];
                byte[] data = Convert.FromBase64String(base64);
                string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                System.IO.File.WriteAllBytes(path, data.ToArray());
                SupplierAttachment supplierAttachment = new SupplierAttachment() {
                    AttachmentName = item.AttachmentName,
                    AttachmentPath = randName,
                    SupplierId = supplierId,
                    MimeType = item.AttachmentFile.Split(",")[0]
                };
                _context.SupplierAttachments.Add(supplierAttachment);
                _context.SaveChanges();
            }

            return Ok(true);
        }

        [Obsolete]
        private void DeleteFiles(long supplierId) {
            string rootFolder = _hostingEnvironment.WebRootPath + @"\files\";

            IEnumerable<SupplierAttachment> supplierAttachments = _context.SupplierAttachments.Where(x => x.SupplierId == supplierId).ToList();
            _context.SupplierAttachments.RemoveRange(supplierAttachments);
            _context.SaveChanges();

            try {
                foreach (var item in supplierAttachments) {
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
            var model = _context.Suppliers.Single(x => x.SupplierId == id);
            model.CurrentStatus = 0;
            int flag = _context.SaveChanges();

            return Ok(flag > 0);
        }
    }
}