using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private Dictionary<string, GarageVehicle> m_VehiclesInGarage;

        public Dictionary<string, GarageVehicle> VehiclesInGarage
        {
            get
            {
                return m_VehiclesInGarage;
            }

            set
            {
                m_VehiclesInGarage = value;
            }
        }

        public Garage()
        {
            VehiclesInGarage = new Dictionary<string, GarageVehicle>();
        }

        public void AddModelAndLeftedEnergyPrecent(string i_VehicleModel, float i_LeftedEnergyPrecent, string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = VehiclesInGarage[i_LicenseNumber];
            checkIfValidPercent(i_LeftedEnergyPrecent);
            garageVehicle.Vehicle.SetVehicleModelAndPercentage(i_LeftedEnergyPrecent, i_VehicleModel);
            garageVehicle.Vehicle.Energy.CurrentEnergy = i_LeftedEnergyPrecent / 100 * garageVehicle.Vehicle.Energy.MaxEnergy;
        }

        public void EnterNewVehicle(
            string i_VehicleOwner, 
            string i_VehicleOwnerPhone, 
            int i_VehicleType, 
            string i_LicenseNumber)
        {
            VehicleInit vehicleInit = new VehicleInit();
            Vehicle vehicle;
            GarageVehicle garageVehicle;
            eVehicleTypes vehicleType;

            vehicleType = checkIfValidVehicleTypeParam(i_VehicleType);
            vehicle = vehicleInit.InitVehicle(vehicleType); 
            vehicle.SetVehicleLicenseNumber(i_LicenseNumber);
            garageVehicle = new GarageVehicle(vehicle, i_VehicleOwner, i_VehicleOwnerPhone, eVehicleStatus.IN_PROGRESS);
            m_VehiclesInGarage.Add(vehicle.LicenseNumber, garageVehicle);
        }

        public bool CheckIfVehicleInGarage(string i_LicenseNumber) 
        {
            bool isExist = false;

            if(IsExistInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = eVehicleStatus.IN_PROGRESS;
                isExist = true;
            }

            return isExist;
        }

        public List<string> GetVehiclesInGarageByStatus(int i_VehiclesStatusToShow) 
        {
            List<string> filtersVehiclesList = new List<string>();
            eVehicleStatus currentVehicleStatus, requestedVehicleStatus;

                requestedVehicleStatus = CheckIfValidStatusParam(i_VehiclesStatusToShow); 
                foreach(string vehicleLicense in m_VehiclesInGarage.Keys)
                {
                    currentVehicleStatus = m_VehiclesInGarage[vehicleLicense].VehicleStatus;
                    if(requestedVehicleStatus == currentVehicleStatus)
                    {
                        filtersVehiclesList.Add(vehicleLicense);
                    }
                }

            return filtersVehiclesList;
        }

        public List<string> GetAllVehiclesInGarage()
        {
            List<string> garageVehiclesList = new List<string>();

            foreach (string vehicleLicense in m_VehiclesInGarage.Keys)
            {
                garageVehiclesList.Add(vehicleLicense);
            }

            return garageVehiclesList;
        }

        public bool IsExistInGarage(string i_LicenseNumber) 
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public void ChangeGarageVehicleStatus(string i_LicenseNumber, int i_NewStatus)
        {
            if(IsExistInGarage(i_LicenseNumber))
            {
                eVehicleStatus newStatus = CheckIfValidStatusParam(i_NewStatus); 
                m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = newStatus;
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void FillAurPressureToMax(string i_LicenseNumber) 
        {
            if(IsExistInGarage(i_LicenseNumber))
            {
                m_VehiclesInGarage[i_LicenseNumber].Vehicle.FillAirPressureToMax();
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void RefuelVehicleEnergy(string i_LicenseNumber, int i_FuelType, float i_FuelAmountToAdd) 
        {
            eFuel fuelType;
            if(IsExistInGarage(i_LicenseNumber))
            {
                FuelVehicle fuelVehicle = m_VehiclesInGarage[i_LicenseNumber].Vehicle as FuelVehicle;
                if(fuelVehicle != null)
                {
                    fuelType = checkIfValidFuelParam(i_FuelType);
                    m_VehiclesInGarage[i_LicenseNumber].Vehicle.RefuelEnergy(fuelType, i_FuelAmountToAdd);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not a Fuel Vehicle", i_LicenseNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        private void checkIfValidPercent(float i_LeftedEnergyPrecent)
        {
            if(i_LeftedEnergyPrecent > 100 || i_LeftedEnergyPrecent < 0)
            {
                throw new ValueOutOfRangeException(
                        100, 
                        0, 
                        string.Format("Max Lefted Energy Precent was exceeded, Value out of range - {0}.", i_LeftedEnergyPrecent));
            }
        }

        public void ChargeVehicleEnergy(string i_LicenseNumber, float i_MinuteToCharge)
        {
            if(IsExistInGarage(i_LicenseNumber))
            {
                ElectricVehicle electricVehicle = m_VehiclesInGarage[i_LicenseNumber].Vehicle as ElectricVehicle;
                if(electricVehicle != null)
                {
                    m_VehiclesInGarage[i_LicenseNumber].Vehicle.ChargeBatteryEnergy(i_MinuteToCharge);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not an Electric Vehicle", i_LicenseNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with license number '{0}' is not exist in the garage", i_LicenseNumber));
            }
        }

        public void SetMotorcycleAdditionalParams(string i_LicenseNumber, int i_LicenseType, int i_EngineCapacity) 
        {
            GarageVehicle garageVehicle = VehiclesInGarage[i_LicenseNumber];

            eLicenseTypes licenseType = checkIfValidLicenseTypeParam(i_LicenseType);

            if(garageVehicle.Vehicle is ElectricMotorcycle)
            {
                ElectricMotorcycle electricMotorcycle = garageVehicle.Vehicle as ElectricMotorcycle;
                electricMotorcycle.MotorcycleDetails.LicenseType = licenseType;
                electricMotorcycle.MotorcycleDetails.EngineCapacity = i_EngineCapacity;
            }
            else if(garageVehicle.Vehicle is FuelMotorcycle)
            {
                FuelMotorcycle fuelMotorcycle = garageVehicle.Vehicle as FuelMotorcycle;
                fuelMotorcycle.MotorcycleDetails.LicenseType = licenseType;
                fuelMotorcycle.MotorcycleDetails.EngineCapacity = i_EngineCapacity;
            }
        }

        public void SetCarAdditionalParams(string i_LicenseNumber, int i_VehicleColor, int i_NumOfDoors) 
        {
            GarageVehicle garageVehicle = VehiclesInGarage[i_LicenseNumber];

            eColors color = checkIfValidColorParam(i_VehicleColor);
            eDoors numOfDoors = checkIfValidDoorsParam(i_NumOfDoors);

            if(garageVehicle.Vehicle is FuelCar)
            {
                FuelCar fuelCar = garageVehicle.Vehicle as FuelCar;
                fuelCar.CarDetails.VehicleColor = color;
                fuelCar.CarDetails.NumOfDoors = numOfDoors;
            }
            else if(garageVehicle.Vehicle is ElectricCar)
            {
                ElectricCar electricCar = garageVehicle.Vehicle as ElectricCar;
                electricCar.CarDetails.VehicleColor = color;
                electricCar.CarDetails.NumOfDoors = numOfDoors;
            }
        }

        public void SetTruckAdditionalParams(string i_LicenseNumber, bool i_IsTransportingDangerousMaterial, float i_CargoCapacity) 
        {
            Truck truck = VehiclesInGarage[i_LicenseNumber].Vehicle as Truck;
            if (i_CargoCapacity >= 0)
            {
                truck.IsTransportingDangerousMaterial = i_IsTransportingDangerousMaterial;
                truck.CargoCapacity = i_CargoCapacity;
            }
            else
            {
                throw new ArgumentException("Cargo capacity can not be negative");
            }
        }

        public void AddWheelDetails(string i_ManufactureName, float i_LeftedAirPressure, string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = VehiclesInGarage[i_LicenseNumber];
            checkIfValiLeftedAirPressureParams(i_LeftedAirPressure, garageVehicle);
            garageVehicle.Vehicle.InitWheels(i_ManufactureName, i_LeftedAirPressure);
        }

        public string GetVehicleData(string i_LicenseNumber) 
        {
            if(!VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException(string.Format("Lisence {0} Lisence is not in the Garage", i_LicenseNumber));       
            }

            return VehiclesInGarage[i_LicenseNumber].ToString();
        }

        private void checkIfValiLeftedAirPressureParams(float i_LeftedAirPressure, GarageVehicle i_GarageVehicle)
        {
            if(i_LeftedAirPressure > i_GarageVehicle.Vehicle.MaxAirPressure || i_LeftedAirPressure < 0)
            {
                throw new ValueOutOfRangeException(
                    i_GarageVehicle.Vehicle.MaxAirPressure,
                    0,
                    string.Format("Invalid Lefted Air Pressure, Value out of range - {0}.", i_LeftedAirPressure));
            }
        }

        private eColors checkIfValidColorParam(int i_VehicleColor) 
        {
            if(Enum.IsDefined(typeof(eColors), i_VehicleColor))
            {
                return (eColors)Enum.Parse(typeof(eColors), i_VehicleColor.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Vehicle color choice - {0}", i_VehicleColor));
            }
        }

        private eFuel checkIfValidFuelParam(int i_FuelType) 
        {
            if(Enum.IsDefined(typeof(eFuel), i_FuelType))
            {
                return (eFuel)Enum.Parse(typeof(eFuel), i_FuelType.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Fuel Type choice - {0}", i_FuelType));
            }
        }

        private eDoors checkIfValidDoorsParam(int i_NumOfDoors)
        {
            if(Enum.IsDefined(typeof(eDoors), i_NumOfDoors))
            {
                return (eDoors)Enum.Parse(typeof(eDoors), i_NumOfDoors.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Number Of Doors choice - {0}", i_NumOfDoors));
            }
        }

        private eLicenseTypes checkIfValidLicenseTypeParam(int i_LicenseType)
        {
            if(Enum.IsDefined(typeof(eLicenseTypes), i_LicenseType))
            {
                return (eLicenseTypes)Enum.Parse(typeof(eLicenseTypes), i_LicenseType.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Licemse Type choice - {0}.", i_LicenseType));
            }
        }

        public eVehicleStatus CheckIfValidStatusParam(int i_VehicleStatus) 
        {
            if(Enum.IsDefined(typeof(eVehicleStatus), i_VehicleStatus))
            {
                return (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), i_VehicleStatus.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Vehicle Status choice - {0}", i_VehicleStatus));
            }
        }

        private eVehicleTypes checkIfValidVehicleTypeParam(int i_VehicleType)
        {
            if(Enum.IsDefined(typeof(eVehicleTypes), i_VehicleType))
            {
                return (eVehicleTypes)Enum.Parse(typeof(eVehicleTypes), i_VehicleType.ToString());
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid Vehicle Type choice - {0}", i_VehicleType));
            }
        }

        public string GetVehicleTypeAsString(int i_VehicleType)
        {
            return ((eVehicleTypes)Enum.Parse(typeof(eVehicleTypes), i_VehicleType.ToString())).ToString();
        }

        public void RemoveVihcle(string i_LisenceNumber)
        {
            VehiclesInGarage.Remove(i_LisenceNumber);
        }
    }
}