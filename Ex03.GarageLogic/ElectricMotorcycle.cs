using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
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

        public ElectricMotorcycle(float i_MaxBatteryCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure) 
            : base(i_MaxBatteryCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
            m_MotorcycleDetails = new MotorcycleDetails();
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
    Lisence Type: {1}
    Engine Capacity: {2}
    Current Battery Amount (in Hours): {3}
    Maximum Battery Capacity (in Hours): {4}
    {5}", 
                Model,
                MotorcycleDetails.LicenseType.ToString(),
                MotorcycleDetails.EngineCapacity.ToString(), 
                Energy.CurrentEnergy, 
                Energy.MaxEnergy, 
                Wheels[0].ToString());
        }
    }
}