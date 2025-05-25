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
                try
                {
                    switch(m_CurrentState)
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
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.CheckInVehicle:
                            string licenseID = m_AppUI.GetLicenseID();
                            if (m_GarageManager.GetAllLicensePlates().Contains(licenseID))
                            {
                                m_GarageManager.ModifyVehicleStatus(licenseID, Enums.eVehicleStatus.InRepair);
                                m_AppUI.DisplayError("Vehicle already exists in the garage, status updated to InRepair.");
                                m_CurrentState = Enums.eAppState.Menu;
                                break;
                            }

                            m_GarageManager.AssembleVehicleFromList(m_AppUI.GetNewVehicleToCheckIn(licenseID));
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.ShowLicensePlates:
                            List<string> plates;
                            if (!m_AppUI.GetIfFilter())
                            {
                                plates = m_GarageManager.GetAllLicensePlates();
                            }
                            else
                            {
                                Enums.eVehicleStatus state = m_AppUI.GetNewState();
                                plates = m_GarageManager.GetLicensePlatesByStatus(state);
                            }

                            m_AppUI.DisplayData(plates);
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.UpdateVehicleStatus:
                            m_AppUI.DisplayData(m_GarageManager.GetAllLicensePlates());
                            m_GarageManager.ModifyVehicleStatus(m_AppUI.GetLicenseID(), m_AppUI.GetNewState());
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.InflateTires:
                            m_AppUI.DisplayData(m_GarageManager.GetAllLicensePlates());
                            m_GarageManager.InflateTires(m_AppUI.GetLicenseID());
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.RefuelVehicle:
                            m_AppUI.DisplayData(m_GarageManager.GetAllLicensePlates());
                            m_GarageManager.RefuelVehicle(m_AppUI.GetLicenseID(), m_AppUI.GetFuelType(), m_AppUI.GetFuelAmount());
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.RechargeElectricVehicle:
                            m_AppUI.DisplayData(m_GarageManager.GetAllLicensePlates());
                            m_GarageManager.RechargeElectricVehicle(m_AppUI.GetLicenseID(), m_AppUI.GetElectricityAmount());
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;

                        case Enums.eAppState.ShowAllVehicles:
                            m_AppUI.DisplayData(m_GarageManager.GetAllLicensePlates());
                            string dataInfo = m_GarageManager.GetSpecificVehicleData(m_AppUI.GetLicenseID());
                            Console.WriteLine(dataInfo);
                            m_AppUI.SuccessMessage();
                            m_CurrentState = Enums.eAppState.Menu;
                            break;
                    }
                }

                catch (Exception e)
                {
                    m_AppUI.DisplayError(e.Message);
                    m_CurrentState = Enums.eAppState.Menu;
                }
                finally
                {
                    System.Console.Clear();
                }
            }
        }
    }
}