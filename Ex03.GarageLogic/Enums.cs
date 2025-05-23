namespace Ex03.GarageLogic
{
    public static class Enums
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public enum eLicenseType
        {
            None,
            A,
            A2,
            AB,
            B2
        }

        public enum eVehicleColor
        {
            None,
            Yellow,
            White,
            Black,
            Silver
        }

        public enum eNumOfDoors
        {
            None = 0,
            Two = 2,
            Three,
            Four,
            Five
        }

        public enum eVehicleStatus
        {
            InRepair,
            Fixed,
            Paid
        }
    }
}