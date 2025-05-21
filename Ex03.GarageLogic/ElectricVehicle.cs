namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private readonly ElectricBattery r_Battery;
        public override float m_EnergyLeft
        {
            get
            {
                return r_Battery.m_CurrentChargeAmount;
            }
        }

        public ElectricVehicle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }

        public void Recharge(float i_Amount)
        {
            r_Battery.Recharge(i_Amount);
        }
    }
}
