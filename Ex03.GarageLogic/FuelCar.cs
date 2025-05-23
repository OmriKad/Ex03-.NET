namespace Ex03.GarageLogic
{
    public class FuelCar : Vehicle, ICar
    {
        private FuelTank r_FuelTank { get; set; }
        public Enums.eVehicleColor m_Color  { get; set; }
        public Enums.eNumOfDoors m_NumOfDoors { get; set; }

        public FuelCar(string i_LicenseID, string i_ModelName)
            : base(i_LicenseID, i_ModelName)
        {
            r_FuelTank = new FuelTank(Enums.eFuelType.Octan95, 48f);
            AddWheels(5, 32f);
            m_Color = Enums.eVehicleColor.None;
            m_NumOfDoors = Enums.eNumOfDoors.None;
        }

        public override float m_EnergyLeft
        {
            get
            {
                return r_FuelTank.EnergyLeft();
            }
            set
            {
                r_FuelTank.m_CurrentFuelAmount = value * r_FuelTank.r_MaxFuelAmount / 100;
            }
        }
    }
}
