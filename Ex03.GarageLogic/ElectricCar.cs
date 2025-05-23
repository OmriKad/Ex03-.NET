namespace Ex03.GarageLogic
{
    public class ElectricCar : Vehicle, ICar
    {
      private readonly ElectricBattery r_ElectricBattery;
      public Enums.eVehicleColor m_Color { get; set; }
      public Enums.eNumOfDoors m_NumOfDoors { get; set; }
      public ElectricCar(string i_LicenseID, string i_ModelName)
          : base(i_LicenseID, i_ModelName)
      { 
          r_ElectricBattery = new ElectricBattery(4.8f);
          AddWheels(5, 32f);
          m_Color = Enums.eVehicleColor.None; 
          m_NumOfDoors = Enums.eNumOfDoors.None;
      }

      public override float m_EnergyLeft
      {
          get
          {
              return r_ElectricBattery.EnergyLeft();
          }
          set
          {
              r_ElectricBattery.Recharge(value * r_ElectricBattery.m_CurrentChargeAmount / 100);
      }
    }
}