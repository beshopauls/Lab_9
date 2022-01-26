using System;
namespace lab_9
{
    public class TimeArray
    {
        public Time[] arr;
        int _size;
        public int Size
        {
            get { return _size; }
            set { if (value < 0) { _size = 0; } else { _size = value; } }
        }
        public TimeArray()
        {
            this.arr = new Time[_size];
        }
        public TimeArray(ref int size)
        {
            this._size = size;
            this.arr = new Time[_size];
            Random elements = new Random();    
            for (int i = 0; i < size; i++)
            {
                this.arr[i] = new Time();
                this.arr[i].Convert_Time(elements.Next(1, 59), elements.Next(1, 5), elements.Next(1, 59));
            }
        }
        public TimeArray(bool ex)
        {
            bool success;
            int size;
            do
            {
                Console.Write("Please enter size for array of time ");
                success = int.TryParse(Console.ReadLine(), out size);

            } while (!success);
            int hour, min, sec;          
            this._size = size;
            this.arr = new Time[size];
            for (int i = 0; i < size; i++)
            {
              
                Console.WriteLine("Please Enter Time (hours : minutes : seconds)=> " + (i + 1));
                do
                {
                    Console.WriteLine("Enter Hour");
                    success = int.TryParse(Console.ReadLine(), out hour);
                    if (!success) Console.WriteLine(" Please try again ");

                } while (!success);
                            
                do
                {
                    Console.WriteLine("Enter minute");
                    success = int.TryParse(Console.ReadLine(), out min);
                    if (!success) Console.WriteLine(" Please try again ");

                } while (!success);
                do
                {
                    Console.WriteLine("Enter sec");
                    success = int.TryParse(Console.ReadLine(), out sec);
                    if (!success) Console.WriteLine(" Please try again ");

                } while (!success);
                Time obj = new Time();
                this.arr[i] = obj.Convert_Time(min, hour, sec);
            }
        }
        public Time this[int numberOfTime]
        {
            get { return this.arr[numberOfTime]; }
            set { this.arr[numberOfTime] = value; }
        }
        public void display()
        {
            Console.WriteLine("Colection of time =>");
            for (int i = 0; i < this._size; i++)
                Console.WriteLine(" {0} : {1} :{2}", this.arr[i].hours, this.arr[i].minutes, this.arr[i].second);
        }
        public Time middle()
        {
            Time temp = new Time();
            for (int i = 0; i < this.Size; i++)
                temp = temp+ this[i];
            temp = temp/ Size;
            Console.Write("Middle ");
            temp.display();
            return temp;
        }
       ~TimeArray(){}
    }
}
