namespace Ex03.GarageLogic
{
    public class FuelTank
    {
        private readonly Enums.eFuelType r_FuelType;
        internal float m_CurrentFuelAmount;
        private readonly float r_MaxFuelAmount;
        public FuelTank(Enums.eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelAmount = i_MaxFuelAmount;
            m_CurrentFuelAmount = 0;
        }
        public Enums.eFuelType FuelType
        {
            get { return r_FuelType; }
        }
        public void Refuel(float i_Amount)
        {
            if (m_CurrentFuelAmount + i_Amount > r_MaxFuelAmount)
            {
                throw new ArgumentException("Cannot refuel beyond max fuel amount");
            }
            m_CurrentFuelAmount += i_Amount;
        }
    }
}