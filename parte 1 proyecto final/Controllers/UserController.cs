using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parte_1_proyecto_final.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
