using System.Xml.Serialization;

namespace Mobildev.SMS.Models
{
    public class BaseSms
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }

        [XmlElement("PassWord")]
        public string Password { get; set; }

        [XmlElement("Action")]
        public int Action { get; set; }
    }
}