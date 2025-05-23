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

        public void Refuel(float i_Amount)
        {
            if (m_CurrentFuelAmount + i_Amount > r_MaxFuelAmount)
            {
                throw new ArgumentException("Cannot refuel beyond max fuel amount");
            }
            m_CurrentFuelAmount += i_Amount;
        }

        public float EnergyLeft()
        {
            return (m_CurrentFuelAmount / r_MaxFuelAmount) * 100f;
        }
    }
}