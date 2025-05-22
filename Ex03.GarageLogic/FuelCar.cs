namespace Ex03.GarageLogic
{
    public class FuelCar : Vehicle, Icar
    {
        private readonly FuelTank rFuelTank;

        public FuelCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            
        }

    }
}
