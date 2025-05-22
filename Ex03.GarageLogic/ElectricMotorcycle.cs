namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Vehicle, IMotorcycle
    {
        private readonly ElectricBattery rElectricBattery;

        public ElectricMotorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }
    }
}