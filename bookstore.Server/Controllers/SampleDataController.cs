﻿using bookstore.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
              
        [Route("Vlada")]
        public IActionResult bla() {
            return Json("Vladimir");
                }
        }
}
