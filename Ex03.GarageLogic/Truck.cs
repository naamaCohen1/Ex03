using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : FuelVehicle
    {
        private bool m_IsTransportingDangerousMaterial;
        private float m_CargoCapacity;

        public bool IsTransportingDangerousMaterial
        {
            get
            {
                return m_IsTransportingDangerousMaterial;
            }

            set
            {
                m_IsTransportingDangerousMaterial = value;
            }
        }

        public float CargoCapacity
        {
            get
            {
                return m_CargoCapacity;
            }

            set
            {
                m_CargoCapacity = value;
            }
        }

        public Truck(eFuel i_FuelType, float i_MaxFuelCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure)
: base(i_FuelType, i_MaxFuelCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
        }

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0} 
    Is Transporting Dangerous Material: {1}
    Cargo Capacity: {2}
    Fuel Type: {3}
    Current Fuel Amount: {4}
    Maximum Fuel Capacity: {5}
    {6}",
                Model,
                m_IsTransportingDangerousMaterial.ToString(), 
                m_CargoCapacity, 
                FuelType.ToString(),
                Energy.CurrentEnergy, 
                Energy.MaxEnergy, 
                Wheels[0].ToString());
        }
    }
}