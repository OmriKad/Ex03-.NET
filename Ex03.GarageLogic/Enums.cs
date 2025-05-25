namespace Ex03.GarageLogic
{
    public static class Enums
    {
        public enum eFuelType
        {
            None,
            Octan95,
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

        public enum eAppState
        {
            Menu = 1 ,
            LoadDatabase ,
            CheckInVehicle,
            ShowLicensePlates,
            UpdateVehicleStatus,
            InflateTires,
            RefuelVehicle,
            RechargeElectricVehicle,
            ShowAllVehicles,
            Exit
        }
    }
}