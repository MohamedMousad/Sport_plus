using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPlus.BLL.ModelVM.Account
{
    public class VerifyEmailVM
    {
        public required string UserName { get; set; }
        public required string Code { get; set; }
    }

}