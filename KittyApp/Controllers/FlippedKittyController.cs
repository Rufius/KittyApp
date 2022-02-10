using KittyApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlippedKittyController : ControllerBase
    {
        private IConfiguration _configuration;
        private IKittyService _kittyService;
        public FlippedKittyController(IConfiguration configuration, IKittyService kittyService)
        {
            _configuration = configuration;
            _kittyService = kittyService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var url = _configuration.GetValue(typeof(string), "CatUrl") as string;
            var result = await _kittyService.FlipKittyImage(url);
            return File(result, @"image/jpeg");
        }
    }
}
