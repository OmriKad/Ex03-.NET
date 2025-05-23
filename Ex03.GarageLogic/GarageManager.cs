using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_LoadedVehicles;

        public GarageManager()
        {
            r_LoadedVehicles = new Dictionary<string, Vehicle>();
        }

        public List<string> GetAllLicensePlates()
        {
            List<string> LicensePlates = new List<string>();
            foreach (Vehicle vehicle in r_LoadedVehicles.Values)
            {
                LicensePlates.Add(vehicle.m_LicenseId);
            }
            return LicensePlates;
        }

        public void LoadDatabase(string FilePath)
        {
            string[] lines = System.IO.File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line == "*****")
                {
                    break;
                }

                Vehicle vehicle = parseLineToVehicle(line);
                r_LoadedVehicles[vehicle.m_LicenseId] = vehicle;
            }
        }

        private Vehicle parseLineToVehicle(string i_Line)
        {
            string[] parts = i_Line.Split(',');
            string vehicleType = parts[0];
            string licensePlate = parts[1];
            string modelName = parts[2];
            string energyPercentage = parts[3];
            string tierModel = parts[4];
            string currAirPressure = parts[5];
            string ownerName = parts[6];
            string ownerPhone = parts[7];

            if (parts.Length < VehicleCreator.SupportedTypes.Count)
            {
                throw new ValueRangeException(0f, VehicleCreator.SupportedTypes.Count);
            }

            if (!VehicleCreator.SupportedTypes.Contains(vehicleType))
            {
                throw new ArgumentException($"Vehicle type {vehicleType} is not supported.");
            }

            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
            vehicle.SetWheelsManufactureName(tierModel);
            vehicle.SetTirePressureForAllWheels(float.Parse(currAirPressure));
            vehicle.m_EnergyLeft = float.Parse(energyPercentage);

            switch(vehicleType)
            {
                case "FuelMotorcycle":
                case "ElectricMotorcycle":
                    IMotorcycle motorcycle = (IMotorcycle)vehicle;
                    motorcycle.m_LicenseType = (Enums.eLicenseType)Enum.Parse(typeof(Enums.eLicenseType), parts[8]);
                    motorcycle.m_EngineSize = int.Parse(parts[9]);
                    break;
                case "FuelCar":
                case "ElectricCar":
                    ICar car = (ICar)vehicle;
                    car.m_Color = (Enums.eVehicleColor)Enum.Parse(typeof(Enums.eVehicleColor), parts[8]);
                    car.m_NumOfDoors = (Enums.eNumOfDoors)Enum.Parse(typeof(Enums.eLicenseType), parts[9]);
                    break;
                case "Truck":
                    ITruck truck = (ITruck)vehicle;
                    truck.m_CargoVolume = float.Parse(parts[8]);
                    truck.m_CarryDangeorusMaterial = bool.Parse(parts[9]);
                    break;
            }
            return vehicle;
        }
    }
}
