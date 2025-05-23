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

                Vehicle vehicle = parseLineToVehicle(line);
                r_LoadedVehicles[vehicle.m_LicenseId] = vehicle;
            }
        }

        public void ModifyVehicleStatus(string LicenseId)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];


        }

        public void RechargeElectricVehicle(string LicenseId)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //recharge needed
        }

        public void RefuelVehicle(string LicenseId)
        {
            Vehicle vehicle = r_LoadedVehicles[LicenseId];
            //refuel needed

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
