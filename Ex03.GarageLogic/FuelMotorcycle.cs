using static Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Vehicle, IMotorcycle
    {
        private FuelTank r_FuelTank { get; set; }
        public eLicenseType m_LicenseType { get; set; }
        public int m_EngineSize { get; set; }

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            r_FuelTank = new FuelTank(Enums.eFuelType.Octan98, 5.8f);
            AddWheels(2, 30f);
            m_LicenseType = Enums.eLicenseType.None;
            m_EngineSize = 0;
        }

        public override float m_EnergyLeft
        {
            get
            {
                return r_FuelTank.EnergyLeft();
            }
        }
    }
}