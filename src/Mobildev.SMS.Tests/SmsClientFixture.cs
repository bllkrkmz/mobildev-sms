using System;
using System.Collections.Generic;
using Mobildev.SMS.Enums;
using Mobildev.SMS.Extensions;
using Mobildev.SMS.Models;
using NUnit.Framework;

namespace Mobildev.SMS.Tests
{
    [TestFixture]
    public class SmsClientFixture
    {
        private SmsClient _smsClient;

        [SetUp]
        public virtual void Init()
        {
            _smsClient = new SmsClient("*", "*");
        }

        [Test]
        public void send_sms_to_many()
        {
            var result = _smsClient.Send(ActionTypes.SmsToManyConcat, "test SMS", new List<string> { "*" }, "*");

            Console.WriteLine(result);
        }
        [Test]
        public void send_sms_multi()
        {
            var result = _smsClient.Send(ActionTypes.SmsMultiSendersConcat, new List<MessageModel> { new MessageModel { Message = "test SMS xxx", Number = "*" }, new MessageModel { Message = "test SMS yyy", Number = "*" } }, "*");
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
            var result = _smsClient.GetUserInfo(ActionTypes.UserInfo);
            Console.WriteLine(result);

        }
    }
}
