using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private MotorcycleDetails m_MotorcycleDetails;

        public MotorcycleDetails MotorcycleDetails
        {
            get
            {
                return m_MotorcycleDetails;
            }

            set
            {
                m_MotorcycleDetails = value;
            }
        }

        public FuelMotorcycle(eFuel i_FuelType, float i_MaxFuelCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure)
    : base(i_FuelType, i_MaxFuelCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
            m_MotorcycleDetails = new MotorcycleDetails();
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
    Lisence Type: {1}
    Engine Capacity: {2}
    Fuel Type: {3}
    Current Fuel Amount: {4}
    Maximum Fuel Capacity: {5}
    {6}", 
                Model,
                MotorcycleDetails.LicenseType.ToString(), 
                MotorcycleDetails.EngineCapacity, 
                FuelType.ToString(), 
                Energy.CurrentEnergy, 
                Energy.MaxEnergy, 
                Wheels[0].ToString());
        }
    }
}