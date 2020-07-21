using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void FillAirPressure(float i_AirToAdd) 
        {
            float airPressure = m_CurrentAirPressure + i_AirToAdd;

            if(airPressure <= m_MaxAirPressure && airPressure >= 0)
            {
                m_CurrentAirPressure = airPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    m_MaxAirPressure, 
                    0,
                    string.Format("Max air pressure exceeded, value out of range - {0}. The wheel was not blowed.", airPressure));
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Manufacture: {0}
    Current Air Pressure: {1}
    Max Air Pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure.ToString(),
                m_MaxAirPressure.ToString());
        }
    }
}