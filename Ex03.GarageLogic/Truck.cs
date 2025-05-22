namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_CarryDangeorusMaterial;
        private readonly float r_CargoVolume;

        public Truck(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
        }
    }
}