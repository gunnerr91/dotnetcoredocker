using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColourAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ColourContext context;

        public ValuesController(ColourContext context)
        {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Colour>> Get()
        {
            return context.ColourItems;
        }

    }
}