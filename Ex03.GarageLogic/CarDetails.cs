using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CarDetails
    {
        private eColors m_VehicleColor;
        private eDoors m_NumOfDoors;

        public eColors VehicleColor
        {
            get
            {
                return m_VehicleColor;
            }

            set
            {
                m_VehicleColor = value;
            }
        }

        public eDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }
    }
}