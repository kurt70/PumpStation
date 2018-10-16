using Microsoft.AspNetCore.Mvc;
using PumpStation.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation.Controllers
{
    [Route("api/[controller]")]
    public class WaterLevelController:Controller
    {
        [HttpGet]
        public WaterLevel GetWaterLevel()
        {
            return WaterLevel.Empty;
        }
    }
}
