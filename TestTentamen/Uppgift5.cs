using System;

namespace TestTentamen
{
    public interface IVehicle
    {
        decimal FillTank();

        void Drive(int kilometers);

        int FuelLevel();
    }

    public interface IEnclosedVehicle : IVehicle
    {
        void OpenDoor();

        bool IsDoorOpen { get; }
    }
    
    public abstract class Vehicle : IVehicle
    {
        protected decimal FuelConsumption { get; }
        protected decimal FuelCapacity { get; }
        private decimal _fuelLevel;

        public Vehicle(decimal fuelConsumption, decimal _fuelCapacity)
        {
            FuelConsumption = fuelConsumption;
            FuelCapacity = _fuelCapacity;
        }

        public void Drive(int kilometers)
        {
            _fuelLevel = _fuelLevel - kilometers * FuelConsumption;
            if (_fuelLevel < 0)
            {
                _fuelLevel = 0;
            }
        }

        public int FuelLevel()
        {
            return (int)Math.Round((_fuelLevel / FuelCapacity)) * 100;
        }
        public decimal FillTank()
        {
            var amountToFill = FuelCapacity - _fuelLevel;
            _fuelLevel = FuelCapacity;
            return amountToFill;
        }
    }

    public class Motorbike : Vehicle
    {
        public Motorbike() : base(0.34m, 18m)
        {
        }
    }

    public class Car : Vehicle, IEnclosedVehicle
    {
        public Car() : base(0.77m, 52m)
        {
        }

        public bool IsDoorOpen { get; private set; }

        public void OpenDoor()
        {
            IsDoorOpen = true;
        }
    }
}
