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

        private Vehicle parseLineToVehicle(string line)
        {
            string[] parts = line.Split(',');
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
            switch (vehicleType)
            {
                case "FuelMotorcycle":
                    string licenseType = parts[8];
                    string engineSize = parts[9];
                    

            }


            return vehicle;
        }
    }
}
