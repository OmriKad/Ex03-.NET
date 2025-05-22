using static Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Vehicle, IMotorcycle
    {
        private readonly FuelTank rFuelTank;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {

        }
    }
}