using System;
using System.Collections.Generic;
using System.Text;

namespace MikeBot.Mafia.Logic
{

    //TODO: Переписать на нормальный вид.
    public static class Distribution
    {
        public static string[] Start(int count_players)
        {
            if (count_players < 5)
            {
                //Идите нахуй, вы не играете
                return error();
            }
            else
            {
                switch (count_players)
                {
                    case 5:
                        return players5();
                    case 6:
                        return players6();
                    case 7:
                        return players7();
                    case 8:
                        return players8();
                    case 9:
                        return players9();
                    case 10:
                        return players10();
                    default:
                        return error();
                }
            }
        }

        private static string[] error()
        {
            string[] array = new string[2];
            array[0] = "ошибка";
            array[1] = "Неизвестная";
            return array;
        }

        private static string[] players5()
        {
            //Обязательно: Мирный, бандит,алкоголик, заказной киллер
            string[] array = new string[5];

            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            return array;
        }

        private static string[] players6()
        {
            string[] array = new string[6];
            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[6] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            return array;
        }

        private static string[] players7()
        {
            //обязательно должен быть шериф
            string[] array = new string[6];
            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[6] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[7] = Mafia.Characters.get[2];//шериф
            return array;
        }

        private static string[] players8()
        {
            //обязательно будет начинающий бандит
            string[] array = new string[6];
            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[6] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[7] = Mafia.Characters.get[2];//шериф
            array[8] = Mafia.Characters.get[9];//начинающий бандит
            return array;
        }
        private static string[] players9()
        {
            //обязательно гадалка
            string[] array = new string[6];
            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[6] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[7] = Mafia.Characters.get[2];//шериф
            array[8] = Mafia.Characters.get[9];//начинающий бандит
            array[9] = Mafia.Characters.get[6]; //гадалка
            return array;
        }

        private static string[] players10()
        {
            //обязательно блудница
            string[] array = new string[6];
            System.Random rand = new System.Random();
            array[0] = Mafia.Characters.get[0]; //мирный
            array[1] = Mafia.Characters.get[1]; //бандит
            array[2] = Mafia.Characters.get[7]; //Алкоголик
            array[3] = Mafia.Characters.get[10]; //заказной киллер
            array[4] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //рандом
            array[5] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[6] = Mafia.Characters.get[rand.Next(0, Mafia.Characters.get.Length)]; //ранжом
            array[7] = Mafia.Characters.get[2];//шериф
            array[8] = Mafia.Characters.get[9];//начинающий бандит
            array[9] = Mafia.Characters.get[6]; //гадалка
            array[10] = Mafia.Characters.get[4]; //блудница
            return array;
        }
    }
}
