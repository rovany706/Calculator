using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public static class Calc
    {
        private static int second;
        private static int minute;
        private static int hour;
        private static int day;
        private static int month;
        private static int year;
        private static int second2;
        private static int minute2;
        private static int hour2;
        private static int day2;
        private static int month2;
        private static int year2;
        public static string DistanceBetweenDates(DateTime dateTimePicker1,
            DateTime dateTimePicker2, bool USARadioButton)
        {
            string res = null;
            res = Butt1(res, USARadioButton, dateTimePicker1, dateTimePicker2);
            return res;
        }
        public static string DateСalculation(DateTime dateTimePicker3, string textBox1,
            string textBox2, bool radioButton1, bool USARadioButton)
        {
            string res = null;
            res = Butt2(res, USARadioButton, textBox1, textBox2, dateTimePicker3, radioButton1);
            return res;

        }


        public static void Part1(bool rus, DateTime one, DateTime two)
        {
            //конвертирование данных в даты
            month = one.Month;
            day = one.Day;
            year = one.Year;
            hour = one.Hour;
            minute = one.Minute;
            second = one.Second;

            month2 = two.Month;
            day2 = two.Day;
            year2 = two.Year;
            hour2 = two.Hour;
            minute2 = two.Minute;
            second2 = two.Second;
        }
        /// <summary>
        /// вторая часть программы
        /// </summary>
        /// <param name="rus"></param>
        /// <param name="mn"></param>
        /// <param name="d"></param>
        /// <param name="three"></param>
        public static void Part2(bool rus, string mn, string d, DateTime three)
        {
            //конвертирование в данных в даты
            month = three.Month;
            day = three.Day;
            year = three.Year;
            hour = three.Hour;
            minute = three.Minute;
            second = three.Second;
            
            if (mn != null && mn != "")
                month2 = Convert.ToInt32(mn);
            else
                month2 = 0;
            if (d != null && d != "")
                day2 = Convert.ToInt32(d);
            else
                day2 = 0;

        }
        /// <summary>
        /// действия при нажатии на 1 кнопку
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="rus"></param>
        /// <param name="one"></param>
        /// <param name="two"></param>
        public static string Butt1(string tx, bool rus, DateTime one, DateTime two)
        {
            Part1(rus, one, two);
            Data data1 = new Data(year, month, day, hour, minute, second);
            Data data2 = new Data(year2, month2, day2, hour2, minute2, second2);
            tx = "1) data1 - data2 = кол-во месяцев " + NumMonth(data1 - data2) + "\n2) data1 - data2 = кол-во недель " + NumWeek(data1 - data2) +
                 "\n3) data1 - data2 = кол-во дней " + NumDay(data1 - data2) + "\n4) data1 - data2 = кол-во часов " + NumHour(data1 - data2) + "\n5) data1 - data2 = кол-во минут " + NumMinute(data1 - data2) +
                 "\n6) data1 - data2 = кол-во секунд " + NumSec(data1 - data2);
            return tx;
        }
        /// <summary>
        /// действие при нажатии на 2 кнопку
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="rus"></param>
        /// <param name="mn"></param>
        /// <param name="d"></param>
        /// <param name="three"></param>
        public static string Butt2(string tx, bool rus, string mn, string d, DateTime three, bool one)
        {
            Part2(rus, mn, d, three);
            Data data1 = new Data(year, month, day, hour, minute, second);
            Data data2 = new Data(0, month2, day2, 0, 0, 0);
            Data result = data1 - data2;
            if (one)
                tx = "1) data1 + месяцы + дни = " + PrintData(result, rus);
            else
                tx = "1) data1 - месяцы - дни = " + PrintData(result, rus);
            return tx;
        }
        static string PrintData(Data data, bool rus)
        {
            if (!rus)
            {
                return data.Month + "." + data.Day + "." + data.Year + " " + data.Hour + ":" + data.Minute + ":" + data.Second;
            }
            else
                return data.Day + "." + data.Month + "." + data.Year + " " + data.Hour + ":" + data.Minute + ":" + data.Second;
        }
        /// <summary>
        /// перевод
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>

        //перевод в месяцы
        static int NumMonth(Data dat)
        {
            return dat.Month + dat.Year * 12;
        }
        //перевод в недели
        static int NumWeek(Data dat)
        {
            return dat.Day / 7 + dat.Month * 4 + dat.Year * 52;
        }
        //перевод в дни
        static int NumDay(Data dat)
        {
            return dat.Month * 31 + dat.Year * 365 + dat.Day;
        }
        //перевод в часы
        static int NumHour(Data dat)
        {
            return NumDay(dat) * 24 + dat.Hour;
        }
        //перевод в минуты
        static int NumMinute(Data dat)
        {
            return NumHour(dat) * 60 + dat.Minute;
        }
        //перевод в секунды
        static int NumSec(Data dat)
        {
            return NumMinute(dat) * 60 + dat.Second;
        }


    }
}
