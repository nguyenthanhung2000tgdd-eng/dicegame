using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicegame.dicegame
{
    internal class dicegame
    {
        public static void Main(string[] args)
        {
            dice();
        }
        static void dice()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Nhập số tiền: ");
            long sotien = long.Parse(Console.ReadLine());

            int solanchoi = 0;
            int solanthua = 0;
            int solandacbie= 0;
            bool choitiep = true;

            do
            {
                solanchoi++;
                Console.Write($"Bạn có số tiền {sotien}, dặt bao nhiêu: ");
                int sotiendat = int.Parse(Console.ReadLine());
                bool ok = long.TryParse(Console.ReadLine(), out long result);
                if (ok && result <= sotien && result > 1000)
                {
                    sotiendat = result;
                    break;
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập một số hợp lệ hoặc số tiền đặt " +
                        $"cược không được vượt quá số tiền hiện có {sotien}. Hoặc trên 1000 đồng");
                    Console.Write("Bạn đặt bao nhiêu? ");
                }
            }
            while (true);
            Random rand = new Random();
            int dice1 = rand.Next(1, 7);
            int dice2 = rand.Next(1, 7);
            int sum = dice1 + dice2;

            string doan;
            do
            {
                Console.Write("Bạn đoán tài (T) xỉu (X) hay lục (L): ");
                doan = Console.ReadLine().ToLower();
                if (doan != "T" && doan != "X" && doan != "L")
                {
                    Console.WriteLine("Vui lòng nhập T, X hoặc L.");
                }
                else
                {
                    break;
                }
                return;

            }
            while (true);
            bool win = false;
            bool dacbiet = false;
           
            if (doan == "T" && sum > 6) 
            {
                win = true;
            }
            else if (doan == "X" && sum < 6) 
            {
                win = true;
            }
            else if (doan == "L" && sum == 6)
            {
                dacbiet = true;
            }
            Console.WriteLine($"Kết quả gieo súc sắc: {dice1} + {dice2} = {sum}");
            if (win)
            {
                if (dacbiet)
                {
                 
                    solandacbie++;
                    sotien += sotiendat * 3;
                    Console.WriteLine($"Bạn thắng đặc biệt! Tổng số tiền hiện tại: {sotien} đồng.");
                }
                else
                {
                    sotien += sotiendat;
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {sotien} đồng.");
                }
            }
            else
            {
                sotien -= sotiendat;
                solanthua++;
                Console.WriteLine($"Bạn thua! Tổng số tiền hiện tại: {sotien} đồng.");
            }
  
            Console.Write("Bạn có muốn chơi tiếp không? (C/K): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "k")
            {
                choitiep = false;
            }
         while (choitiep);
            Console.WriteLine("Trò chơi kết thúc!");
            Console.WriteLine($"Số lần chơi: {solanchoi}");
            Console.WriteLine($"Số lần thua:{solanthua}");
            Console.WriteLine($"Số lần thắng: {solanchoi}-{solanthua} - {solandacbie}");
            Console.WriteLine($"Số lần thắng đặc biệt: {solandacbie}");
        }
    }
}
