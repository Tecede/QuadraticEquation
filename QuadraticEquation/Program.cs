using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            List<Equation> equations = new List<Equation>();

            Console.WriteLine("Решение квадратного уравнения вида: ax^2+bx+c=0");
            Console.WriteLine("1. Ввести с клавиатуры");
            Console.WriteLine("2. Считать файл");

            // TODO: Проверка на ввод
            int choise = Convert.ToInt32(Console.ReadLine());

            switch (choise)
            {
                // TODO: Проверка на ввод
                case 1:
                    Console.WriteLine("Введите a: ");
                    a = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите b: ");
                    b = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите c: ");
                    c = Convert.ToDouble(Console.ReadLine());

                    Equation equation = new Equation(a, b, c);

                    equations.Add(equation);

                    break;
                case 2:
                    try
                    {
                        using (StreamReader sr = new StreamReader("input.txt"))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] splitLine = line.Split(' ');

                                a = Convert.ToDouble(splitLine[0]);
                                b = Convert.ToDouble(splitLine[1]);
                                c = Convert.ToDouble(splitLine[2]);

                                Equation equation1 = new Equation(a, b, c);

                                equations.Add(equation1);
                            }
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                default:
                    Console.WriteLine("Некорректный ввод");
                    break;
            }

            while (equations.Count > 0)
            {
                Console.WriteLine("Ваше уравнение:");
                Console.WriteLine($"{equations.First().GetA()}x^2+{equations.First().GetB()}x+{equations.First().GetC()}=0");

                var answer = equations.First().Solve();
                Console.WriteLine($"Дискриминант: {equations.First().GetD()}");


                if (equations.First().GetD() == 0)
                {
                    Console.WriteLine($"x1 = {answer[0]}");
                }
                else
                if (equations.First().GetD() > 0)
                {
                    Console.WriteLine($"x1 = {answer[0]}");
                    Console.WriteLine($"x2 = {answer[1]}");
                }
                else
                {
                    Console.WriteLine("Корней нет");
                }
                Console.WriteLine();

                equations.Remove(equations.First());
            }

            Console.ReadKey();
        }
    }
}
