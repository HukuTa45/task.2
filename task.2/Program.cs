using System;
using System.Collections;
using System.Collections.Generic;

namespace task._2
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumWeekDay week = new EnumWeekDay();

            foreach (var day in week)
            {
                Console.WriteLine($"День недели: {((WeekDayName)day).NameWeekDay}");
            }
        }

        class EnumWeekDay : IEnumerable
        {
            WeekDayName[] day = { new WeekDayName("Понедельник"), new WeekDayName("Вторник"), new WeekDayName("Среда"), new WeekDayName("Четверг"), new WeekDayName("Пятница"), new WeekDayName("Суббота"), new WeekDayName("Воскресенье") };

            public IEnumerator GetEnumerator()
            {
                return new DayEnum(day);
            }
        }

        class WeekDayName
        {
            private string weekDayName;

            public WeekDayName(string weekDayName)
            {
                this.weekDayName = weekDayName;
            }

            public string NameWeekDay
            {
                get
                {
                    return weekDayName;
                }
                set
                {
                    weekDayName = value;
                }
            }
        }

        class DayEnum : IEnumerator
        {
            WeekDayName[] days;
            int position = -1;
            public DayEnum(WeekDayName[] day)
            {
                this.days = day;
            }
            public object Current
            {
                get
                {
                    if (position == -1 || position >= days.Length)
                        throw new InvalidOperationException();
                    return days[position];
                }
            }

            public bool MoveNext()
            {
                if (position < days.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                position = -1;
            }

        }

    }
}
