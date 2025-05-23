using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public readonly string m_ModelName;
        public readonly string m_LicenseId;

        public abstract float m_EnergyLeft { get; set; }

        public List<Wheel> m_Wheels;

        protected Vehicle(string i_LicenseID, string i_ModelName)
        {
            m_LicenseId = i_LicenseID;
            m_ModelName = i_ModelName;
            m_Wheels = new List<Wheel>();
        }

        public void AddWheels(int i_numOfWheelsToAdd, float i_MaxAirPressure)
        {
            for (int i = 0; i < i_numOfWheelsToAdd; i++)
            {
                m_Wheels.Add(new Wheel(0, i_MaxAirPressure));
            }
        }

        public void SetWheelsManufactureName(string i_ManufactureName)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.m_ManufacturerName = i_ManufactureName;
            }
        }

        public void SetSpecificWheelTirePressure(int i_TireNumber, float i_TirePressure)
        {
            m_Wheels[i_TireNumber].Inflate((i_TirePressure));
        }

        public void SetTirePressureForAllWheels(float i_TirePressure)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.Inflate(i_TirePressure);
            }
        }
    }
}
