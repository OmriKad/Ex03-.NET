using static Ex03.GarageLogic.Enums;
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Vehicle, IMotorcycle
    {
        private FuelTank r_FuelTank { get; set; }

        public eLicenseType m_LicenseType { get; set; }

        public int m_EngineSize { get; set; }

        public FuelMotorcycle(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
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
            set
            {
                r_FuelTank.Refuel(value * r_FuelTank.r_MaxFuelAmount / 100, r_FuelTank.r_FuelType);
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
            details.AppendLine($"Fuel Type: {r_FuelTank.r_FuelType}");
            details.AppendLine($"Energy Amount: {r_FuelTank.EnergyLeft()}%");
            details.AppendLine("Wheels:");
            for(int i = 0; i < m_Wheels.Count; i++)
            {
                details.AppendLine(
                    $"  Wheel {i + 1}: Manufacturer - {m_Wheels[i].m_ManufacturerName}, Pressure - {m_Wheels[i].m_CurrentAirPressure}/{m_Wheels[i].m_MaxAirPressure}");
            }

            return details.ToString();
        }

        public override void FillPowerSource(float i_Amount, Enums.eFuelType i_FuelType)
        {
            r_FuelTank.Refuel(i_Amount, i_FuelType);
        }
    }
}