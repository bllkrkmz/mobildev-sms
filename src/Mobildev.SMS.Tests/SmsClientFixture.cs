using System;
using System.Collections.Generic;
using System.Globalization;
using Mobildev.SMS.Enum;
using Mobildev.SMS.Extensions;
using NUnit.Framework;

namespace Mobildev.SMS.Tests
{
    [TestFixture]
    public class SmsClientFixture
    {
        [Test]
        public void send_sms()
        {
            var smsClient = new SmsClient("*", "*");
            var result = smsClient.Send(ActionTypes.SmsToConcat, "Test mesaj", new List<string> { "*" }, "*");
            Console.WriteLine(result);
        }

        [Test]
        public void phone_number_fixture()
        {
            var numbers = new[] { null, "", "0090 (216) 428 53 33", "0090", "0090 (533) 240 68 54", "0090 (532) 396 45 50", "0090 (212) 454 10 0", "0 (212) 454 10 56", "+90 516 364 3347" };
            foreach (var number in numbers)
            {
                var phoneNumber = number.ToPhoneNumber();
                if (!phoneNumber.IsMobilePhoneNumber()) continue;
                Console.WriteLine(phoneNumber);
            }
        }

        [Test]
        public void get_user_info()
        {
            var smsClient = new SmsClient("**", "**");
            var result = smsClient.GetUserInfo(ActionTypes.UserInfo);
            Console.WriteLine(result);

        }
    }
}
