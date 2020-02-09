using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.HtmlEntities;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.ApiController {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;


        public StaffController(AppDBContext context, IMapper mapper, IHostingEnvironment hostingEnvironment) {
            _context = context;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult Create(StaffViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            /**************** Saving Staffs **************/
            Staff staff = _mapper.Map<Staff>(model);
            staff.CurrentStatus = 1;

            _context.Staff.Add(staff);
            var flag = _context.SaveChanges();
            var staffId = staff.StaffId;


            if (flag > 0) {
                /**************** Creating Staff Attachments and Saving **************/
                Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
                IList<StaffAttachmentViewModel> staffAttachmentlList = model.StaffAttachmentList;
                foreach (var item in staffAttachmentlList) {
                    string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                    string base64 = item.AttachmentFile.Substring(item.AttachmentFile.IndexOf(',') + 1);
                    byte[] data = Convert.FromBase64String(base64);
                    string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                    System.IO.File.WriteAllBytes(path, data.ToArray());
                    StaffAttachment staffAttachment = new StaffAttachment() {
                        AttachmentName = item.AttachmentName,
                        AttachmentPath = randName,
                        StaffId = staffId,
                        MimeType = item.AttachmentFile.Split(",")[0]
                    };
                    _context.StaffAttachment.Add(staffAttachment);
                    _context.SaveChanges();
                }

                /**************** Saving User **************/
                if (model.UserViewModel.CurrentStatus == 1) {
                    User userModel = _mapper.Map<User>(model.UserViewModel);
                    userModel.StaffId = staffId;

                    _context.User.Add(userModel);
                    _context.SaveChanges();
                }
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost]
        public IActionResult Update(StaffViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }


            /**************** Updating Staffs **************/

            var single = _context.Staff.Single(x => x.StaffId == model.StaffId);
            single.StaffName = model.StaffName;
            single.Nic = model.Nic;
            single.ContactNo = model.ContactNo;
            single.Address = model.Address;

            var flag = _context.SaveChanges();
            var staffId = single.StaffId;


            /**************** Updating Staff Attachments and Saving **************/
            DeleteFiles(model.StaffId);
            Miscellaneous.CreateFolder(_hostingEnvironment.WebRootPath + @"\files");
            IList<StaffAttachmentViewModel> staffAttachmentlList = model.StaffAttachmentList;
            foreach (var item in staffAttachmentlList) {
                string randName = DateTime.Now.ToString("MMddyyyyhhmmssfff") + "_" + new Random().Next(0, 10000).ToString("D6") + "_" + item.AttachmentName;
                string base64 = item.AttachmentFile.Split(",")[1];
                byte[] data = Convert.FromBase64String(base64);
                string path = _hostingEnvironment.WebRootPath + @"\files\" + randName;
                System.IO.File.WriteAllBytes(path, data.ToArray());
                StaffAttachment staffAttachment = new StaffAttachment() {
                    AttachmentName = item.AttachmentName,
                    AttachmentPath = randName,
                    StaffId = staffId,
                    MimeType = item.AttachmentFile.Split(",")[0]
                };
                _context.StaffAttachment.Add(staffAttachment);
                _context.SaveChanges();
            }

            /**************** Updating User **************/
            if (model.UserViewModel.CurrentStatus == 1) {

                if (_context.User.Count(x => x.UserId == model.UserViewModel.UserId) > 0) {
                    var user = _context.User.Single(x => x.UserId == model.UserViewModel.UserId);
                    user.UserName = model.UserViewModel.UserName;
                    user.Password = model.UserViewModel.Password;
                    user.CurrentStatus = model.UserViewModel.CurrentStatus;

                } else {
                    User userModel = _mapper.Map<User>(model.UserViewModel);
                    userModel.StaffId = staffId;
                    _context.User.Add(userModel);
                }

                _context.SaveChanges();

            } else {
                if (_context.User.Count(x => x.UserId == model.UserViewModel.UserId) > 0) {
                    var user = _context.User.Single(x => x.UserId == model.UserViewModel.UserId);
                    user.CurrentStatus = 0;
                    _context.SaveChanges();

                }

            }

            return Ok(true);
        }

        [HttpGet("{id}")]
        public IActionResult Delete(long id) {
            var staff = _context.Staff.Single(x => x.StaffId == id);
            staff.CurrentStatus = 0;
            int flag = _context.SaveChanges();

            return Ok(flag > 0);
        }

        private void DeleteFiles(long staffId) {
            string rootFolder = _hostingEnvironment.WebRootPath + @"\files\";

            IEnumerable<StaffAttachment> staffAttachments = _context.StaffAttachment.Where(x => x.StaffId == staffId).ToList();
            _context.StaffAttachment.RemoveRange(staffAttachments);
            _context.SaveChanges();

            try {
                foreach (var item in staffAttachments) {
                    if (System.IO.File.Exists(Path.Combine(rootFolder, item.AttachmentPath))) {
                        System.IO.File.Delete(Path.Combine(rootFolder, item.AttachmentPath));
                        Console.WriteLine("File deleted.");
                    } else Console.WriteLine("File not found");
                }

            } catch (IOException ioExp) {
                Console.WriteLine(ioExp.Message);
            }
        }
         
    }
}