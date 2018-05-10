using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation.Controllers
{
    [Route("api/[controller]")]
    public class PumpController: Controller
    {
        [HttpGet]
        [Route("IsRunning/")]
        public bool IsRunning()
        {
            return false;
        }

        [HttpGet]
        [Route("Start/")]
        public bool Start()
        {
            return false;
        }

        [HttpGet]
        [Route("Stop/")]
        public bool Stop()
        {
            return false;
        }

        //Set speed/voltage?
    }
}
