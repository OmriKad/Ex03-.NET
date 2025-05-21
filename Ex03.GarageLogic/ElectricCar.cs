namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private readonly Enums.eVehicleColor r_Color;
        private readonly Enums.eNumOfDoors r_NumOfDoors;


        public ElectricCar(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }
    }
}