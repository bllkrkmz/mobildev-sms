using System;
using System.Xml.Serialization;

namespace Mobildev.SMS.Models
{
    [Serializable, XmlRoot("MainReportRoot")]
    public class UserInfo : BaseSms { }
}