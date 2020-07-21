using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        private CarDetails m_CarDetails;

        public CarDetails CarDetails
        {
            get
            {
                return m_CarDetails;
            }

            set
            {
                m_CarDetails = value;
            }
        }

        public FuelCar(eFuel i_FuelType, float i_MaxFuelCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure)
    : base(i_FuelType, i_MaxFuelCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
            m_CarDetails = new CarDetails();
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
    Car Color: {1}
    Num Of Doors: {2}
    Fuel Type: {3}
    Current Fuel Amount: {4}
    Maximum Fuel Capacity: {5}
    {6}", 
                Model,
                CarDetails.VehicleColor.ToString(), 
                CarDetails.NumOfDoors.GetHashCode(), 
                FuelType.ToString(), 
                Energy.CurrentEnergy, 
                Energy.MaxEnergy, 
                Wheels[0].ToString());
        }
    }
}