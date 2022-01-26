using System;
namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t Lab 9");
            int size = 5;bool success;
            Time time1 = new Time(4, 300, 260);
            Time time2 = new Time(1, 20, 30);
            Time temp = new Time();
            Console.WriteLine("Object 1 and 2 befor used function convert_Time");
            time1.display();
            time2.display();
            time1.Convert_Time(time1.minutes, time1.hours, time1.second);
            Console.WriteLine("Object 1 and 2 after used function convert_Time");
            time1.display();
            time2.display();
            Console.WriteLine("Object 1 and 2 after used operators (++ , -- , + , - , * , / )");
            Console.WriteLine("Operator (++)");
            time1++;
            time2++;
            time1.display();
            time2.display();
            Console.WriteLine("Operator (--)");
            time1--;
            time2--;
            time1.display();
            time2.display();
            Console.WriteLine("Operator (+) between two object");
            temp = time1 + time2;
            temp = temp.Convert_Time(temp.minutes, temp.hours, temp.second);
            temp.display();
            Console.WriteLine("Operator (+) between object and number +20");
            time1 += 20;
            time2 += 20;
            time1.display();
            time2.display();
            Console.WriteLine("Operator (-) between two object");
            temp = time1 - time2;
            temp.display();
            Console.WriteLine("Operator (-) between object and number -20");
            time1 -= 20;
            time2 -= 20;
            time1.display();
            time2.display();
            Console.WriteLine("Operator (*)  between two object");
            temp = time1 * time2;
            temp = temp.Convert_Time(temp.minutes, temp.hours, temp.second);
            temp.display();
            Console.WriteLine("Operator ( / )  between two object");
            temp = time1 / time2;
            temp = temp.Convert_Time(temp.minutes, temp.hours, temp.second);
            temp.display();
            Console.WriteLine("Operator ( / ) between object and number /2");
            time1 /= 2;
            time2 /= 2;
            time1.display();
            time2.display();            
            do
            {
                Console.Write("Please enter size for array of time ");
                success = int.TryParse(Console.ReadLine(), out size);

            } while (!success);
            Console.WriteLine("Create Array of objects type Time by Random ");
            TimeArray timeArray1 = new TimeArray(ref size);
            timeArray1.display();
            timeArray1.middle();
            Console.WriteLine("Create Array of objects type Time by user ");
            TimeArray timeArray2 = new TimeArray(true);
            timeArray2.display();
            timeArray2.middle();
            Console.WriteLine("Number of objects created : " + Time.count);
            Console.ReadKey();
        }
    }
}
