using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Threading;



namespace Racing
{
    public delegate void RaceStart(bool go);
    
    class Program
    {
        public delegate void RaceFin(ref int grade);

        public static event RaceStart Start;
        private static void Stop(ref int grade)
        {
            grade++;
        }
        private static void GoCrazyRace(List<Car> cars)
        {
            ConsoleKeyInfo cki;
            int x = 0;
            
            foreach(var item in cars)
            {
                item.ShowCar(item.Distance, item.Track + 1);
            }
            SetCursorPosition(10, 4);
            WriteLine("Нажмите пробел для старта");
            do
            {
                cki = ReadKey(true);

            } while (cki.Key != ConsoleKey.Spacebar);
            SetCursorPosition(10, 4);
            WriteLine("                          ");
            Start?.Invoke(true);
            while (x < Start.GetInvocationList().Length)
            {
                foreach (var item in cars)
                {
                    item.Race(ref x);
                }

                Thread.Sleep(100);
            }
        }
        private static void Winners(List<Car> cars)
        {
            SetCursorPosition(10, CursorTop); WriteLine("         **********         ");
            SetCursorPosition(10, CursorTop); WriteLine("         *        *         ");
            SetCursorPosition(10, CursorTop); WriteLine("**********   ***  *         ");
            SetCursorPosition(10, CursorTop); WriteLine("*  ****  *     *  **********");
            SetCursorPosition(10, CursorTop); WriteLine("*    *   *     *  *  ****  *");
            SetCursorPosition(10, CursorTop); WriteLine("*  *     *     *  *    *   *");
            SetCursorPosition(10, CursorTop); WriteLine("*  ****  *        *   ***  *");
            SetCursorPosition(10, CursorTop); WriteLine("*        *        *    *   *");
            SetCursorPosition(10, CursorTop); WriteLine("*        *        *   *    *");
            SetCursorPosition(10, CursorTop); WriteLine("****************************");
            foreach (var item in cars)
            {
                if (item.Rang == 1)
                {
                    SetCursorPosition(20, CursorTop - 11);
                    Write(item.Name);
                }
                if (item.Rang == 2)
                {
                    SetCursorPosition(10, CursorTop + 1);
                    Write(item.Name);
                }
                if (item.Rang == 3)
                {
                    SetCursorPosition(30, CursorTop + 1);
                    Write(item.Name);
                }
            }

        }
        static void Main(string[] args)
        {
            WindowHeight = 40;
            WindowWidth = 150;
            CursorVisible = false;
           
            Random rnd = new Random();
            List<Car> cars = new List<Car>
            {
                new Bolid(1, "Молния", 20),
                new Bus(2, "Бомбовоз", 15),
                new PassengerCar(3, "Кляча", 10),
                new Bolid(4, "Пуля", 15),
                new Bus(5, "17-А", 10),
                new PassengerCar(6, "Лексузель", 20)
            };
            foreach(var item in cars)
            {
                item.Finish += Stop;
                Start += item.Go;
            }
            GoCrazyRace(cars);
            
            Winners(cars);
            SetCursorPosition(0, CursorTop + 10);

            
        }

    }
}
