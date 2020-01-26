namespace SitaAssignment.Configuration
{
    public interface IConnectionStrings
    {
        string XmlFile { get; set; }
    }

    public class ConnectionStrings : IConnectionStrings
    {
        public string XmlFile { get; set; }
    }
}