using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharmila_Textile_WebApp.FluentValidation.Responses;

namespace Sharmila_Textile_WebApp.FluentValidation.Validators {
    public class ErrorResponse {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>(); 
    }
}
