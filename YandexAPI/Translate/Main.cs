using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YandexAPI.Translate
{
    public static class Main
    {
        public static string Start(string texxt, string lng)
        {
            string json = Request.API(texxt, lng);

            var obj = JsonConvert.DeserializeObject<Model>(json);

            int code = obj.code;

            string text;

            switch(code)
            {
                case 200:
                    text = obj.text[0];
                    break;
                case 401:
                    text = "Неправильный API ключ.";
                    break;
                case 402:
                    text = "API ключ был заблокирован.";
                    break;
                case 404:
                    text = "Привышено количество трафика на сегодня.";
                    break;
                case 413:
                    text = "Текст слишком большой.";
                    break;
                case 422:
                    text = "Внутренняя ошибка сервера. Текст не может быть переведён. Попробуйте позже.";
                    break;
                case 501:
                    text = "Язык был выбран не верно.";
                    break;
                default:
                    text = "Неизвестная ошибка перевода. Попробуйте позже.";
                    break;
            }

            return text;
        }

    }
}
