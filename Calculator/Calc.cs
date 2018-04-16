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
            res = Butt1(res, USARadioButton, dateTimePicker1, dateTimePicker1);
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
            string dt1 = one.ToString();
            string[] dat = dt1.Split('.', ':', ' ');
            string dt2 = two.ToString();
            string[] dat2 = dt2.Split('.', ':', ' ');
            month = Convert.ToInt32(dat[0]);
            day = Convert.ToInt32(dat[1]);
            year = Convert.ToInt32(dat[2]);
            hour = Convert.ToInt32(dat[3]);
            minute = Convert.ToInt32(dat[4]);
            second = Convert.ToInt32(dat[5]);
            month2 = Convert.ToInt32(dat2[0]);
            day2 = Convert.ToInt32(dat2[1]);
            year2 = Convert.ToInt32(dat2[2]);
            hour2 = Convert.ToInt32(dat2[3]);
            minute2 = Convert.ToInt32(dat2[4]);
            second2 = Convert.ToInt32(dat2[5]);

            if (!rus)//если рос. формат
            {
                day = Convert.ToInt32(dat[0]);
                month = Convert.ToInt32(dat[1]);
                day2 = Convert.ToInt32(dat2[0]);
                month2 = Convert.ToInt32(dat2[1]);
            }
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
            string dt3 = three.ToString();
            string[] dat3 = dt3.Split('.', ':', ' ');
            month = Convert.ToInt32(dat3[0]);
            day = Convert.ToInt32(dat3[1]);
            year = Convert.ToInt32(dat3[2]);
            hour = Convert.ToInt32(dat3[3]);
            minute = Convert.ToInt32(dat3[4]);
            second = Convert.ToInt32(dat3[5]);
            if (!rus)//если рос. формат
            {
                day = Convert.ToInt32(dat3[0]);
                month = Convert.ToInt32(dat3[1]);
            }
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
            tx = ("1) data1 - data2 = кол-во месяцев " + NumMonth(data1 - data2) + "\n2) data1 - data2 = кол-во недель " + NumWeek(data1 - data2) +
                  "\n3) data1 - data2 = кол-во дней " + NumDay(data1 - data2) + "\n4) data1 - data2 = кол-во часов " + NumHour(data1 - data2) + "\n5) data1 - data2 = кол-во минут " + NumMinute(data1 - data2) +
                  "\n6) data1 - data2 = кол-во секунд " + NumSec(data1 - data2));
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
            Data data2 = new Data(0, month2, 0, 0, 0, 0);
            Data data3 = new Data(0, 0, day2, 0, 0, 0);
            if (one)
                tx = ("1) data1 + месяцы = data2  " + PrintData(data1 + data2, rus) + "\n2) data1 +дни = data2  " + PrintData(data1 + data3, rus)).ToString();
            else
                tx = ("1) data1 - месяцы = data2  " + PrintData(data1 - data2, rus) + "\n2) data1 - дни = data2  " + PrintData(data1 - data3, rus)).ToString();
            return tx;
        }
        static string PrintData(Data data, bool rus)
        {
            if (!rus)
            {
                return data.Month.ToString() + "." + data.Day.ToString() + "." + data.Year.ToString() + " " + data.Hour + ":" + data.Minute + ":" + data.Second;
            }
            else
                return data.Day.ToString() + "." + data.Month.ToString() + "." + data.Year.ToString() + " " + data.Hour + ":" + data.Minute + ":" + data.Second;
        }
        /// <summary>
        /// перевод
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>

        //перевод в месяцы
        static int NumMonth(Data dat)
        {
            return dat.Month + dat.Year / 365;
        }
        //перевод в недели
        static int NumWeek(Data dat)
        {
            return dat.Day / 7 + dat.Month / 4 + dat.Year / 52;
        }
        //перевод в дни
        static int NumDay(Data dat)
        {
            return NumWeek(dat) * 7;
        }
        //перевод в часы
        static int NumHour(Data dat)
        {
            return NumDay(dat) * 24;
        }
        //перевод в минуты
        static int NumMinute(Data dat)
        {
            return NumHour(dat) * 60;
        }
        //перевод в секунды
        static int NumSec(Data dat)
        {
            return NumMinute(dat) * 60;
        }


    }
}
