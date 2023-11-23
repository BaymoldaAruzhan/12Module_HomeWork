using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dopolnitelno
{
    // Задача 1: Работа с делегатами
    delegate double MathOperation(double x, double y);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;

        static void Main()
        {
            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");

            int choice = Convert.ToInt32(Console.ReadLine());

            MathOperation mathOperation = null;

            switch (choice)
            {
                case 1:
                    mathOperation = Add;
                    break;
                case 2:
                    mathOperation = Subtract;
                    break;
                case 3:
                    mathOperation = Multiply;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;
            }

            double result = mathOperation(num1, num2);
            Console.WriteLine($"Result: {result}");

            // Задача 2: Использование событий
            Counter counter = new Counter();

            counter.ThresholdReached += (sender, e) =>
            {
                Console.WriteLine($"Threshold reached at {counter.Value}!");
            };

            for (int i = 0; i < 10; i++)
            {
                counter.Increment();
                Thread.Sleep(500); // Пауза в полсекунды для наблюдения результатов.
            }

            // Задача 3: Продвинутая работа с событиями
            Timer timer = new Timer();

            timer.Tick += (sender, e) =>
            {
                Console.WriteLine($"Current time: {DateTime.Now.ToLongTimeString()}");
            };

            timer.Start();

            Console.WriteLine("Press any key to stop the timer...");
            Console.ReadKey();

            timer.Stop();
        }
    }

    // Задача 2: Использование событий
    class Counter
    {
        private const int Threshold = 5;
        private int value;

        public event EventHandler ThresholdReached;

        public int Value => value;

        public void Increment()
        {
            value++;
            Console.WriteLine($"Counter value: {value}");

            if (value == Threshold)
            {
                OnThresholdReached();
            }
        }

        protected virtual void OnThresholdReached()
        {
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }
    }

    // Задача 3: Продвинутая работа с событиями
    class Timer
    {
        public event EventHandler Tick;

        private bool isRunning;

        public void Start()
        {
            isRunning = true;

            while (isRunning)
            {
                Thread.Sleep(1000); // Пауза в одну секунду.
                OnTick();
            }
        }

        public void Stop()
        {

            isRunning = false;
        }

        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }
    }

}
