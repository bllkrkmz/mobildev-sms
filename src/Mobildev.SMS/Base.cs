using System;
using System.Xml.Serialization;

namespace Mobildev.SMS
{
    public class Base
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }

        [XmlElement("PassWord")]
        public string Password { get; set; }

        [XmlElement("Action")]
        public int Action { get; set; }
    }
}