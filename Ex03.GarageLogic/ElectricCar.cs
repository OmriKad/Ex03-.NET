using System.Text;

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
              r_ElectricBattery.Recharge(value * r_ElectricBattery.r_MaxChargeAmount / 100);
          }
      }

      public override string GetVehicleDetails()
      {
          StringBuilder details = new StringBuilder();
          details.AppendLine($"License ID: {m_LicenseId}");
          details.AppendLine($"Model Name: {m_ModelName}");
          details.AppendLine($"Owner: {m_Owner.m_Name}");
          details.AppendLine($"Status: {m_Status}");
          details.AppendLine($"Color: {m_Color}");
          details.AppendLine($"Number of Doors: {m_NumOfDoors}");
          details.AppendLine($"Energy Amount: {r_ElectricBattery.EnergyLeft()}%");
          details.AppendLine("Wheels:");
          for (int i = 0; i < m_Wheels.Count; i++)
          {
              details.AppendLine($"  Wheel {i + 1}: Manufacturer - {m_Wheels[i].m_ManufacturerName}, Pressure - {m_Wheels[i].m_CurrentAirPressure}/{m_Wheels[i].m_MaxAirPressure}");
          }

          return details.ToString();
      }

      public override void FillPowerSource(float i_Amount, Enums.eFuelType i_FuelType)
      {
          r_ElectricBattery.Recharge(i_Amount);
      }
    }
}