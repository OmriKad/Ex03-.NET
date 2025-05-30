﻿using System;

namespace Ex03.GarageLogic
{
    public class ElectricBattery
    {
        public float m_CurrentChargeAmount;
        public float r_MaxChargeAmount;
        public ElectricBattery(float i_MaxChargeAmount)
        {
            r_MaxChargeAmount = i_MaxChargeAmount;
            m_CurrentChargeAmount = 0;
        }
        public void Recharge(float i_Amount)
        {
            if (m_CurrentChargeAmount + i_Amount > r_MaxChargeAmount)
            {
                throw new ValueRangeException(0f, Math.Abs(r_MaxChargeAmount - m_CurrentChargeAmount));
            }
            m_CurrentChargeAmount += i_Amount;
        }

        public float EnergyLeft()
        {
            return (m_CurrentChargeAmount / r_MaxChargeAmount) * 100f;
        }
    }
}