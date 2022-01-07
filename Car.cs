using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    /*public abstract class*/interface Car
    {
        event Program.RaceFin Finish;
        int MaxSpeed { get; set; } // максимальная скорость
        int Speed { get; set; }  // текущая скорость
        //protected int tire_wear; // износ резины
        string Name { get; set; } // название
        int Distance { get; set; } // пройденная дистанция
        int Track { get; set; } // Дорожка
        int Rang { get; set; } //занятое место
        void Go(bool go);
        void Race(ref int rang);// отображение автомобиля
        void ShowCar(int x, int y); // отображение авто
        
    }
}
