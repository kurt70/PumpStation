using PumpStation.ApiModels;
using PumpStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation.Managers
{
    public interface IWaterLevelManager
    {
        WaterLevel GetWaterLevel();
    }
    public class WaterLevelManager : IWaterLevelManager
    {
        private IGPIORepository _gpioRpository;

        public WaterLevelManager(IGPIORepository gpioRpository)
        {
            _gpioRpository = gpioRpository ?? throw new ArgumentException(nameof(gpioRpository));
        }
        public WaterLevel GetWaterLevel()
        {
            throw new NotImplementedException();
        }
    }
}
