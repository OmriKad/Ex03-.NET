using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Vehicle, IMotorcycle
    {
        private readonly ElectricBattery r_ElectricBattery;
        public eLicenseType m_LicenseType { get; set; }
        public int m_EngineSize { get; set; }
        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            r_ElectricBattery = new ElectricBattery(4.8f);
            AddWheels(2, 30f);
            m_LicenseType = Enums.eLicenseType.None;
            m_EngineSize = 0;
        }

        public override float m_EnergyLeft
        {
            get
            {
                return r_ElectricBattery.EnergyLeft();
            }
            set
            {
                r_ElectricBattery.Recharge(value * r_ElectricBattery.m_CurrentChargeAmount / 100);
            }
        }
    }
}