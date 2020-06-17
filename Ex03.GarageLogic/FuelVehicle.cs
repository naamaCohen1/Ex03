using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelVehicle : Vehicle
    {
        private eFuel m_FuelType;

        public eFuel FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public FuelVehicle(eFuel i_FuelType, float i_MaxFuelCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure) 
            : base(i_MaxFuelCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
            m_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelLitersToAdd, eFuel i_FuelType)
        {
            if(i_FuelType == m_FuelType)
            {
                float newFuel = this.Energy.CurrentEnergy + i_FuelLitersToAdd;

                if(newFuel <= this.Energy.MaxEnergy && newFuel >= 0)
                {
                    this.Energy.CurrentEnergy = newFuel;
                }
                else
                {
                    throw new ValueOutOfRangeException(
                        this.Energy.MaxEnergy, 0, string.Format("Max feul energy exceeded, Value out of range - {0}. The battery was not loaded.", newFuel));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Fuel Type '{0}' is not fit to requested fuel type '{1}'", i_FuelType, FuelType));
            }
        }
    }
}
