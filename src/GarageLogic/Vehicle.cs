using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle 
    {
        private readonly float r_MaxAirPressure;
        private string m_Model;
        private string m_LicenseNumber;
        private float m_LeftedEnergyPrecent;
        private List<Wheel> m_Wheels;
        private Energy m_Energy;

        public string Model
        {
            get
            {
                return m_Model;
            }

            set
            {
                m_Model = value;
            }
        }

        public Energy Energy
        {
            get
            {
                return m_Energy;
            }

            set
            {
                m_Energy = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public float LeftedEnergyPrecent
        {
            get
            {
                return m_LeftedEnergyPrecent;
            }

            set
            {
                m_LeftedEnergyPrecent = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public Vehicle(float i_MaxEnergy, eWheels i_NumOfWheels, float i_MaxAirPressure) 
        {
            m_Model = string.Empty;
            m_LicenseNumber = string.Empty;
            m_LeftedEnergyPrecent = 0;
            m_Wheels = new List<Wheel>((int)i_NumOfWheels);
            r_MaxAirPressure = i_MaxAirPressure;
            m_Energy = new Energy(i_MaxEnergy);
        }

        public void FillAirPressureToMax() 
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillAirPressure(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public void RefuelEnergy(eFuel i_FuelType, float i_FuelAmountToAdd) 
        {
            FuelVehicle vehicle = this as FuelVehicle;

            if(vehicle != null)
            {
                vehicle.Refuel(i_FuelAmountToAdd, i_FuelType);
                updateLeftedEnergyPrecent(vehicle.Energy);
            }
        }

        public void ChargeBatteryEnergy(float i_MinuteToLoad) 
        {
            ElectricVehicle vehicle = this as ElectricVehicle;

            if(vehicle != null)
            {
                vehicle.ChargeBattery(i_MinuteToLoad);
                updateLeftedEnergyPrecent(vehicle.Energy);
            }
        }

        private void updateLeftedEnergyPrecent(Energy i_VehicleEnergy)
        {
            m_LeftedEnergyPrecent = (i_VehicleEnergy.CurrentEnergy / i_VehicleEnergy.MaxEnergy) * 100;
        }

        public void SetVehicleLicenseNumber(string i_LicenseNumber)
        {
            LicenseNumber = i_LicenseNumber;
        }

        public void SetVehicleModelAndPercentage(float i_LeftedEnergyPrecent, string i_VehicleModel)
        {
            LeftedEnergyPrecent = i_LeftedEnergyPrecent;
            Model = i_VehicleModel;
        }

        public void InitWheels(string i_ManufactureName, float i_LeftedAirPressure)
        {
            for(int i = 0; i < Wheels.Capacity; i++)
            {
                m_Wheels.Add(new Wheel(i_ManufactureName, i_LeftedAirPressure, MaxAirPressure));
            }
        }
    }
}
