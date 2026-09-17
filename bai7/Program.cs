using System;

namespace PerfectNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhập số bắt đầu của khoảng: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Nhập số kết thúc của khoảng: ");
            int end = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nCác số hoàn hảo trong khoảng từ {start} đến {end} là:");
            bool found = false;

            for (int num = start; num <= end; num++)
            {
                if (num <= 1) continue;

                int sum = 0;
                for (int i = 1; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        sum += i;
                    }
                }
                if (sum == num)
                {
                    Console.Write($"{num} ");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy số hoàn hảo nào trong khoảng này.");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}