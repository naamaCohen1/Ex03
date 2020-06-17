using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        public ElectricVehicle(float i_MaxBatteryCapacity, eWheels i_NumOfWheels, float i_MaxAirPressure) 
            : base(i_MaxBatteryCapacity, i_NumOfWheels, i_MaxAirPressure)
        {
        }

        public void ChargeBattery(float i_MinToCharge)
        {
            float newBattery = Energy.CurrentEnergy + (i_MinToCharge / 60);

            if(newBattery <= Energy.MaxEnergy && newBattery >= 0)
            {
                Energy.CurrentEnergy = newBattery;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    Energy.MaxEnergy, 
                    0, 
                    string.Format("Max battery energy exceeded, Value out of range - {0}. The battery was not loaded.", newBattery));
            }
        }
    }
}