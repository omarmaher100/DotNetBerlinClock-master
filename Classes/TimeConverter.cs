using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            string[] time = aTime.Split(':');

            int hours = int.Parse(time[0]);
            int minutes = int.Parse(time[1]);
            int seconds = int.Parse(time[2]);

            char firstSeries = BuildFirstSeriesForSecond(seconds);
            string secondSeries = BuildSecondSeriesForHour(hours);
            string thirdSeries = BuildThirdSeriesForHour(hours);
            string fourthSeries = BuildFourthSeriesForMinutes(minutes);
            string fifthSeries = BuildFifthSeriesForMinutes(minutes);
            
            return $"{firstSeries}\r\n{secondSeries}\r\n{thirdSeries}\r\n{fourthSeries}\r\n{fifthSeries}";
        }


        static char BuildFirstSeriesForSecond(int second)
        {
            return (second % 2) == 0 ? 'Y' : 'O';
        }

        static string BuildSecondSeriesForHour(int hour)
        {
            //e.g. 22/5=4; 11/5=2
            return BuildSeriesForHours(hour / 5);
        }

        static string BuildThirdSeriesForHour(int hour)
        {
            //e.g 22-(22/5)*5=6; 13-(13/5)*5=3
            return BuildSeriesForHours(hour - (hour / 5) * 5);
        }

        static string BuildFourthSeriesForMinutes(int min)
        {
            int spots = min / 5;
            var builder = new StringBuilder();

            for (int i = 0; i < 11; i++)
            {
                if (i < spots)
                {
                    if (i == 2 || i == 5 || i == 8)
                    {
                        builder.Append('R');
                    }
                    else
                    {
                        builder.Append('Y');
                    }
                }
                else
                {
                    builder.Append('O');
                }
            }

            return builder.ToString();
        }

        static string BuildFifthSeriesForMinutes(int min)
        {
            int spots = min - (min / 5) * 5;
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'Y' : 'O');
            }

            return builder.ToString();
        }

        static string BuildSeriesForHours(int spots)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'R' : 'O');
            }

            return builder.ToString();
        }
    }
}
