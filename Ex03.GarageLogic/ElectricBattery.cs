namespace Ex03.GarageLogic
{
    public class ElectricBattery
    {
        internal float m_CurrentChargeAmount;
        private readonly float r_MaxChargeAmount;
        public ElectricBattery(float i_MaxChargeAmount)
        {
            r_MaxChargeAmount = i_MaxChargeAmount;
            m_CurrentChargeAmount = 0;
        }
        public void Recharge(float i_Amount)
        {
            if (m_CurrentChargeAmount + i_Amount > r_MaxChargeAmount)
            {
                throw new ArgumentException("Cannot recharge beyond max charge amount");
            }
            m_CurrentChargeAmount += i_Amount;
        }
    }
}