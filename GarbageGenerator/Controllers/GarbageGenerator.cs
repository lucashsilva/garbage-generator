using System;
using System.Collections.ObjectModel;
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
            var size = Math.Pow(2, 22);
            Collection<int> list = new Collection<int>();

            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }

            return Ok();
        }
    }
}
