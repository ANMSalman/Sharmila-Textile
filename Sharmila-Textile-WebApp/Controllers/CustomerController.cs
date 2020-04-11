using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
    public class CustomerController : Controller {
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

        public IActionResult CustomerView() {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }

            var data = from a in _context.Customers
                       join b in _context.Users on a.CreatedBy equals b.UserId where a.CurrentStatus == 1
                       select new CustomerViewModel {
                           CustomerId = a.CustomerId, CustomerName = a.CustomerName, NIC = a.NIC, HomeAddress = a.HomeAddress, HomeLandline = a.HomeLandline,
                           OfficeAddress = a.OfficeAddress, OfficeLandline = a.OfficeLandline, Mobile = a.Mobile, OpeningBalance = a.OpeningBalance, CurrentBalance = a.CurrentBalance,
                           CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy, CurrentStatus = a.CurrentStatus, LastCollectionDate = a.LastCollectionDate, UserName = b.UserName
                       };

            return View(data);
        }

        [Obsolete]
        public IActionResult CustomerDetailView(string breadCumValue, int cusId) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.breadcumValue = breadCumValue;
            ViewBag.IsUpdate = cusId > 0 ? "true" : "false";

            ViewBag.isCollectionExist = _context.Collections.Count(x => x.CustomerId == cusId) > 0;

            if (cusId > 0) {
                Customer customer = _context.Customers.FirstOrDefault(x => x.CustomerId == cusId);
                List<CustomerAttachment> customerAttachments =
                    _context.CustomerAttachments.Where(x => x.CustomerId == cusId).ToList();

                CustomerViewModel model = _mapper.Map<CustomerViewModel>(customer);

                List<CustomerAttachmentViewModel> cstAtchList = new List<CustomerAttachmentViewModel>();
                foreach (var item in customerAttachments) {
                    CustomerAttachmentViewModel customerAttachmentViewModel = new CustomerAttachmentViewModel {
                        CustomerId = item.CustomerId,
                        AttachmentName = item.AttachmentName,
                        AttachmentRandomName = item.AttachmentPath
                    };

                    string path = _hostingEnvironment.WebRootPath + @"\files\" + item.AttachmentPath;
                    byte[] data = System.IO.File.ReadAllBytes(path);
                    customerAttachmentViewModel.AttachmentFile = item.MimeType + "," + Convert.ToBase64String(data);
                    cstAtchList.Add(customerAttachmentViewModel);
                }

                model.CustomerAttachmentList = cstAtchList;
                return View(model);
            }
            return View();
        }

        public IActionResult CustomerInfoView(string breadCumValue, int cusId) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.breadcumValue = breadCumValue;

            var data = (from a in _context.Customers
                        join b in _context.Users on a.CreatedBy equals b.UserId
                        join c in _context.Staffs on b.StaffId equals c.StaffId
                        where a.CurrentStatus == 1 && a.CustomerId == cusId
                        select new CustomerViewModel {
                            CustomerId = a.CustomerId, CustomerName = a.CustomerName, NIC = a.NIC, HomeAddress = a.HomeAddress, HomeLandline = a.HomeLandline,
                            OfficeAddress = a.OfficeAddress, OfficeLandline = a.OfficeLandline, Mobile = a.Mobile, OpeningBalance = a.OpeningBalance,
                            CurrentBalance = a.CurrentBalance, CreatedDate = a.CreatedDate, CreatedBy = a.CreatedBy, CurrentStatus = a.CurrentStatus,
                            UserName = c.StaffName
                        }).SingleOrDefault();
            return View(data);
        }
    }
}