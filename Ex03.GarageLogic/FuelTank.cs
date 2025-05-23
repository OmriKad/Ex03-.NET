using System;

namespace Ex03.GarageLogic
{
    public class FuelTank
    {
        private readonly Enums.eFuelType r_FuelType;
        public float m_CurrentFuelAmount { get; set; }
        public float r_MaxFuelAmount { get; set; }

        public FuelTank(Enums.eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmount = i_MaxFuelAmount;
            m_CurrentFuelAmount = 0;
        }

        public void Refuel(float i_Amount, Enums.eFuelType i_FuelType)
        {
            if (m_CurrentFuelAmount + i_Amount > r_MaxFuelAmount)
            {
                throw new ValueRangeException(0f, r_MaxFuelAmount);
            }

            if(i_FuelType != r_FuelType)
            {
                throw new ArgumentException($"Fuel type {i_FuelType} is not compatible with the vehicle's fuel type {r_FuelType}.");
            }

            m_CurrentFuelAmount += i_Amount;
        }

        public float EnergyLeft()
        {
            return (m_CurrentFuelAmount / r_MaxFuelAmount) * 100f;
        }
    }
}