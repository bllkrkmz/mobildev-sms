using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Mobildev.SMS.Enums;
using Mobildev.SMS.Extensions;
using Mobildev.SMS.Models;

namespace Mobildev.SMS
{
    public class SmsClient : ISmsClient
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly IDictionary<string, string> _exMessages;

        public SmsClient(string userName, string password)
        {
            _userName = userName;
            _password = password;
            _exMessages = new Dictionary<string, string>
            {
                {"01", "Hatalı Kullanıcı Adı, Hatalı Şifre, Hatalı Bayi Kodu"},
                {"02", "Yetersiz kredi"},
                {"03", "Tanımsız Action parametresi"},
                {"04", "Gelen XML yok"},
                {"05", "XML düğümü eksik ya da hatalı"},
                {"06", "Tanımsız Orijinatör bilgisi"},
                {"07", "Mesaj kodu (ID) yok"},
                {"08", "Verilen tarihler arasında SMS gönderimi yok"},
                {"09", "Tarih alanları boş - hatalı"},
                {"10", "SMS gönderilemedi"},
                {"11", "Tanımlanamayan hata"},
                {"12", "Mesaj Metni alanı boş"},
                {"13", "Mesaj metni alanı 268 karakterden uzun"},
                {"14", "GSM Numara(ları) boş bırakılamaz"},
                {"15", "Hatalı Gönderim Tarihi"}
            };
        }

        public string Send(ActionTypes action, string message, IEnumerable<string> numbers, string displayName)
        {
            var result = SendRequest(SmsToMany.Build(action, message, numbers, _userName, _password, displayName));

            if (_exMessages.ContainsKey(result))
                throw new Exception(_exMessages[result]);

            return result;
        }

        public string Send(ActionTypes action, IEnumerable<MessageModel> messages, string displayName)
        {
            var result = SendRequest(SmsMultiSenders.Build(action, messages, _userName, _password, displayName));

            if (_exMessages.ContainsKey(result))
                throw new Exception(_exMessages[result]);

            return result;
        }

        public string GetUserInfo(ActionTypes action)
        {
            var userInfo = new UserInfo
            {
                UserName = _userName,
                Password = _password,
                Action = (int)action
            };
            var result = SendRequest(userInfo);

            if (_exMessages.ContainsKey(result))
                throw new Exception(_exMessages[result]);

            return result;
        }

        private static string SendRequest<T>(T obj)
        {
            using (var client = new HttpClient())
            {
                var postData = obj.Serialize(Encoding.UTF8, true);
                var content = new StringContent(postData, Encoding.UTF8);
                var request = client.PostAsync("http://8bit.mobilus.net/", content).Result;
                var result = request.Content.ReadAsStringAsync().Result;
                return result;
            }
        }
    }
}
