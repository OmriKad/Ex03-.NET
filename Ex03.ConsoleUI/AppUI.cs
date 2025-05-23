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


        public string GetDatabasePath()
        {
            System.Console.WriteLine("Please enter a path for the database directory : ");
            System.Console.WriteLine("enter q to return to the menu");
            string Path = Console.ReadLine();
            return Path;
        }


        public void DisplayLicensePlates(List<string> plates)
        {
            foreach (string plate in plates)
            {
                System.Console.WriteLine(plate);
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
            string LicenseID = System.Console.ReadLine();
            if (LicenseID.All(char.IsDigit))
            {
                return LicenseID;

            }
            else
            {
                return null; // error handling
            }
        }




    }
}
