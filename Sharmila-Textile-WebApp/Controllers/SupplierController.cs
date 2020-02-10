using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
    public class SupplierController : Controller {
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

        public IActionResult SupplierView() {
            var data = from a in _context.Supplier
                       join b in _context.User on a.CreatedBy equals b.UserId where a.CurrentStatus == 1
                       select new SupplierViewModel {
                           SupplierId = a.SupplierId, SupplierName = a.SupplierName, Address = a.Address, Landline = a.Landline, 
                           Mobile = a.Mobile, OpeningBalance = a.OpeningBalance,
                           CurrentBalance = a.CurrentBalance, CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy, CurrentStatus = a.CurrentStatus,
                           UserName = b.UserName
                       };
            return View(data);
        }

        [Obsolete]
        public IActionResult SupplierDetailView(string breadCumValue, int supplierId) {
            ViewBag.breadcumValue = breadCumValue;
            ViewBag.IsUpdate = supplierId > 0 ? "true" : "false";

            if (supplierId > 0) {
                Supplier supplier = _context.Supplier.FirstOrDefault(x => x.SupplierId == supplierId);
                List<SupplierAttachment> supplierAttachments =
                    _context.SupplierAttachment.Where(x => x.SupplierId == supplierId).ToList();

                SupplierViewModel model = _mapper.Map<SupplierViewModel>(supplier);

                List<SupplierAttachmentViewModel> supplierAttachmentViewModelList = new List<SupplierAttachmentViewModel>();
                foreach (var item in supplierAttachments) {
                    SupplierAttachmentViewModel supplierAttachmentViewModel = new SupplierAttachmentViewModel {
                        SupplierId = item.SupplierId,
                        AttachmentName = item.AttachmentName,
                        AttachmentRandomName = item.AttachmentPath
                    };

                    string path = _hostingEnvironment.WebRootPath + @"\files\" + item.AttachmentPath;
                    byte[] data = System.IO.File.ReadAllBytes(path);
                    supplierAttachmentViewModel.AttachmentFile = item.MimeType + "," + Convert.ToBase64String(data);
                    supplierAttachmentViewModelList.Add(supplierAttachmentViewModel);
                }

                model.SupplierAttachmentList = supplierAttachmentViewModelList;
                return View(model);
            }
            return View();
        }
    }
}