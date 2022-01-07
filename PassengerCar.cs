using System;
using static System.Console;

namespace Racing
{
    class PassengerCar : Car
    {
        public int MaxSpeed { get; set; }
        public int Speed { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Track { get; set; }
        public int Rang { get; set; }
        bool go = false;

        public event Program.RaceFin Finish;
        public PassengerCar(int track, string name, int max_speed)
        {
            Name = name;
            MaxSpeed = max_speed;
            //tire_wear = 0;
            Distance = 0;
            Track = track * 5;
            Rang = 0;
        }
        public void ShowCar(int x, int y)
        {
            SetCursorPosition(x, y - 1); Write(@"         \ ");
            SetCursorPosition(x, y);     Write(@" |  L  L  |");
            SetCursorPosition(x, y + 1); Write(@" --@----@--");
        }
        public void Go(bool go)
        {
            this.go = go;
        }
        public void Race(ref int rang)
        {
            if (go == true)
            {
                Random rnd = new Random();
                Speed = rnd.Next(1, MaxSpeed);
                if (Speed + Distance > 100) Speed = 100 - Distance;

                for (int i = 0; i < Speed; i++)
                {
                    ShowCar(Distance + i, Track + 1);
                }

                //string str = new string(' ', x);
                //Write(str + "--@----@--\\");
                SetCursorPosition(115, Track);
                Write(Name);
                SetCursorPosition(115, Track + 1);
                Write("Скорость: " + Speed);
                SetCursorPosition(115, Track + 2);
                Distance += Speed;
                Write("Пройдено " + Distance + " %");
                //tire_wear *= Speed;
                if (Distance >= 100)
                {
                    Finish?.Invoke(ref rang);
                    Rang = rang;
                    go = false;
                }
            }

        }
    }
}
