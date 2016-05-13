using System.Collections.Generic;
using Mobildev.SMS.Enum;

namespace Mobildev.SMS
{
    public interface ISmsClient
    {
        string Send(ActionTypes action, string body, IEnumerable<string> numbers, string displayName);

        string GetUserInfo(ActionTypes action);
    }
}