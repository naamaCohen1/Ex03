using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private string m_VehicleOwner;
        private string m_VehicleOwnerPhone;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }

            set
            {
                m_Vehicle = value;
            }
        }

        public string VehicleOwner
        {
            get
            {
                return m_VehicleOwner;
            }

            set
            {
                m_VehicleOwner = value;
            }
        }

        public string VehicleOwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }

            set
            {
                m_VehicleOwnerPhone = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public GarageVehicle(Vehicle i_Vehicle, string i_VehicleOwner, string i_VehicleOwnerPhone, eVehicleStatus i_VehicleStatus)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleOwner = i_VehicleOwner;
            m_VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_VehicleStatus = i_VehicleStatus;
        }

        public override string ToString()
        {
            return string.Format(
                @"    
    License Number: {0}
    Owner Name: {1}
    Vehicle Owner Phone: {2}
    Status in the Grage: {3}
    {4}", 
                m_Vehicle.LicenseNumber, 
                m_VehicleOwner, 
                m_VehicleOwnerPhone, 
                m_VehicleStatus.ToString(), 
                m_Vehicle.ToString());
        }
    }
}