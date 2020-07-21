using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Energy 
    {
        private readonly float r_MaxEnergyCapacity;
        private float m_CurrentEnergy;

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
        }

        public Energy(float i_MaxEnergy)
        {
            r_MaxEnergyCapacity = i_MaxEnergy;
        }
    }
}