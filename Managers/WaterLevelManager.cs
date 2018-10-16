using CommonContracts;
using PumpStation.ApiModels;
using System;

namespace PumpStation.Managers
{
    public interface IWaterLevelManager
    {
        WaterLevel GetWaterLevel();
    }
    public class WaterLevelManager : IWaterLevelManager
    {
        private IHardwareAbstractionLayer _hal;

        public WaterLevelManager(IHardwareAbstractionLayer hal)
        {
            _hal = hal ?? throw new ArgumentException(nameof(hal));
        }
        public WaterLevel GetWaterLevel()
        {
            throw new NotImplementedException();
        }
    }
}
