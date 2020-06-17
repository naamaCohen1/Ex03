using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleInit
    {
        private readonly int r_MaxCarAirPessure = 32;
        private readonly float r_MaxCarFuelCapability = 60;
        private readonly int r_MaxMotorcycleAirPessure = 30;
        private readonly float r_MaxMotorcycleFuelCapability = 7;
        private readonly int r_MaxTruckAirPessure = 28;
        private readonly float r_MaxTruckFuelCapability = 120;
        private readonly float r_MaxCarBatteryCapabity = 2.1f;
        private readonly float r_MaxMotorcycleBatteryCapabity = 1.2f;

        public Vehicle InitVehicle(eVehicleTypes i_VehicleType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleTypes.FUEL_CAR:
                    newVehicle = new FuelCar(eFuel.OCTAN_96, r_MaxCarFuelCapability, eWheels.FOUR, r_MaxCarAirPessure);
                    break;
                case eVehicleTypes.ELECTRIC_CAR:
                    newVehicle = new ElectricCar(r_MaxCarBatteryCapabity, eWheels.FOUR, r_MaxCarAirPessure);
                    break;
                case eVehicleTypes.FUEL_MOTORCYCLE:
                    newVehicle = new FuelMotorcycle(eFuel.OCTAN_95, r_MaxMotorcycleFuelCapability, eWheels.TWO, r_MaxMotorcycleAirPessure);
                    break;
                case eVehicleTypes.ELECTRIC_MOTORCYCLE:
                    newVehicle = new ElectricMotorcycle(r_MaxMotorcycleBatteryCapabity, eWheels.TWO, r_MaxMotorcycleAirPessure);
                    break;
                case eVehicleTypes.TRUCK:
                    newVehicle = new Truck(eFuel.SOLER, r_MaxTruckFuelCapability, eWheels.SIXTEEN, r_MaxTruckAirPessure);
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid vehicle type - {0}", i_VehicleType.ToString()));
            }

            return newVehicle;
        }
    }
}
