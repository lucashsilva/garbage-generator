using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarbageGenerator.Controllers
{
    [ApiController]
    [Route("garbage")]
    public class GarbageGeneratorController : ControllerBase
    {
        private readonly ILogger<GarbageGeneratorController> _logger;

        public GarbageGeneratorController(ILogger<GarbageGeneratorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var size = Math.Pow(2, 20);
            var list = new List<Double>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }

            return Ok();
        }
    }
}
