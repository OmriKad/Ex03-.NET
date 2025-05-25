using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Enums;

namespace Ex03.ConsoleUI
{
    public class AppUI
    {
        private Messages m_MessageStorage = new Messages();
        private string m_CarArt = @"  
                                                 __..--""""""""           """"""""--..__              
                                          _.-""""""""""""""""""""""-----...      ______ `.            
                                       .-""                      l ,-""""    \ ""-.`.          
                                    .-""                         ; ;        ;   \ """"--.._   
                                  .'                           : :         |    ;      .l  
                            _.._.'                             ; ;  ___    |    ;    .' :  
                           (  .'                              : :  :   "".  :..-'   .'    ; 
                            )'                                | ;  ; __.'-""(     .'  .--.: 
                    ___...-'""""""""----....____          ______.-' :-/.'       \_.-'  .' .-.\l
            __..--""""                        """"""""""""""""""""          /\""          ;    / .gs./\;
        _.-""                                                   /  ;          |   . d$P""Tb  
     .-""""-,                       ____                        /   |          :   ;:$$   $; 
   .'     ;                    ,""""    """"--..__               /    :          |   $$$;   :$ 
  /""-._  /                     ;       ____..-'    .-""""""-.  /     :          ;  _$$$;   :$ 
 :     """"--.._          ___....+---""""""""          .'  _._  \/      |         _:-"" $$$;   :$ 
 ;                                              /  .d$$$b./       ;      .-"".'   :$$$   $P 
:            .----...____                      :  dP' `T$P        |   .-"" .' _.gd$$$$b_d$' 
;    __...---|    bug    |----....____         | :$     $b        : .'   (.-""  `T$$$$$$P'  
;  .';       '----...____;       /    ""-.      ; $;     :$;_____..-""  .-""                  
: /  :                          /        \__..-':$       $$ ;-.    .-""                     
 Y    ;                        /          ;     $;       :$;|  `.-""                        
 :    :                       /           |     $$       $$;:.-""                           
 '$$$ggggp...____            /            :     :$;     :$$                                
  $$$$$$$$$$$$   """"""""----...:________....gggg$$$$$$     $$;                                
  'T$$$$$$$$P'                           T$$$$$$$$$b._.d$P                                 
    `T$$$$P'                              T$$$$$$$$$$$$$P                                  
                                           `T$$$$$$$$$P'";



        static string MenuRepresentation = @".-'--`-._                                                            .-'--`-._     
'-O---O--'  Omri                                            Ori     '-O---O--'    

    ____                                                                        
 __/  |_\_                                                                      
|  _     _``-.                                                                 
'-(_)---(_)--'   Omri                                   .-`""""""""""`-..  Ori    
                                                    Ori '=()===()=-'         

+------------------------------------------------------------------------------+
| GARAGE APP MENU                                                              |
|                                                                              |
| 1. Load Vehicles from Database                                               |
| 2. Vehicle Check-In                                                          |
| 3. Display License Plate List                                                |
| 4. Update Vehicle Status                                                     |
| 5. Inflate Vehicle Tires                                                     |
| 6. Refuel a Vehicle                                                          |
| 7. Recharge Electric Vehicle                                                 |
| 8. Show All Vehicle Records                                                  |
| 9. Exit                                                                      |
|                                                                              |
| Please select an option [1-9]:                                               |
+------------------------------------------------------------------------------+

                          _.-.___\__                                          
                         |  _      _`-.   Omri                                
                         '-(_)----(_)--`                                      
";

        public void DisplayMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine(MenuRepresentation);

        }

        private int GetInputFromUser()
        {
            string UserInput = Console.ReadLine();
            if (int.TryParse(UserInput, out int ConvertedUserInput))
            {
                if (ConvertedUserInput < 1 || ConvertedUserInput > 9)
                {
                    m_MessageStorage.PrintInputOutOfRangeError();
                    ConvertedUserInput = int.MaxValue;
                }
            }
            else
            {
                m_MessageStorage.PrintInvalidInputError();
                ConvertedUserInput = int.MaxValue;

            }

            return ConvertedUserInput;
        }

