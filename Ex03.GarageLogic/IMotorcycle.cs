namespace Ex03.GarageLogic
{
    public interface IMotorcycle
    {
        Enums.eLicenseType m_LicenseType { get; }
        int m_EngineSize { get; }
    }
}