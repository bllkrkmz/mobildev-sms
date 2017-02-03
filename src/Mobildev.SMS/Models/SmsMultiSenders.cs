using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Mobildev.SMS.Enums;
using Mobildev.SMS.Extensions;

namespace Mobildev.SMS.Models
{
    [Serializable, XmlRoot("MainmsgBody")]
    public class SmsMultiSenders : BaseSms
    {
        [XmlElement("Messages")]
        public MultiMessages Messages { get; set; }

        [XmlElement("Originator")]
        public string DisplayName { get; set; }

        [XmlElement("SDate")]
        public string SendDate { get; set; }


        public static SmsMultiSenders Build(ActionTypes action, IEnumerable<MessageModel> messages, string userName, string password, string displayName)
        {
            return new SmsMultiSenders
            {
                UserName = userName,
                Password = password,
                Action = (int)action,
                Messages = MultiMessages.Build(messages),
                DisplayName = displayName,
                SendDate = DateTime.Now.ToString("ddMMyyyyhhmm")
            };
        }
    }

    [Serializable, XmlRoot(ElementName = "Messages")]
    public class MultiMessages
    {
        [XmlElement(ElementName = "Message")]
        public List<MultiMessage> Messages { get; set; }

        public static MultiMessages Build(IEnumerable<MessageModel> messages)
        {
            return new MultiMessages
            {
                Messages = messages.Select(MultiMessage.Build).ToList()
            };
        }
    }

    [Serializable, XmlRoot("Message")]
    public class MultiMessage
    {
        [XmlElement("Mesgbody")]
        public string Message { get; set; }

        [XmlElement("Number")]
        public string Number { get; set; }

        public static MultiMessage Build(MessageModel model)
        {
            return new MultiMessage
            {
                Message = model.Message.CleanHtmlTags().CleanInvalidChars(),
                Number = model.Number
            };
        }
    }
}