        public string[] GetNewVehicleToCheckIn(string i_LicenseID)
        {
            string[] vehicleDetails = new string[10];
            vehicleDetails[0] = GetTypeOfVehicle();
            vehicleDetails[1] = i_LicenseID;
            vehicleDetails[2] = GetModelName();
            vehicleDetails[3] = GetEnergyPrecentage();
            vehicleDetails[4] = GetTireManufactureName();
            vehicleDetails[5] = GetCurrentAirPressure();
            vehicleDetails[6] = GetOwnerName();
            vehicleDetails[7] = GetOwnerPhone();
            switch (vehicleDetails[0])
            {
                case "FuelCar":
                case "ElectricCar":
                    vehicleDetails[8] = GetColor();
                    vehicleDetails[9] = GetNumOfDoors();
                    break;
                case "FuelMotorcycle":
                    vehicleDetails[8] = GetLicenseType();
                    vehicleDetails[9] = GetEngineSize();
                    break;
                case "ElectricMotorcycle":
                    vehicleDetails[8] = GetLicenseType();
                    vehicleDetails[9] = "0";
                    break;
                case "Truck":
                    vehicleDetails[8] = GetCanCarryDangerousMaterials();
                    vehicleDetails[9] = GetTruckCargoCapacity();
                    break;
            }

            return vehicleDetails;
        }

        public string GetTypeOfVehicle()
        {
            List<string> supportedTypes = VehicleCreator.SupportedTypes;
            Console.WriteLine("Please enter the type of vehicle you want to check in:");
            foreach (string supportedType in supportedTypes)
            {
                Console.WriteLine($"- {supportedType}");
            }

            string userInput = Console.ReadLine();
            if (!supportedTypes.Contains(userInput))
            {
                throw new ArgumentException($"Vehicle type {userInput} is not supported.");
            }

            return userInput;
        }

        public string GetModelName()
        {
            Console.WriteLine("Please enter the model name of the vehicle:");
            string modelName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentException("Model name cannot be empty.");
            }

