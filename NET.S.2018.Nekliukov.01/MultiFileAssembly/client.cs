using System;
using Car;

class Program {
    static void Main() {
        Auto obj1 = new Auto();
        obj1.AutoInfo();

        SportCar obj = new SportCar();
        obj.InfoSportCar();

        Console.ReadLine();
    }
}