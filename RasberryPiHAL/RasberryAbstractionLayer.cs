using CommonContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace RasberryPiHAL
{
    public class RasberryAbstractionLayer : IHardwareAbstractionLayer
    {
        private ILogger<RasberryAbstractionLayer> _logger;

        public RasberryAbstractionLayer(ILogger<RasberryAbstractionLayer> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        public int Get(int pinId)
        {
            try
            {
                var pin = PinMapper(pinId);
                pin.PinMode = GpioPinDriveMode.Output;
                var v = pin.Read() ? 1 : 0;
                _logger.LogDebug($"Pin id {pinId} has the value of {v}.");
                return v;
            }
            catch (Exception e)
            {
                var msg = $"Getting pin {pinId}'s value failed.";
                _logger.LogError(e, msg);
                throw new Exception(msg, e);
            }
        }

        public List<GPIOPin> GetPins()
        {
            var res = new List<GPIOPin>();
            foreach (var item in Pi.Gpio.HeaderP1.Values)
            {
                res.Add(item.ToModel());
            }
            return res;
        }

        public void Set(int pinId, int value)
        {
            try
            {
                var pin = PinMapper(pinId);
                pin.PinMode = GpioPinDriveMode.Input;
                pin.Write(value == 0 ? GpioPinValue.Low : GpioPinValue.High);
                _logger.LogDebug($"Setting Pin id {pinId} to the value of {value}.");
            }
            catch (Exception e)
            {
                var msg = $"Setting pin {pinId}'s value failed.";
                _logger.LogError(e, msg);
                throw new Exception(msg, e);
            }
        }

        private GpioPin PinMapper(int pinId)
        {
            return Pi.Gpio.GetGpioPinByBcmPinNumber(pinId);
        }
    }

    public static class Extensions
    {
        public static GPIOPin ToModel(this GpioPin pin)
        {
            var res = new GPIOPin()
            {
                Direction = pin.PinMode == GpioPinDriveMode.Input ? PinDirection.In : PinDirection.Out,
                PinNumber = pin.PinNumber,
                Value = pin.ReadValue() == GpioPinValue.High ? 1 : 0
            };
            return res;
        }
    }
}
