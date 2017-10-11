using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Command
{
    public static class About
    {
        public static void Start(string dialog)
        {
            string msg = "МАЙК БОТ\nСБОРКА: 0.0.10.09.test1\nРАЗРАБОТЧИК: [fooxboy|Славик Смирнов]\n Все права на бота принадлежат [id317386320|Александру Ткачёву]. \nИНФОРМАЦИЯ GIT:\n-Первый коммит: 05.09.2017 22:32:01 (Славик Лис <FooxBoy@yandex.ru>)\n-Последний коммит: 09.10.2017 21:01 (Славик Лис <FooxBoy@yandex.ru>)\n-Ветвь: master\n-Общее количество комминтов: 122 начиная с 05.09.2017 22:32:01";
            Bot.API.Message.Send(msg, dialog);
        }
    }
}
