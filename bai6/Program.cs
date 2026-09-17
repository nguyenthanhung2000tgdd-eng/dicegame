using System;

namespace HarmonicSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhập số lượng phần tử n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                double sum = 0.0;
                Console.Write("Chuỗi Harmonic: ");

                for (int i = 1; i <= n; i++)
                {
                    if (i < n)
                    {
                        Console.Write($"1/{i} + ");
                    }
                    else
                    {
                        Console.Write($"1/{i}");
                    }

                    sum += 1.0 / i; 
                }

                Console.WriteLine($"Tổng của chuỗi Harmonic đến {n} phần tử là: {sum:F5}");
            }
            else
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương hợp lệ!");
            }
        }
    }
}