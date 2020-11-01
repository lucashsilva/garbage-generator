using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarbageGenerator.Controllers
{
    [ApiController]
    [Route("garbage")]
    public class GarbageGeneratorController : ControllerBase
    {
        private readonly ILogger<GarbageGeneratorController> _logger;
        private static byte[][] buffer;
        private static int msgCount;
        private static int MSG_SIZE;
        private static int WINDOW_SIZE;

        public GarbageGeneratorController(ILogger<GarbageGeneratorController> logger)
        {
            _logger = logger;

            WINDOW_SIZE = Int32.Parse(Environment.GetEnvironmentVariable("WINDOW_SIZE"));
            MSG_SIZE = Int32.Parse(Environment.GetEnvironmentVariable("MSG_SIZE"));
            buffer = new byte[WINDOW_SIZE][];
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                GC.TryStartNoGCRegion(Int32.Parse(Environment.GetEnvironmentVariable("HEAP_SIZE")));
            }
            catch (InvalidOperationException e)
            {
                // already in no gc region
            }

            byte[] byteArray = new byte[MSG_SIZE];

            for (int i = 0; i < MSG_SIZE; i++)
            {
                byteArray[i] = (byte)i;
            }

            if (WINDOW_SIZE > 0)
            {
                buffer[msgCount++ % WINDOW_SIZE] = byteArray;
            }

            long max = 5000;
            long count = 0;
            for (long i = 3; i <= max; i++)
            {
                bool isPrime = true;
                for (long j = 2; j <= i / 2 && isPrime; j++)
                {
                    isPrime = i % j > 0;
                }
                if (isPrime)
                {
                    count++;
                }
            }

            return Ok();
        }
    }
}