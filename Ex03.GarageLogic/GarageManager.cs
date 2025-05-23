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

        public void InflateTires()
        {
            throw new NotImplementedException();
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

                Vehicle vehicle = parseLineToVehicle(line);
                r_LoadedVehicles[vehicle.m_LicenseId] = vehicle;
            }
        }

        public void ModifyVehicleStatus()
        {
            
            System.Console.WriteLine("Please enter a vehicle license plate id:");

            

        }

        public void RechargeElectricVehicle(GarageManager m_GarageManager)
        {
            throw new NotImplementedException();
        }

        public void RefuelVehicle()
        {
            throw new NotImplementedException();
        }

        public void ShowAllVehicles()
        {
            throw new NotImplementedException();
        }

        private Vehicle parseLineToVehicle(string line)
        {
            string[] parts = line.Split(',');
            string type = parts[0];
            string license = parts[1];
            string model = parts[2];

            //type error handling

            Vehicle vehicle = VehicleCreator.CreateVehicle(type, license, model);





            return vehicle;
        }
    }
}
