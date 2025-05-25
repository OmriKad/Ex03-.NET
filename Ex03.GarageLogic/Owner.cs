using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    public struct Owner
    {
        public string m_Name { get; set; }
        public string m_PhoneNumber { get; set; }
        public Owner(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public static void IsValidPhone(string i_OwnerPhone)
        {
            // Accept only format: 3 digits, dash, 7 digits
            if (string.IsNullOrWhiteSpace(i_OwnerPhone) ||
                i_OwnerPhone.Length != 11 ||
                i_OwnerPhone[3] != '-' ||
                !i_OwnerPhone.Substring(0, 3).All(char.IsDigit) ||
                !i_OwnerPhone.Substring(4, 7).All(char.IsDigit))
            {
                throw new ArgumentException("Owner's phone number must be in the format xxx-xxxxxxx (e.g. 050-1234567).");
            }
        }
    }
}
