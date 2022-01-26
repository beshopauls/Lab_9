using System;
using System.Runtime.InteropServices;
namespace lab_9
{
    public class Time
    {
        int _hours;
        int _minutes;
        int _second;
        public static int count = 0;
        public Time()
        {
            count++;
        }
        public int hours
        {
            get => _hours; 
            set {
                if (value < 0)
                    hours = 0;
                else
                    this._hours = value; }
        }
        public int minutes
        {
            get => _minutes; 
            set
            {
                if (value < 0)
                    minutes = 0;
                else
                    this._minutes = value; }
        }
        public int second
        {
            get => _second; 
            set
            {
                if (value < 0)
                    second = 0;
                else
                    this._second = value; }
        }
        public Time(int h, int m, [Optional] int s)
        {
            count++;
            this._hours = h;
            this._minutes = m;
            this._second = s;
        }
        public Time(Time obj)
        {
            count++;
            this._hours = obj._hours;
            this._minutes = obj._minutes;
            this._second = obj._second;
        }
        public Time Convert_Time(int min, [Optional] int hou, [Optional] int sec)
        {

            if ((min >= 0 && hou >= 0 && sec >= 0) || (min >= 0))
            {
                hours += hou;
                minutes += min;
                second += sec;
            }
            else return this;
            int temphour, tempmin;
            while (hours > 23 || minutes > 59 || second > 59)
            {
                if(hours >23)
                    hours -= 24;
                if (minutes > 59)
                {
                    temphour = minutes / 60;
                    minutes -= (temphour * 60);
                    hours += temphour;
                }
                if (second > 59)
                {
                    tempmin = second / 60;
                    second -= (tempmin * 60);
                    minutes += tempmin;
                }
                if (hours <= 23 && minutes <= 59 && second <= 59)
                    break;
            }
            return this;
        }
        // Static 
        public static Time Convert_Time_static(int min, [Optional] int hou, [Optional] int sec)
        {
            Time obj = new Time();          
            if ((min >= 0 && hou >= 0 && sec >= 0) || (min >= 0))
            {
                obj.hours += hou;
                obj.minutes += min;
                obj.second += sec; 
            }
            else return obj;
            int temphour, tempmin;
            while (obj.minutes > 59 || obj.second > 59)
            {
                if (obj.minutes > 59)
                {
                    temphour = obj.minutes / 60;
                    obj.minutes -= (temphour * 60);
                    obj.hours += temphour;
                }
                if (obj.second > 59)
                {
                    tempmin = obj.second / 60;
                    obj.second -= (tempmin * 60);
                    obj.minutes += tempmin;
                }
                if (obj.hours <= 23 && obj.minutes <= 59 && obj.second <= 59)
                    break;
            }
            return obj;
        }
        public static Time operator ++(Time obj)
        {
            obj.minutes++;
            if (obj.hours <= 23 && obj.minutes <= 59 && obj.second <= 59)
                return new Time(obj);
            else
                return Convert_Time_static(obj.minutes, obj.hours, obj.second);
        }
        public static Time operator --(Time obj)
        {
            if ((obj.hours <= 23 && obj.minutes <= 59 && obj.second <= 59) && (obj.minutes > 0))
            {
                obj.minutes--;
                return new Time(obj);
            }
            else
            {
                obj.minutes--;
                return Convert_Time_static(obj.minutes, obj.hours, obj.second);
            }
        }
        public static Time operator +(Time obj1, Time obj2)
        {
            Time temp = new Time();
            temp.hours = obj1.hours + obj2.hours;
            temp.minutes = obj1.minutes + obj2.minutes;
            temp.second = obj1.second + obj2.second;   
            return temp;
        }
        public static Time operator +(Time obj1, int min)
        {
            Time temp = new Time();
            temp = temp.Convert_Time(obj1.minutes + min , obj1.hours , obj1.second);
            return temp;
        }     
        public static Time operator -(Time obj1, Time obj2)
        {
            Time temp = new Time();
            temp.hours = obj1.hours - obj2.hours;
            temp.minutes = obj1.minutes - obj2.minutes;
            temp.second = obj1.second - obj2.second;
            return temp;
        }
        public static Time operator -(Time obj1, int min)
        {
            Time temp = new Time();
            temp = temp.Convert_Time(obj1.minutes - min, obj1.hours, obj1.second);
            return temp;
        }

        public static Time operator *(Time obj1, Time obj2)
        {
            Time temp = new Time();
            temp.hours = obj1.hours * obj2.hours;
            temp.minutes = obj1.minutes * obj2.minutes;
            temp.second = obj1.second * obj2.second;
            return temp;
        }
        public static Time operator /(Time obj1, Time obj2)
        {
            Time temp = new Time();
            temp.hours = obj1.hours / obj2.hours;
            temp.minutes = obj1.minutes / obj2.minutes;
            temp.second = obj1.second / obj2.second;
            return temp;
        }
        
        public static Time operator /(Time obj1, int num)
        {
            Time temp = new Time();
            temp = temp.Convert_Time(obj1.minutes / num , obj1.hours / num, obj1.second / num );
            return temp;
        }
        public void display()
        {
            Console.WriteLine(" Time is  {0} : {1} : {2}", this._hours, this._minutes, this._second);
        }
        // Static 
        public static void display_static(Time ob)
        {
            Console.WriteLine(" Time is  {0} : {1} : {2}", ob.hours, ob.minutes, ob.second);
        }
        public static explicit operator int(Time ob)
        {
            return ob.minutes;
        }
        public static implicit operator bool(Time ob)
        {
            return ob.hours == 0 && ob.minutes == 0;
        }
        public int Compare(object x, object y)
        {
            Time time1 = x as Time;
            Time time2 = y as Time;
            if (time1 == null && time2 == null)
                return -1;
            return time1.hours.CompareTo(time2.hours)
                ^ time1.minutes.CompareTo(time2.minutes)
                ^ time1.second.CompareTo(time2.second);
        }
        ~Time()
        {
            count--;
        }
    }
}
