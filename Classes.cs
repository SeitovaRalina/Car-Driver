using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Driver
{
    class Car
    {
        public string number { get; private set; }
        private string model { get; set; }
        private string color { get;set; }
        public Car(string number, string model, string color)
        {
            this.number = number;
            this.model = model;
            this.color = color;
        }
        public void Print()
        {
            Console.WriteLine($"Номер машины: {number}");
            Console.WriteLine($"Модель машины: {model}");
            Console.WriteLine($"Цвет: {color}");
        }
    }
    class Driver
    {
        public string[] number_cars { get; private set;}
        public string surname { get; private set; }
        public string name { get; private set; }
        public Driver(string[] cars, string surname, string name)
        {
            this.number_cars = cars;
            this.surname = surname;
            this.name = name;
        }
        public void Print()
        {
            Console.WriteLine($"Владелец: {surname} {name}");
            Console.WriteLine("Номера его машин: " + String.Join(", ", number_cars.ToArray()) + ".");
            Console.WriteLine();
        }
    }
}
