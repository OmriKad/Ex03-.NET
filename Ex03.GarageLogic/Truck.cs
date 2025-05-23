using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle, ITruck
    {
        private FuelTank r_FuelTank { get; set; }
        public bool m_CarryDangeorusMaterial { set; get; }
        public float m_CargoVolume { set; get; }

        public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            r_FuelTank = new FuelTank(Enums.eFuelType.Soler, 135);
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
                r_FuelTank.Refuel(value * r_FuelTank.r_MaxFuelAmount / 100);
            }
        }
    }
}