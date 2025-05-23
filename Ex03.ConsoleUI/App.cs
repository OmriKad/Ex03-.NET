using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

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
            while (m_CurrentState != Enums.eAppState.Exit)
            {
                switch (m_CurrentState)
                {
                    case Enums.eAppState.Menu:
                        m_AppUI.DisplayMenu();
                        m_CurrentState = m_AppUI.GetMenuSelection();
                        break;

                    case Enums.eAppState.LoadDatabase:
                        string dbPath = m_AppUI.PromptForDatabasePath();
                        m_GarageManager.LoadDatabase(dbPath);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.CheckInVehicle:
                        m_AppUI.CheckInVehicle();
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.ShowLicensePlates:
                        List<string> plates = m_GarageManager.GetAllLicensePlates();
                        m_AppUI.DisplayLicensePlates(plates);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.UpdateVehicleStatus:
                        m_AppUI.UpdateVehicleStatus(m_GarageManager);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.InflateTires:
                        m_AppUI.InflateTires(m_GarageManager);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.RefuelVehicle:
                        m_AppUI.RefuelVehicle(m_GarageManager);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.RechargeVehicle:
                        m_AppUI.RechargeElectricVehicle(m_GarageManager);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;

                    case Enums.eAppState.ShowAllVehicles:
                        m_AppUI.ShowAllVehicles(m_GarageManager);
                        m_CurrentState = Enums.eAppState.Menu;
                        break;
                }
            }

            //m_AppUI.PrintExitMessage();
        }

    }
}
