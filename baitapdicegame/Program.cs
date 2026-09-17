using System;
using System.Text;

namespace DiceGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            dice();
        }

        static void dice()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập số tiền ban đầu: ");
            if (!long.TryParse(Console.ReadLine(), out long sotien) || sotien < 1000)
            {
                Console.WriteLine("Số tiền không hợp lệ! Phải nhập số từ 1000 đồng.");
                return;
            }

            int solanchoi = 0;
            int solanthua = 0;
            int solandacbie = 0;
            bool choitiep = true;
            

            do
            {
                if (sotien < 1000)
                {
                    Console.WriteLine("Số tiền của bạn không đủ để tiếp tục chơi.");
                    break;
                }

                solanchoi++;
                long sotiendat = 0;

                // Vong lap nhap sotiendat
                do
                {
                    Console.Write($"[Lượt {solanchoi}] Số tiền hiện có: {sotien} đồng. Đặt bao nhiêu? ");
                    bool ok = long.TryParse(Console.ReadLine(), out sotiendat);

                    if (ok && sotiendat >= 1000 && sotiendat <= sotien)
                    {
                        break;
                    }
                    Console.WriteLine($"Vui lòng nhập số hợp lệ: từ 1000 đồng và không vượt quá {sotien} đồng.");
                } while (true);

                // doan T X L
                string doan = "";
                while (true)
                {
                    Console.Write("Bạn đoán Tài (T), Xỉu (X) hay Lục (L): ");
                    doan = Console.ReadLine().Trim().ToUpper();
                    if (doan == "T" || doan == "X" || doan == "L")
                    {
                        break;
                    }
                    Console.WriteLine("Vui lòng chỉ nhập T, X hoặc L.");
                }

                // gieo xx
                Random rand = new Random();
                int dice1 = rand.Next(1, 7);
                int dice2 = rand.Next(1, 7);
                int sum = dice1 + dice2;

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
                    win = true;
                    dacbiet = true;
                }

                Console.WriteLine($"Kết quả gieo xúc xắc: {dice1} + {dice2} = {sum}");

                if (win)
                {
                    if (dacbiet)
                    {
                        solandacbie++;
                        sotien += sotiendat * 3;
                        Console.WriteLine($"Bạn thắng ĐẶC BIỆT (x3 tiền cược)! Số tiền hiện tại: {sotien} đồng.");
                    }
                    else
                    {
                        sotien += sotiendat;
                        Console.WriteLine($"Bạn thắng! Số tiền hiện tại: {sotien} đồng.");
                    }
                }
                else
                {
                    sotien -= sotiendat;
                    solanthua++;
                    Console.WriteLine($"Bạn thua! Số tiền hiện tại: {sotien} đồng.");
                }

                if (sotien < 1000)
                {
                    Console.WriteLine("Bạn đã hết tiền!");
                    break;
                }

                Console.Write("Bạn có muốn chơi tiếp không? (C/K): ");
                string input = Console.ReadLine().Trim().ToUpper();
                if (input == "K")
                {
                    choitiep = false;
                }

            } while (choitiep);

            // Thống kê kết quả
            int solanthangthuong = solanchoi - solanthua - solandacbie;
            Console.WriteLine("TRÒ CHƠI KẾT THÚC");
            Console.WriteLine($"Tổng số lần chơi : {solanchoi}");
            Console.WriteLine($"Số lần thua : {solanthua}");
            Console.WriteLine($"Số lần thắng : {solanthangthuong}");
            Console.WriteLine($"Thắng đặc biệt : {solandacbie}");
            Console.WriteLine($"Số tiền còn lại : {sotien} đồng.");
        }
    }
}