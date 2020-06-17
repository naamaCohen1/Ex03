using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Garage m_Garage;
       
        public GarageManager()
        {
            m_Garage = new Garage();
        }

        public void EnterNewVehicle(string i_VehicleOwner, string i_VehicleOwnerPhone, int i_VehicleType, string i_LicenseNumber) 
        {
            m_Garage.EnterNewVehicle(i_VehicleOwner, i_VehicleOwnerPhone, i_VehicleType, i_LicenseNumber);
        }

        public bool CheckIfVehicleInGarage(string i_LicenseNumber) 
        {
            return m_Garage.CheckIfVehicleInGarage(i_LicenseNumber);
        }

        public List<string> GetVehiclesInGarageByStatus(int m_VehiclesStatusToShow) 
        {
            return m_Garage.GetVehiclesInGarageByStatus(m_VehiclesStatusToShow);
        }

        public List<string> GetAllVehiclesInGarage()
        {
            return m_Garage.GetAllVehiclesInGarage();
        }

        public bool IsExistInGarage(string i_LicenseNumber)
        {
            return m_Garage.IsExistInGarage(i_LicenseNumber);
        }

        public void ChangeGarageVehicleStatus(string i_LicenseNumber, int i_NewStatus) 
        {
            m_Garage.ChangeGarageVehicleStatus(i_LicenseNumber, i_NewStatus);
        }

        public void FillAirPressureToMax(string i_LicenseNumber) 
        {
            m_Garage.FillAurPressureToMax(i_LicenseNumber);
        }

        public void RefuelVehicleEnergy(string i_LicenseNumber, int i_FuelType, float i_FuelAmountToAdd) 
        {
            m_Garage.RefuelVehicleEnergy(i_LicenseNumber, i_FuelType, i_FuelAmountToAdd);
        }

        public void ChargeVehicleEnergy(string i_LicenseNumber, float i_MinuteToCharge) 
        {
            m_Garage.ChargeVehicleEnergy(i_LicenseNumber, i_MinuteToCharge);
        }

        public void SetMotorcycleAdditionalParams(string i_LicenseNumber, int i_LicenseType, int i_EngineCapacity) 
        {
            m_Garage.SetMotorcycleAdditionalParams(i_LicenseNumber, i_LicenseType, i_EngineCapacity);
        }

        public void SetCarAdditionalParams(string i_LicenseNumber, int i_VehicleColor, int i_NumOfDoors)  
        {
            m_Garage.SetCarAdditionalParams(i_LicenseNumber, i_VehicleColor, i_NumOfDoors);
        }

        public void SetTruckAdditionalParams(string i_LicenseNumber, bool i_IsTransportingDangerousMaterial, float i_CargoCapacity)
        {
            m_Garage.SetTruckAdditionalParams(i_LicenseNumber, i_IsTransportingDangerousMaterial, i_CargoCapacity);
        }

        public void AddWheelDetails(string i_ManufactureName, float i_LeftedAirPressure, string i_LicenseNumber) 
        {
            m_Garage.AddWheelDetails(i_ManufactureName, i_LeftedAirPressure, i_LicenseNumber);
        }

        public string GetVehicleData(string i_LicenseNumber) 
        {
            return m_Garage.GetVehicleData(i_LicenseNumber);
        }

        public string GetVehicleTypeAsString(int i_VehicleStatus)
        {
            return m_Garage.GetVehicleTypeAsString(i_VehicleStatus);
        }

        public eVehicleStatus CheckIfValidStatusParam(int i_VehicleStatus) 
        {
            return m_Garage.CheckIfValidStatusParam(i_VehicleStatus);
        }

        public void AddModelAndLeftedEnergyPrecent(string i_LicenseNumber, float i_LeftedEnergyPrecent, string i_VehicleModel)
        {
            m_Garage.AddModelAndLeftedEnergyPrecent(i_LicenseNumber, i_LeftedEnergyPrecent, i_VehicleModel);
        }
    }
}
