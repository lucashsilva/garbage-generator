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
            Console.WriteLine(Environment.GetEnvironmentVariable("name"));
            var size = Math.Pow(2, Int32.Parse(Environment.GetEnvironmentVariable("to_power_of")));
            var list = new List<Double>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }

            return Ok();
        }
    }
}
