using static Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : FuelVehicle
    {
        private readonly Enums.eLicenseType r_LicenseType;
        private readonly int r_EngineSize;

        public FuelMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {

        }
    }
}