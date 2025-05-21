using System;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {
        private readonly FuelTank r_FuelTank;
        public override float m_EnergyLeft
        {
            get
            {
                return r_FuelTank.m_CurrentFuelAmount;
            }
        }
        protected FuelVehicle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }

        public void Refuel(Enums.eFuelType i_FuelType, float i_Amount)
        {
            if (i_FuelType != r_FuelTank.FuelType)
            {
                throw new ArgumentException("Fuel type mismatch");
            }
            r_FuelTank.Refuel(i_Amount);
        }
    }
}
