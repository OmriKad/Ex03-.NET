using System;
using System.Collections.Generic;
using System.IO;
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

        public List<string> GetLicensePlatesByStatus(Enums.eVehicleStatus status)
        {
            List<string> LicensePlates = new List<string>();
            foreach (Vehicle vehicle in r_LoadedVehicles.Values)
            {
                if (vehicle.m_Status == status)
                {
                    LicensePlates.Add(vehicle.m_LicenseId);
                }
            }
            return LicensePlates;
        }

        public void InflateTires(string LicenseId)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //foreach (Wheel wheel in vehicle.m_Wheels)
            //{
                

            //}


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

                parseLineToVehicle(line);
            }
        }

        public void ModifyVehicleStatus(string i_LicenseId, Enums.eVehicleStatus i_VehicleStatus)
        {
            if(!CheckIfPlateInGarage(i_LicenseId))
            {
                throw new ArgumentException($"Vehicle with license plate {i_LicenseId} not found in the garage.");
            }

            Vehicle vehicle = r_LoadedVehicles[i_LicenseId];
            vehicle.m_Status = i_VehicleStatus;
        }

        public void RechargeElectricVehicle(string LicenseId, Enums.eFuelType FuelType, int FuelAmount)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //recharge needed
        }

        public void RefuelVehicle(string LicenseId,Enums.eFuelType FuelType,int FuelAmount)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            vehicle.m_EnergyLeft = (100 - vehicle.m_EnergyLeft);
        }

        public bool CheckIfPlateInGarage(string i_Plate)
        {
            return r_LoadedVehicles.ContainsKey(i_Plate);
        }
      
        private void parseLineToVehicle(string i_Line)
        {
            string[] vehicleData = i_Line.Split(',');
            AssembleVehicleFromList(vehicleData);
        }

        public void AssembleVehicleFromList(string[] i_VehicleData)
        {
            string vehicleType = i_VehicleData[0];
            string licensePlate = i_VehicleData[1];
            string modelName = i_VehicleData[2];
            string energyPercentage = i_VehicleData[3];
            string tierModel = i_VehicleData[4];
            string currAirPressure = i_VehicleData[5];
            string ownerName = i_VehicleData[6];
            string ownerPhone = i_VehicleData[7];

            if (i_VehicleData.Length < VehicleCreator.SupportedTypes.Count)
            {
                throw new ValueRangeException(0f, VehicleCreator.SupportedTypes.Count);
            }

            if (!VehicleCreator.SupportedTypes.Contains(vehicleType))
            {
                throw new ArgumentException($"Vehicle type {vehicleType} is not supported.");
            }

            if (string.IsNullOrWhiteSpace(licensePlate) || string.IsNullOrWhiteSpace(modelName) ||
                string.IsNullOrWhiteSpace(tierModel) || string.IsNullOrWhiteSpace(currAirPressure) ||
                string.IsNullOrWhiteSpace(ownerName) || string.IsNullOrWhiteSpace(ownerPhone))
            {
                throw new ArgumentException("Invalid vehicle data provided.");
            }

            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
            Owner.IsValidPhone(ownerPhone);
            Owner owner = new Owner(ownerName, ownerPhone);
            vehicle.m_Owner = owner;
            vehicle.SetWheelsManufactureName(tierModel);
            vehicle.SetTirePressureForAllWheels(float.Parse(currAirPressure));
            vehicle.m_EnergyLeft = float.Parse(energyPercentage);

            switch (vehicleType)
            {
                case "FuelMotorcycle":
                case "ElectricMotorcycle":
                    IMotorcycle motorcycle = (IMotorcycle)vehicle;
                    motorcycle.m_LicenseType = (Enums.eLicenseType)Enum.Parse(typeof(Enums.eLicenseType), i_VehicleData[8]);
                    motorcycle.m_EngineSize = int.Parse(i_VehicleData[9]);
                    break;
                case "FuelCar":
                case "ElectricCar":
                    ICar car = (ICar)vehicle;
                    car.m_Color = (Enums.eVehicleColor)Enum.Parse(typeof(Enums.eVehicleColor), i_VehicleData[8]);
                    car.m_NumOfDoors = (Enums.eNumOfDoors)Enum.Parse(typeof(Enums.eNumOfDoors), i_VehicleData[9]);
                    break;
                case "Truck":
                    ITruck truck = (ITruck)vehicle;
                    truck.m_CarryDangeorusMaterial = bool.Parse(i_VehicleData[8]);
                    truck.m_CargoVolume = float.Parse(i_VehicleData[9]);
                    break;
            }

            r_LoadedVehicles.Add(licensePlate, vehicle);
        }

        public List<string> GetSpecificVehicleData(string i_Plate)
        {
            List<string> vehicleData = new List<string>();

            if (r_LoadedVehicles.ContainsKey(i_Plate))
            {
                Vehicle vehicle = r_LoadedVehicles[i_Plate];
                vehicleData.Add($"License Plate: {vehicle.m_LicenseId}");
                vehicleData.Add($"Model Name: {vehicle.m_ModelName}");
                vehicleData.Add($"Owner Name: {vehicle.m_Owner.m_Name}");
                vehicleData.Add($"Owner Phone: {vehicle.m_Owner.m_PhoneNumber}");
                vehicleData.Add($"Vehicle Status: {vehicle.m_Status}");
                vehicleData.Add($"Energy Left: {vehicle.m_EnergyLeft}");
            }
            else
            {
                throw new ArgumentException($"Vehicle with license plate {i_Plate} not found in the garage.");
            }

            return vehicleData;
        }
    }
}
