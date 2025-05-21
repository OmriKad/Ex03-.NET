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
        protected string m_ModelName { get; set; }
        protected string m_LicenseId { get; set; }

        public abstract float m_EnergyLeft { get; }

        protected List<Wheel> m_Wheels = new List<Wheel>();

        protected Vehicle(string i_LicenseID, string i_ModelName)
        {
            m_LicenseId = i_LicenseID;
            m_ModelName = i_ModelName;
        }

    }
}
