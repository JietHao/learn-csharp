using Microsoft.VisualBasic;
using System;

namespace learn.code
{
    public static class Instance
    {
        public static long ServerMinusClientTime = 0;
    }


    //精确到毫秒。。。
    public class TimeInfo
    {
        enum TimePointType : byte
        {
            tp_Hourly = 0,
            tp_Daily,
            tp_Weekly,
            tp_Monthly,
            tp_Customly,
        }

        public delegate void handleOnTime();

        public handleOnTime? _hour_handle;
        public handleOnTime? _daily_handle;
        public handleOnTime? _daily_zero_handle;
        public handleOnTime? _week_handle;
        public handleOnTime? _month_handle;

        private int timeZone;

        public const long _hour_seconds = 3600 * 1000;
        public const long _day_seconds = 24 * _hour_seconds;
        public const long _week_seconds = 7 * _day_seconds;
        public int TimeZone
        {
            get
            {
                return this.timeZone;
            }
            set
            {
                this.timeZone = value;
                dt = dt1970.AddHours(TimeZone);
            }
        }

        private DateTime dt1970;
        private DateTime dt;

        public long ServerMinusClientTime { private get; set; }

        public long FrameTime;

        public TimeInfo()
        {
            this.dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            this.dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            this.FrameTime = this.ClientNow();
            _hourly_date = gen_next_date(0, 0, 0, 0, TimePointType.tp_Hourly);
            _daily_date = gen_next_date(0, 4, 0, 0, TimePointType.tp_Daily);
            _daily_date_zero = gen_next_date(0, 0, 0, 0, TimePointType.tp_Daily);
            _weekly_date = gen_next_date(0, 0, 0, 0, TimePointType.tp_Weekly);
            _monthly_date = gen_next_date(1, 0, 0, 0, TimePointType.tp_Monthly);
        }

        public void Update()
        {
            this.FrameTime = this.ClientNow();
            if (FrameTime - _hourly_point >= _hour_seconds)
            {
                _hourly_date = _hourly_date.AddHours(1);
                _hour_handle?.Invoke();
            }
            if (FrameTime - _daily_point >= _day_seconds)
            {
                _daily_date = _daily_date.AddDays(1);
                _daily_handle?.Invoke();
            }
            if (FrameTime - _daily_point_zero >= _day_seconds)
            {
                _daily_date_zero = _daily_date_zero.AddDays(1);
                _daily_zero_handle?.Invoke();
                if (FrameTime - _weekly_point >= _week_seconds)
                {
                    _weekly_date.AddDays(7);
                    _week_handle?.Invoke();
                }
                var monthly_date = gen_next_date(1, 0, 0, 0, TimePointType.tp_Monthly);
                if (_monthly_date != monthly_date)
                {
                    _monthly_date = monthly_date;
                    _month_handle?.Invoke();
                }
            }
        }

        /// <summary> 
        /// 根据时间戳获取时间 
        /// </summary>  
        /// 
        public DateTime ToDateTime(long timeStamp)
        {
            return dt.AddTicks(timeStamp * 10000);
        }

        public string ToDateTimeStr(long timeStamp, string fmt="yyyy-MM-dd HH:mm:ss")
        {
            return ToDateTime(timeStamp).ToString(fmt);
        }

        // 线程安全
        public long ClientNow()
        {
            return (DateTime.UtcNow.Ticks - this.dt1970.Ticks) / 10000;
        }

        public long ServerNow()
        {
            return ClientNow() + Instance.ServerMinusClientTime;
        }

        public long ClientFrameTime()
        {
            return this.FrameTime;
        }

        public long ServerFrameTime()
        {
            return this.FrameTime + Instance.ServerMinusClientTime;
        }

        public long Transition(DateTime d)
        {
            return (d.Ticks - dt.Ticks) / 10000;
        }

        public long _hourly_point
        {
            get { return (_hourly_date.ToUniversalTime().Ticks - this.dt1970.Ticks) / 10000; }
        }
        public long _daily_point
        {
            get { return (_daily_date.ToUniversalTime().Ticks - this.dt1970.Ticks) / 10000; }
        }
        public long _daily_point_zero
        {
            get { return (_daily_date_zero.ToUniversalTime().Ticks - this.dt1970.Ticks) / 10000; }
        }
        public long _weekly_point
        {
            get { return (_weekly_date.ToUniversalTime().Ticks - this.dt1970.Ticks) / 10000; }
        }
        public long _monthly_point
        {
            get { return (_monthly_date.ToUniversalTime().Ticks - this.dt1970.Ticks) / 10000; }
        }


        private DateTime _hourly_date;
        private DateTime _daily_date;
        private DateTime _daily_date_zero;
        private DateTime _weekly_date;
        private DateTime _monthly_date;
        private DateTime inner_gen_next_date(int day, int hour, int minute, int second, TimePointType t)
        {
            DateTime cur_date = DateTime.Now;
            DateTime triger_data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, DateTimeKind.Local);
            //long triger_time = triger_data.Ticks - DateTime.UtcNow.Ticks;
            if (t != TimePointType.tp_Hourly)
            {
                triger_data = triger_data.AddHours(hour);
            }
            else
            {
                triger_data = triger_data.AddHours(DateTime.Now.Hour);
            }
            triger_data.AddMinutes(minute);
            triger_data.AddSeconds(second);
            if (TimePointType.tp_Weekly == t)
            {
                triger_data = triger_data.AddDays(day + 1 - (int)cur_date.DayOfWeek);
            }
            else
            {
                if (TimePointType.tp_Monthly == t)
                {
                    triger_data = triger_data.AddDays(day - cur_date.Day);
                    while (triger_data.Day != day)
                    {
                        triger_data = new DateTime(triger_data.Year, triger_data.Month + 1, day, hour, minute, second, DateTimeKind.Local);
                    }
                }
            }
            while (triger_data < cur_date)
            {
                triger_data = inner_next_date(triger_data, t);
            }
            return triger_data;
        }
        private DateTime gen_next_date(int day, int hour, int minute, int second, TimePointType t)
        {
            var date = inner_gen_next_date(day, hour, minute, second, t);
            if (t == TimePointType.tp_Monthly)
            {
                date = new DateTime(date.Year, date.Month - 1, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Local);
            }
            else if (t == TimePointType.tp_Daily)
            {
                date = date.AddDays(-1);
            }
            else if (t == TimePointType.tp_Weekly)
            {
                date = date.AddDays(-7);
            }
            else if (t == TimePointType.tp_Hourly)
            {
                date = date.AddHours(-1);
            }
            return date;
        }

        private DateTime inner_next_date(DateTime date, TimePointType t)
        {
            switch (t)
            {
                case TimePointType.tp_Hourly:
                    {
                        date = date.AddHours(1);
                        break;
                    }

                case TimePointType.tp_Daily:
                    {
                        date = date.AddDays(1);
                        break;
                    }
                case TimePointType.tp_Weekly:
                    {
                        date = date.AddDays(7);
                        break;
                    }
                case TimePointType.tp_Monthly:
                    {
                        int day = date.Day;
                        do
                        {
                            date = date.AddMonths(1);
                        } while (date.Day != day);
                        break;
                    }
                default:
                    {

                    }
                    break;
            }
            return date;
        }

        public static void main()
        {
            Console.WriteLine($" now: {new TimeInfo().ServerNow()}");
        }
    }
}
