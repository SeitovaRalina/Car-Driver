using System;
using System.Linq;
using System.Security.Cryptography;

namespace Car_Driver
{
    internal class Requests
    {
        static void Main(string[] args)
        {
            string[] strings = File.ReadAllLines(@"C:\Users\seito\source\repos\Car Driver\CarInfo.txt");
            List<Car> cars = new List<Car>();
            List<Driver> drivers = new List<Driver>();
            foreach (string s in strings)
            {
                string[] info = s.Split();
                if (info.Length > 0)
                {
                    cars.Add(new Car(info[0], info[1], info[2]));
                }
            }
            Console.WriteLine("Введите информацию (владелец - номер машины): ");
            string a = "  ";
            while (a != "")
            {
                a = Console.ReadLine();
                if (a != "") {
                    string[] s = a.Split();
                    string[] number_cars = new string[s.Length-2]; 
                    for (int i = 2;i < s.Length; i++) { number_cars[i-2] = s[i]; }
                    drivers.Add(new Driver(number_cars, s[0], s[1]));
                }
            }
            Console.WriteLine();
            Console.Write("Введите номер машины, информацию о владельцах которой нужно узнать: ");
            string choose_car = Console.ReadLine();
            var cardrivers = from d in drivers
                             from id in d.number_cars
                             where id == choose_car
                             select new
                             {
                                 surname = d.surname,
                                 name = d.name,
                             };
            foreach (var cardriver in cardrivers) { Console.WriteLine($"{cardriver.surname} {cardriver.name}");}
            Console.WriteLine();
            Console.Write("Введите фамилию владельца, чтобы узнать информацию о его машинах: ");
            string srnm = Console.ReadLine();
            var carsinfo = from d in drivers
                          where d.surname == srnm
                          from c in d.number_cars
                          from car in cars
                          where c == car.number
                          select car;
            foreach(var car in carsinfo) { car.Print(); }
            Console.WriteLine();
            Console.Write("Введите букву: ");
            string bukva = Console.ReadLine().ToLower();
            var drvrs = from d in drivers
                        where d.surname[0].ToString().ToLower() == bukva
                        select d;
            foreach (var drvr in drvrs) { drvr.Print(); }
            // данные по машине (ее владельцы)
            // владелец (его машины)
            // водители с фамилией с заданной буквы
        }
    }
}