using CommonContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation.Controllers
{
    [Route("api/[controller]")]
    public class GpioController : Controller, IHardwareAbstractionLayer
    {
        private IHardwareAbstractionLayer _hal;

        public GpioController(IHardwareAbstractionLayer hal)
        {
            _hal = hal ?? throw new ArgumentException(nameof(hal));
        }

        [HttpGet]
        [Route("GetPinValue/{pinId}")]
        public int Get(int pinId)
        {
            return _hal.Get(pinId);
        }

        [HttpGet]
        [Route("GetAllPins")]
        public List<GPIOPin> GetPins()
        {
            return _hal.GetPins();
        }

        [HttpPut]
        [Route("SetPinValue/{pinId}/{value}")]
        public void Set(int pinId, int value)
        {
            _hal.Set(pinId, value);
        }
    }
}
