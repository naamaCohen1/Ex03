using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
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

        public ElectricCar(float i_MaxBatteryCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure)
            : base(i_MaxBatteryCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
            m_CarDetails = new CarDetails();
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
    Car Color: {1}
    Num Of Doors: {2}
    Current Battery Amount (in Hours): {3}
    Maximum Battery Capacity (in Hours): {4}
    {5}", 
                Model,
                CarDetails.VehicleColor.ToString(), 
                CarDetails.NumOfDoors.GetHashCode(),
                Energy.CurrentEnergy, 
                Energy.MaxEnergy, 
                Wheels[0].ToString());
        }
    }
}