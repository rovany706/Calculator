using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Data
    {
        private int _second;
        private int _minute;
        private int _hour;
        private int _day;
        private int _month;
        private int _year;

        public Data(int year, int month, int day, int hour, int minute, int second)
        {
            _year = year + (month + day / 31) / 12;
            _month = (month + day / 31) % 12;
            _day = day % 31;
            _hour = hour;
            _minute = minute;
            _second = second;
        }

        public int Second
        {
            get => _second;
            set
            {
                if (value < 0)
                {
                    Minute--;
                    _second = 60 - Math.Abs(value);
                    return;
                }

                if (value >= 60)
                {
                    Minute++;
                    _second = value - 60;
                    return;
                }

                _second = value;
            }
        }
        public int Minute
        {
            get => _minute;
            set
            {
                if (value < 0)
                {
                    Hour--;
                    _minute = 60 - Math.Abs(value);
                    return;
                }

                if (value >= 60)
                {
                    Hour++;
                    _minute = value - 60;
                    return;
                }

                _minute = value;
            }
        }
        public int Hour
        {
            get => _hour;
            set
            {
                if (value < 0)
                {
                    Day--;
                    _hour = 24 - Math.Abs(value);
                    return;
                }

                if (value >= 24)
                {
                    Day++;
                    _hour = value - 24;
                    return;
                }

                _hour = value;
            }

        }
        public int Day
        {
            get => _day;
            set
            {
                if (value <= 0)
                {
                    Month--;
                    _day = DaysInMonth(Year, Month) - value;
                    return;
                }

                int oldDaysInMonth = DaysInMonth(Year, Month);
                if (value > DaysInMonth(Year, Month))
                {
                    Month++;
                    _day = value - oldDaysInMonth;
                    return;
                }

                _day = value;
            }

        }

        public int Month
        {
            get => _month;
            set
            {
                if (value <= 0)
                {
                    Year--;
                    _month = 12 - value;
                    return;
                }

                if (value > 12)
                {
                    Year++;
                    _month = value - 12;
                    return;
                }

                _month = value;
            }
        }

        public int Year
        {
            get => _year;
            set => _year = value;
        }

        //Високосный ли год
        private static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 400 == 0)
                    return true;
                if (year % 100 == 0)
                    return false;
                return true;
            }

            return false;

        }

        //Возвращает количество дней в месяце
        private static int DaysInMonth(int year, int month)
        {
            switch (month)
            {
                case 2: //Февраль
                    if (IsLeapYear(year))
                        return 29;
                    return 28;
                case 8: //В августе 31 день
                    return 31;
                default: //Остальные месяцы
                    if (month % 2 == 1)
                        return 31;
                    return 30;
            }
        }

        public static bool operator >(Data d1, Data d2)
        {
            if (d1.Year == d2.Year)
            {
                if (d1.Month == d2.Month)
                {
                    if (d1.Day == d2.Day)
                    {
                        if (d1.Hour == d2.Hour)
                        {
                            if (d1.Minute == d2.Minute)
                            {
                                if (d1.Second > d2.Second)
                                    return true;
                            }
                            else if (d1.Minute > d2.Minute)
                                return true;
                        }
                        else if (d1.Hour > d2.Hour)
                            return true;
                    }
                    else if (d1.Day > d2.Day)
                        return true;
                }
                else if (d1.Month > d2.Month)
                    return true;
            }
            else if (d1.Year > d2.Year)
                return true;

            return false;
        }
        public static bool operator <(Data d1, Data d2)
        {
            if (d1.Year == d2.Year)
            {
                if (d1.Month == d2.Month)
                {
                    if (d1.Day == d2.Day)
                    {
                        if (d1.Hour == d2.Hour)
                        {
                            if (d1.Minute == d2.Minute)
                            {
                                if (d1.Second < d2.Second)
                                    return true;
                            }
                            else if (d1.Minute < d2.Minute)
                                return true;
                        }
                        else if (d1.Hour < d2.Hour)
                            return true;
                    }
                    else if (d1.Day < d2.Day)
                        return true;
                }
                else if (d1.Month < d2.Month)
                    return true;
            }
            else if (d1.Year < d2.Year)
                return true;

            return false;
        }

        public static Data operator -(Data d1, Data d2)
        {
            Data result = new Data(d1.Year - d2.Year, 0, 0, 0, 0, 0);
            if (d1 > d2)
            {
                result.Month -= d1.Month - d2.Month;
                result.Day -= d1.Day - d2.Day;
                result.Hour -= d1.Hour - d2.Hour;
                result.Minute -= d1.Minute - d2.Minute;
                result.Second -= d1.Second - d2.Second;
            }
            else
            {
                result.Month -= d2.Month - d1.Month;
                result.Day -= d2.Day - d1.Day;
                result.Hour -= d2.Hour - d1.Hour;
                result.Minute -= d2.Minute - d1.Minute;
                result.Second -= d2.Second - d1.Second;
            }

            return result;
        }
        public static Data operator +(Data d1, Data d2)
        {
            Data result = new Data(d1.Year + d2.Year, 0, 0, 0, 0, 0);
            result.Month += d1.Month + d2.Month;
            result.Day += d1.Day + d2.Day;
            result.Hour += d1.Hour + d2.Hour;
            result.Minute += d1.Minute + d2.Minute;
            result.Second += d1.Second + d2.Second;

            return result;
        }
    }
}
