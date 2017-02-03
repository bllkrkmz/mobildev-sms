using System.Collections.Generic;
using Mobildev.SMS.Enums;
using Mobildev.SMS.Models;

namespace Mobildev.SMS
{
    public interface ISmsClient
    {
        string Send(ActionTypes action, string message, IEnumerable<string> numbers, string displayName);
        string Send(ActionTypes action, IEnumerable<MessageModel> messages, string displayName);
        string GetUserInfo(ActionTypes action);
    }
}