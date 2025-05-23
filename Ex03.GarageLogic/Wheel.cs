using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName { get; set; }
        private float m_CurrentAirPressure { get; set; }
        private float m_MaxAirPressure { get; set; }
        public Wheel(float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = null;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ArgumentException("Cannot inflate beyond max air pressure");
            }
            m_CurrentAirPressure += i_AirToAdd;
        }
    }
}