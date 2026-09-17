using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitapdoanso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            doanso();
        }

        static void doanso()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // nhap tien
            long sotien = 0;
            while (true)
            {
                Console.Write("Nhập số tiền bạn có: ");
                if (!long.TryParse(Console.ReadLine(), out sotien) && sotien >= 1000)
                {
                    break;
                }
                Console.WriteLine("Vui lòng nhập số tiền hợp lệ và lớn hơn hoặc bằng 1000 đồng.");
            }

            int solanchoi = 0;
            int solanthua = 0;
            int solanthang = 0;
            bool choitiep = true;

            do
            {
                if (sotien <= 0)
                {
                    Console.WriteLine("Bạn đã hết tiền! Trò chơi kết thúc.");
                    break;
                }

                solanchoi++;
                Console.WriteLine($"LƯỢT 1 {solanchoi} ");
                Console.WriteLine($"Số tiền hiện có của bạn: {sotien} đồng.");

                // nhap tien cuoc
                long sotiendat = 0;
                while (true)
                {
                    Console.Write("Nhập số tiền đặt cược: ");
                    if (long.TryParse(Console.ReadLine(), out sotiendat) && sotiendat > 0 && sotiendat <= sotien)
                    {
                        break;
                    }
                    Console.WriteLine($"Tiền cược phải lớn hơn 0 và không vượt quá số tiền hiện có ({sotien} đồng)!");
                }

                // chon level
                int landoan = 0;
                double thuong = 0;
                while (true)
                {
                    Console.WriteLine("\nChọn mức độ chơi:");
                    Console.WriteLine("1. Dễ (9 lần đoán - Thắng nhận 1/2 tiền đặt)");
                    Console.WriteLine("2. Trung bình (6 lần đoán - Thắng nhận 1 lần tiền đặt)");
                    Console.WriteLine("3. Khó (4 lần đoán - Thắng nhận 3 lần tiền đặt)");
                    Console.Write("Lựa chọn của bạn (1-3): ");
                    string chon = Console.ReadLine();

                    if (chon == "1")
                    {
                        landoan = 9;
                        thuong = 0.5;
                        break;
                    }
                    else if (chon == "2")
                    {
                        landoan = 6;
                        thuong = 1.0;
                        break;
                    }
                    else if (chon == "3")
                    {
                        landoan = 4;
                        thuong = 3.0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chỉ chọn 1, 2 hoặc 3.");
                    }
                }

                // may chon ngau nhien
                Random rand = new Random();
                int so = rand.Next(1, 101);
                bool thang = false;

                Console.WriteLine($"Máy tính đã nghĩ ra một số từ 1 đến 100. Bạn có {landoan} lần đoán!");

                //nguoi choi doan
                for (int i = 1; i <= landoan; i++)
                {
                    Console.Write($"Lần đoán {i}/{landoan} - Nhập số đoán: ");
                    if (!int.TryParse(Console.ReadLine(), out int doanso) || doanso < 1 || doanso > 100)
                    {
                        Console.WriteLine("Số nhập không hợp lệ! Phải nhập số nguyên từ 1 đến 100.");
                        i--; 
                        continue;
                    }

                    if (doanso == so)
                    {
                        thang = true;
                        Console.WriteLine($"\n CHÚC MỪNG! Bạn đã đoán đúng số {so} ở lần thứ {i}!");
                        break;
                    }
                    else if (doanso < so)
                    {
                        Console.WriteLine("Gợi ý: Số bạn đoán nhỏ hơn số cần tìm.");
                    }
                    else
                    {
                        Console.WriteLine("Gợi ý: Số bạn đoán lớn hơn số cần tìm.");
                    }
                }

                // tinh tien
                if (thang)
                {
                    solanthang++;
                    long tienthuong = (long)(sotiendat * thuong);
                    sotien += tienthuong;
                    Console.WriteLine($"Bạn thưởng được {tienthuong} đồng! Tổng số tiền hiện tại: {sotien} đồng.");
                }
                else
                {
                    solanthua++;
                    sotien -= sotiendat;
                    Console.WriteLine($" Bạn đã hết lượt đoán. Số chính xác là: {so}");
                    Console.WriteLine($"Bạn bị trừ {sotiendat} đồng! Tổng số tiền hiện tại: {sotien} đồng.");
                }

                // choitiep
                if (sotien <= 0)
                {
                    Console.WriteLine("Bạn đã hết tiền! Trò chơi kết thúc.");
                    break;
                }

                Console.Write("\nBạn có muốn chơi tiếp không? (C/K): ");
                string input = Console.ReadLine().Trim().ToUpper();
                if (input == "K")
                {
                    choitiep = false;
                }

            } while (choitiep);

            // tong ket game
            Console.WriteLine("KẾT QUẢ TỔNG KẾT");
            Console.WriteLine($"Tổng số lần chơi: {solanchoi}");
            Console.WriteLine($"Số lần thắng: {solanthang}");
            Console.WriteLine($"Số lần thua: {solanthua}");
            Console.WriteLine($"Số tiền còn lại: {sotien} VNĐ");
        }
    }
}