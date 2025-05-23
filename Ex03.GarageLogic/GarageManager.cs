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

        public void CheckInVehicle(string LicenseId)
        {
            if (r_LoadedVehicles.ContainsKey(LicenseId))
            {
                System.Console.WriteLine("This vehicle already exists in this garage.");

            }
            else
            {
                // vehicle creation missing here
                System.Console.WriteLine("Please enter vehicle type:");
                string type = System.Console.ReadLine();
                if (type.Contains("eletric"))
                {
                    System.Console.WriteLine("Please enter the energy presentage left : ");

                }
                else
                {
                    System.Console.WriteLine("Please enter the fuel presentage left : ");

                }
                string EnergyLeft = System.Console.ReadLine();
                System.Console.WriteLine("Please enter the air pressure currently in your wheels :  ");
                // wheel filling missing

                //if(Vehicle is car)
                System.Console.WriteLine("Please enter the color of your vehicle :  ");
                string color = System.Console.ReadLine();


                //if(vehicle is motorcycle)
                System.Console.WriteLine("Please enter your License type:  ");
                string LicenseType = System.Console.ReadLine();

                //(if vehicle is truck)
                System.Console.WriteLine("does your vehicle contains hazardous materials? y/n  ");
                string hazardousMaterials = System.Console.ReadLine();



            }
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

                Vehicle vehicle = parseLineToVehicle(line);
                r_LoadedVehicles[vehicle.m_LicenseId] = vehicle;
            }
        }

        public void ModifyVehicleStatus(string LicenseId, Enums.eVehicleStatus VehicleStatus)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];


        }

        public void RechargeElectricVehicle(string LicenseId, Enums.eFuelType FuelType, int FuelAmount)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //recharge needed
        }

        public void RefuelVehicle(string LicenseId,Enums.eFuelType FuelType,int FuelAmount)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //refuel needed

        }

        public void ShowAllVehicles()
        {
            throw new NotImplementedException();
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
