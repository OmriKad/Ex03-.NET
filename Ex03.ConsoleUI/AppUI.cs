using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class AppUI
    {
        private Messages m_MessageStorage = new Messages();
        private string m_CarArt = @"                                   __..--""""""""           """"""""--..__              
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
'-O---O--'  Max                                              Max     '-O---O--'    

    ____                                                                        
 __/  |_\_                                                                      
|  _     _``-.                                                                 
'-(_)---(_)--'   Max                                     .-`""""""""""`-..  Max    
                                                    Max '=()===()=-'         

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
                         |  _      _`-.   Max                                 
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


        internal Enums.eAppState GetMenuSelection()
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
            System.Console.WriteLine("Please enter a path for the database directory : ");
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

        //public void ShowVehicleStatus(Vehicle modifiedVehicle)
        //{
        //    System.Console.WriteLine($"License Id : {modifiedVehicle.m_LicenseId}");
        //    System.Console.WriteLine($"Model Name : {modifiedVehicle.m_ModelName}");
        //}

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
            if (LicenseIDWithoutSpaces.All(char.IsDigit))
            {
                return LicenseID;

            }
            else
            {
                return null; // error handling
            }
        }

        internal Enums.eVehicleStatus GetRequiredState()
        {
            Enums.eVehicleStatus state;
            while (true)
            {
                System.Console.WriteLine("Please enter the state you want to filter by:");
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

        internal Enums.eVehicleStatus GetNewState()
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
        }
    }
}
