using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.Controllers {
    public class StaffController : Controller {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public StaffController(AppDBContext context, IMapper mapper, IHostingEnvironment hostingEnvironment) {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult StaffView() {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            List<StaffViewModel> list = _mapper.Map<List<StaffViewModel>>(_context.Staffs.Where(x=>x.CurrentStatus == 1).ToList());
            return View(list);
        }

        [Obsolete]
        public IActionResult StaffDetailView(string breadCumValue, int staffId) {
            if (HttpContext.Session.GetString("loggedIn") == null || HttpContext.Session.GetString("loggedIn") == "false") {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.breadcumValue = breadCumValue;
            ViewBag.IsUpdate = staffId > 0 ? "true":"false";

            if (staffId > 0) {
                Staff staff = _context.Staffs.FirstOrDefault(x => x.StaffId == staffId);
                User user = _context.Users.FirstOrDefault(x => x.StaffId == staffId);
                List<StaffAttachment> staffAttachments =
                    _context.StaffAttachments.Where(x => x.StaffId == staffId).ToList();

                StaffViewModel model = _mapper.Map<StaffViewModel>(staff);
                model.UserViewModel = _mapper.Map<UserViewModel>(user);

                List<StaffAttachmentViewModel> stfList = new List<StaffAttachmentViewModel>(); 
                foreach (var item in staffAttachments) {
                    StaffAttachmentViewModel stfAttachmentViewModel = new StaffAttachmentViewModel {
                        StaffId = item.StaffId,
                        AttachmentName = item.AttachmentName,
                        AttachmentRandomName = item.AttachmentPath
                    };

                    string path = _hostingEnvironment.WebRootPath + @"\files\" + item.AttachmentPath;
                    byte[] data = System.IO.File.ReadAllBytes(path); 
                    stfAttachmentViewModel.AttachmentFile = item.MimeType + "," + Convert.ToBase64String(data);
                    stfList.Add(stfAttachmentViewModel);
                }

                model.StaffAttachmentList = stfList;
                return View(model);
            }

            return View();
        }
 

    }
}
