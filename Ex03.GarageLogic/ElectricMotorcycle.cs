using System.Text;
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
                r_ElectricBattery.Recharge(value * r_ElectricBattery.r_MaxChargeAmount / 100);
            }
        }

        public override string GetVehicleDetails()
        {
            StringBuilder details = new StringBuilder();
            details.AppendLine($"License ID: {m_LicenseId}");
            details.AppendLine($"Model Name: {m_ModelName}");
            details.AppendLine($"Owner: {m_Owner.m_Name}");
            details.AppendLine($"Status: {m_Status}");
            details.AppendLine($"Licence Type: {m_LicenseType}");
            details.AppendLine($"Engine size: {m_EngineSize}");
            details.AppendLine($"Energy Amount: {r_ElectricBattery.EnergyLeft()}%");
            details.AppendLine("Wheels:");
            for (int i = 0; i < m_Wheels.Count; i++)
            {
                details.AppendLine(
                    $"  Wheel {i + 1}: Manufacturer - {m_Wheels[i].m_ManufacturerName}, Pressure - {m_Wheels[i].m_CurrentAirPressure}/{m_Wheels[i].m_MaxAirPressure}");
            }

            return details.ToString();
        }

        public override void FillPowerSource(float i_Amount, Enums.eFuelType i_FuelType)
        {
            r_ElectricBattery.Recharge(i_Amount);
        }
    }
}