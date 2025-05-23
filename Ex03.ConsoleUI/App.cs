using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class App
    {
        private AppUI m_AppUI;
        private GarageManager m_GarageManager;
        private Enums.eAppState m_CurrentState = Enums.eAppState.Menu;


        public App()
        {
            m_AppUI = new AppUI();
            m_GarageManager = new GarageManager();
        }



        public void Run()
        {
            m_AppUI.PrintCarArt();
            while (m_CurrentState != Enums.eAppState.Exit)
            {
                switch (m_CurrentState)
                {
                    case Enums.eAppState.Menu:
                        m_AppUI.DisplayMenu();
                        m_CurrentState = m_AppUI.GetMenuSelection();
                        break;

                    case Enums.eAppState.LoadDatabase:
                        string dbPath = m_AppUI.GetDatabasePath();
                        if (dbPath == "q")
                        {
                            m_CurrentState = Enums.eAppState.Menu;
                            System.Console.Clear();
                            break;
                        }
                        m_GarageManager.LoadDatabase(dbPath);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.CheckInVehicle:
                        m_GarageManager.CheckInVehicle(m_AppUI.GetLicenseID()); // needs to be changed
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.ShowLicensePlates:
                        List<string> plates = m_GarageManager.GetAllLicensePlates();
                        m_AppUI.DisplayLicensePlates(plates);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.UpdateVehicleStatus:
                        //Vehicle ModifiedVehicle
                        m_GarageManager.ModifyVehicleStatus(m_AppUI.GetLicenseID(), m_AppUI.GetNewState());
                        //m_AppUI.ShowVehicleStatus(); will be garage manager function
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.InflateTires:
                        m_GarageManager.InflateTires(m_AppUI.GetLicenseID());
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.RefuelVehicle:
                        m_GarageManager.RefuelVehicle(m_AppUI.GetLicenseID(), m_AppUI.GetFuelType(), m_AppUI.GetFuelAmount()); // needs to be changed
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.RechargeElectricVehicle:
                        m_GarageManager.RechargeElectricVehicle(m_AppUI.GetLicenseID(), m_AppUI.GetFuelAmount()); // needs to be changed
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.ShowAllVehicles:
                        m_GarageManager.ShowAllVehicles();  // needs to be changed
                        m_CurrentState = Enums.eAppState.Menu;
                        break;
                }
            }
        }
    }

}
