using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_ModelName { get; set; }
        private string m_LicenseId { get; set; }
        private float m_EnergyLeft { get; set; }

        private List<Wheel> m_Wheels = new List<Wheel>();
    }
}
