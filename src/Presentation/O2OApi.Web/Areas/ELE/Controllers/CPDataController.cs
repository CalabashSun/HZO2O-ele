using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace O2OApi.Web.Areas.ELE.Controllers
{
    public class CPDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
