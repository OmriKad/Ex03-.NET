namespace Ex03.GarageLogic
{
    public interface IMotorcycle
    {
        Enums.eLicenseType m_LicenseType { get; set; }
        int m_EngineSize { get; set; }
    }
}