            return modelName;
        }

        public string GetEnergyPrecentage()
        {
            Console.WriteLine("Please enter energy precentage:");
            string energyPercentage = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(energyPercentage) || !float.TryParse(energyPercentage, out float floatEnergyPercentage))
            {
                throw new ArgumentException("Energy percentage must be a valid number.");
            }

            if (floatEnergyPercentage < 0 || floatEnergyPercentage > 100)
            {
                throw new ValueRangeException(0f, 100f);
            }

            return energyPercentage;
        }

        public string GetTireManufactureName()
        {
            Console.WriteLine("Please enter the tire manufacture name:");
            string tireManufactureName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(tireManufactureName))
            {
                throw new ArgumentException("Tire manufacture name cannot be empty.");
            }

            return tireManufactureName;
        }

        public string GetCurrentAirPressure()
        {
            Console.WriteLine("Please enter the current air pressure:");
            string currentAirPressure = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(currentAirPressure) || !float.TryParse(currentAirPressure, out float floatCurrentAirPressure))
            {
                throw new ArgumentException("Current air pressure must be a valid number.");
            }

            if (floatCurrentAirPressure < 0 || floatCurrentAirPressure > 32)
            {
                throw new ValueRangeException(0f, 32f);
            }

            return currentAirPressure;
        }

        public string GetOwnerName()
        {
            Console.WriteLine("Please enter the owner's name:");
            string ownerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ownerName))
            {
                throw new ArgumentException("Owner's name cannot be empty.");
            }

            return ownerName;
        }

        public string GetOwnerPhone()
        {
            Console.WriteLine("Please enter the owner's phone number (format: xxx-xxxxxxx):");
            string ownerPhone = Console.ReadLine();
            Owner.IsValidPhone(ownerPhone);

            return ownerPhone;
        }

        public string GetLicenseType()
        {
            Console.WriteLine("Please enter the license type:");
            string licenseType = Console.ReadLine();
            if (licenseType == null || !Enum.IsDefined(typeof(Enums.eLicenseType), licenseType))
            {
                throw new ArgumentException("License type must be A, A2, AB, or B2.");
            }

            return licenseType;
        }

        public string GetEngineSize()
        {
            Console.WriteLine("Please enter the engine size:");
            string engineSize = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(engineSize) || !int.TryParse(engineSize, out int intEngineSize))
            {
                throw new ArgumentException("Engine size must be a valid number.");
            }

            if (intEngineSize <= 0)
            {
                throw new ValueRangeException(1f, 3000f);
            }

            return engineSize;
        }

        public string GetColor()
        {
            Console.WriteLine("Please enter the color of the vehicle:");
            string color = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(color) || !Enum.IsDefined(typeof(Enums.eVehicleColor), color))
            {
                throw new ArgumentException("Color must be Yellow, White, Black, or Silver.");
            }

            return color;
        }

        public string GetNumOfDoors()
        {
            Console.WriteLine("Please enter the number of doors:");
            string numOfDoors = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(numOfDoors) || !Enum.IsDefined(typeof(Enums.eNumOfDoors), numOfDoors))
            {
                throw new ValueRangeException((float)Enums.eNumOfDoors.Two, (float)Enums.eNumOfDoors.Five);
            }

            return numOfDoors;
        }

        public string GetCanCarryDangerousMaterials()
        {
            Console.WriteLine("Does the vehicle carry dangerous materials? (yes/no):");
            string canCarryDangerousMaterials = Console.ReadLine();
            if (canCarryDangerousMaterials == null || (canCarryDangerousMaterials.ToLower() != "yes" && canCarryDangerousMaterials.ToLower() != "no"))
            {
                throw new ArgumentException("Please enter 'yes' or 'no'.");
            }

            return canCarryDangerousMaterials;
        }

        public string GetTruckCargoCapacity()
        {
            Console.WriteLine("Please enter Truck's cargo capacity:");
            string truckCargoCapacity = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(truckCargoCapacity) || !float.TryParse(truckCargoCapacity, out float floatTruckCargoCapacity) || floatTruckCargoCapacity < 0)
            {
                throw new ArgumentException("Truck's cargo capacity must be a valid number.");
            }

            return truckCargoCapacity;
        }

        public Enums.eAppState GetMenuSelection()
        {
            int UserInput = GetInputFromUser();
            Enums.eAppState nextAppState;

            switch (UserInput)
            {
                case 1:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.LoadDatabase;
                    break;

                case 2:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.CheckInVehicle;
                    break;

                case 3:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.ShowLicensePlates;
                    break;

                case 4:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.UpdateVehicleStatus;
                    break;

                case 5:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.InflateTires;
                    break;

                case 6:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.RefuelVehicle;
                    break;

                case 7:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.RechargeElectricVehicle;
                    break;

                case 8:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.ShowAllVehicles;
                    break;

                case 9:
                    System.Console.Clear();
                    nextAppState = Enums.eAppState.Exit;
                    break;

                default:
                    System.Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    nextAppState = Enums.eAppState.Menu;
                    break;
            }

            return nextAppState;
        }

        public bool GetIfFilter()
        {
            bool Result;
            while (true)
            {
                System.Console.WriteLine("Do you want to filter the vehicles by state?");
                System.Console.WriteLine("1. yes");
                System.Console.WriteLine("2. no");
                string UserInput = Console.ReadLine();
                if (UserInput == "1")
                {
                    Result = true;
                    break;
                }
                else if (UserInput == "2")
                {
                    Result = false;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid input. Please enter 1 or 2.");
                }
            }

            return Result;
        }


        public string GetDatabasePath()
        {
            System.Console.WriteLine("Please enter the database directory file name ({file_name}.db): ");
            System.Console.WriteLine("enter q to return to the menu");
            string Path = Console.ReadLine();
            return Path;
        }

        public void DisplayData(List<string> i_DataList)
        {
            System.Console.Clear();
            foreach (string data in i_DataList)
            {
                System.Console.WriteLine(data);
            }
        }

        public void PrintCarArt()
        {
            System.Console.WriteLine(m_CarArt);
            Thread.Sleep(1000);
            System.Console.Clear();
        }
        public string GetLicenseID()
        {
            Console.WriteLine("Please enter the License ID:");
            string LicenseID = System.Console.ReadLine();
            string LicenseIDWithoutSpaces = LicenseID.Replace("-", "");
            if (!LicenseIDWithoutSpaces.All(char.IsDigit))
            {
                throw new ArgumentException("The ID is not Valid!");

            }

            return LicenseID;
        }

        public Enums.eVehicleStatus GetNewState()
        {
            Enums.eVehicleStatus state;
            while (true)
            {
                System.Console.WriteLine("Please enter the new state:");
                System.Console.WriteLine("1. InRepair");
                System.Console.WriteLine("2. Fixed");
                System.Console.WriteLine("3. Paid");
                string UserInput = Console.ReadLine();
                if (UserInput == "1")
                {
                    state = Enums.eVehicleStatus.InRepair;
                    break;
                }
                else if (UserInput == "2")
                {
                    state = Enums.eVehicleStatus.Fixed;
                    break;
                }
                else if (UserInput == "3")
                {
                    state = Enums.eVehicleStatus.Paid;
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }

            return state;
        }

        internal void SuccessMessage()
        {
            Console.WriteLine("Operation successfull!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        internal void DisplayError(string i_Message)
        {
            Console.WriteLine(i_Message);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}