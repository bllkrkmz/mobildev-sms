using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Mobildev.SMS.Enums;
using Mobildev.SMS.Extensions;

namespace Mobildev.SMS.Models
{
    [Serializable, XmlRoot("MainmsgBody")]
    public class SmsToMany : BaseSms
    {
        [XmlElement("Mesgbody")]
        public string Message { get; set; }

        [XmlElement("Numbers")]
        public string Numbers { get; set; }

        [XmlElement("Originator")]
        public string DisplayName { get; set; }

        [XmlElement("SDate")]
        public string SendDate { get; set; }

        public static SmsToMany Build(ActionTypes action, string message, IEnumerable<string> numbers, string userName, string password, string displayName)
        {
            return new SmsToMany
            {
                UserName = userName,
                Password = password,
                Action = (int)action,
                Message = message.CleanHtmlTags().CleanInvalidChars(),
                Numbers = string.Join(",", numbers),
                DisplayName = displayName,
                SendDate = DateTime.Now.ToString("ddMMyyyyhhmm")
            };
        }
    }
}