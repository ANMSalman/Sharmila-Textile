using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.ApiController {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public LoginController(AppDBContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{username}/{password}")]
        public IActionResult ValidateLogin(string username, string password) {
            var data = _context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (data != null) {
                HttpContext.Session.SetString("loggedIn", "true");
            }
            var d = HttpContext.Session.GetString("loggedIn");

            return data != null ? Ok(data.UserId) : Ok("Invalid Username Password");
        }
    }
}