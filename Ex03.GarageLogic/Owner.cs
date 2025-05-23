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
    }
}
