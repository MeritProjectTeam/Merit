using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Merit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly Merit.Data.Data.MeritContext MeritContext;

        public AdvertisementController(Merit.Data.Data.MeritContext meritContext)
        {
            MeritContext = meritContext;
        }

        [HttpGet]

        public async Task<ICollection<Data.Models.CompanyAdvertisement>> GetAllAsync()
        {

            return await MeritContext.CompanyAdvertisements.ToListAsync();
        }
    }
}
