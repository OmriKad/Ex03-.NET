using System;
using static Ex03.GarageLogic.Enums;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, ITruck
    {
        private FuelTank r_FuelTank { get; set; }
        public bool m_CarryDangeorusMaterial { set; get; }
        public float m_CargoVolume { set; get; }

        public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            r_FuelTank = new FuelTank(Enums.eFuelType.Soler, 135f);
            AddWheels(12, 27f);
            m_CarryDangeorusMaterial = false;
            m_CargoVolume = 0f;
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
            details.AppendLine($"Can carry dangerous materials?: {m_CarryDangeorusMaterial}");
            details.AppendLine($"Cargo volume: {m_CargoVolume}");
            details.AppendLine($"Fuel Type: {r_FuelTank.r_FuelType}");
            details.AppendLine($"Energy Amount: {r_FuelTank.EnergyLeft()}%");
            details.AppendLine("Wheels:");
            for (int i = 0; i < m_Wheels.Count; i++)
            {
                details.AppendLine($"  Wheel {i + 1}: Manufacturer - {m_Wheels[i].m_ManufacturerName}, Pressure - {m_Wheels[i].m_CurrentAirPressure}/{m_Wheels[i].m_MaxAirPressure}");
            }

            return details.ToString();
        }

        public override void FillPowerSource(float i_Amount, Enums.eFuelType i_FuelType)
        {
            r_FuelTank.Refuel(i_Amount, i_FuelType);
        }
    }
}