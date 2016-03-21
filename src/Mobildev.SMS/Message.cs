using System;
using System.Xml.Serialization;

namespace Mobildev.SMS
{
    [Serializable, XmlRoot("MainmsgBody")]
    public class Message :Base
    {
        [XmlElement("Mesgbody")]
        public string Body { get; set; }

        [XmlElement("Numbers")]
        public string Number { get; set; }

        [XmlElement("Originator")]
        public string DisplayName { get; set; }

        [XmlElement("SDate")]
        public string SendDate { get; set; }
    }
}