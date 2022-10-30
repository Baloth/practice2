using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical2
{
    internal class MainCommands
    {
        public void Main()
        {
            var enteredVal = "0";

            while (enteredVal != "4")
            {
                new helper().ShowMenu();

                enteredVal = Console.ReadLine();

                if (enteredVal == "1")
                {
                    GameFindNumber();
                }
                if (enteredVal == "2")
                {
                    MultiplicationTable();
                }
                if (enteredVal == "3")
                {
                    NumberDivisors();
                }

            }
        }

        private void GameFindNumber()
        {
            var x_num = new Random().Next(0, 100);
            var error = true;

            Console.WriteLine("введите загаданное число");
            var enteredNum = Console.ReadLine();

            if (enteredNum == "0" && x_num == 0)
            {
                Console.WriteLine("Ура! Вы угадали!");
                return;
            }

            while (error)
            {
                if (int.TryParse(enteredNum, out int num))
                {
                    if (num == x_num)
                    {
                        Console.WriteLine("Ура! Вы угадали!");
                        Console.WriteLine();
                        error = true;
                        break;
                    }
                    else if (num < x_num)
                    {
                        Console.WriteLine("Попробуйте число побольше");
                    }
                    else
                    {
                        Console.WriteLine("Попробуйте число поменьше");
                    }
                }
                else
                {
                    Console.WriteLine("Вводимое значение должно быть числом.");
                }
                enteredNum = Console.ReadLine();
            }
        }

        private void MultiplicationTable()
        {
            Console.WriteLine("Таблица умножения");
            var matrix = new List<Multiplication>();
           
            var i = 1;

            while(i< 10)
            {
                var rowMatrix = new Multiplication() {  Row = new List<int>() };

                var j = 1;
                var row = new List<int>();
                while (j < 10)
                {
                    row.Add(j * i);
                    j++;
                }
                rowMatrix.Row = row;
                matrix.Add(rowMatrix);
                i++;
            }

            foreach(var item in matrix)
            {
                foreach(var num in item.Row)
                {
                    Console.Write(num);
                    if(num.ToString().Length == 1)
                    {
                        Console.Write("    ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void NumberDivisors()
        {
            Console.WriteLine("Введите число");
            var enteredNum = Console.ReadLine();
            List<int> list = new();

            if(int.TryParse(enteredNum, out int number)){
                var i = 1;
                Console.WriteLine("делится на целое при следующих числах:");
                Console.WriteLine();
                while (i< number)
                {
                    if(number%i == 0)
                    {
                        Console.Write(i + "    ");
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("не верное введённое значение");
                NumberDivisors();
            }
            Console.WriteLine();
        }


    }

    internal class Multiplication
    {
        public List<int> Row { get; set; }
    }
}
