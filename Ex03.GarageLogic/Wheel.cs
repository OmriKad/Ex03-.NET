﻿using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string m_ManufacturerName { get; set; }
        public float m_CurrentAirPressure { get; set; }
        public float m_MaxAirPressure { get;  private set; }
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
                throw new ValueRangeException(0f, m_MaxAirPressure);
            }
            m_CurrentAirPressure += i_AirToAdd;
        }
    }
}