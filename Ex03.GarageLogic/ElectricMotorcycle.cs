namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private readonly Enums.eLicenseType r_LicenseType;
        private readonly int r_EngineSize;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }
    }
}