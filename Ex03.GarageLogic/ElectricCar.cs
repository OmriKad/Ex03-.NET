namespace Ex03.GarageLogic
{
    public class ElectricCar : Vehicle, ICar

    {
    private readonly ElectricBattery rElectricBattery;

    public ElectricCar(string i_LicenseID, string i_ModelName)
        : base(i_LicenseID, i_ModelName)
    {
    }
    }
}