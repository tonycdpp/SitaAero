using System.Collections.Generic;

namespace SitaAssignment.Configuration
{
    public interface IMailHandlersConfiguration
    {
        List<MailHandler> MailHandlers { get; set; }
    }

    public class MailHandlersConfiguration : IMailHandlersConfiguration
    {
        public List<MailHandler> MailHandlers { get; set; }
    }
}