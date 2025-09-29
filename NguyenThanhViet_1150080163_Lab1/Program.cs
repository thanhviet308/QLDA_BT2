using System;
using System.Linq;

namespace Lab1_ThucHanh
{
    internal class Program
    {
        // ========== Helpers ==========
        static int ReadInt(string prompt, Func<int, bool> valid = null, string invalidMsg = "Gia tri khong hop le! Vui long nhap lai.")
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out int v) && (valid == null || valid(v))) return v;
                Console.WriteLine(invalidMsg);
            }
        }

        static double ReadDouble(string prompt, Func<double, bool> valid = null, string invalidMsg = "Gia tri khong hop le! Vui long nhap lai.")
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (double.TryParse(s, out double v) && (valid == null || valid(v))) return v;
                Console.WriteLine(invalidMsg);
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nNhan phim bat ky de quay ve MENU...");
            Console.ReadKey(true);
            Console.WriteLine(); // cách dòng cho dễ nhìn
        }

        static void Main(string[] args)
        {
            while (true)
            {
                // KHÔNG Clear mỗi vòng để dễ theo dõi I/O
                Console.WriteLine("=== MENU 11 BAI THUC HANH LAB 1 ===");
                Console.WriteLine("1. Tinh chu vi, dien tich HCN");
                Console.WriteLine("2. Tim so lon hon trong 2 so nguyen");
                Console.WriteLine("3. Tim so lon nhat trong 3 so nguyen");
                Console.WriteLine("4. Cho biet mot thang co bao nhieu ngay");
                Console.WriteLine("5. Kiem tra so nguyen n chan/le, am/khong am");
                Console.WriteLine("6. Tinh chu vi, dien tich HCN (so thuc)");
                Console.WriteLine("7. Kiem tra tam giac (chu vi, dien tich)");
                Console.WriteLine("8. Giai phuong trinh bac 2");
                Console.WriteLine("9. Tinh tong cac phan tu trong mang");
                Console.WriteLine("10. Sap xep mang bang Selection Sort");
                Console.WriteLine("11. Chen mot so vao mang tang dan");
                Console.WriteLine("0. Thoat");
                int choice = ReadInt("Nhap lua chon: ", v => v >= 0 && v <= 11, "Lua chon 0..11!");

                Console.WriteLine(); // cách dòng

                switch (choice)
                {
                    case 1: Bai1(); Pause(); break;
                    case 2: Bai2(); Pause(); break;
                    case 3: Bai3(); Pause(); break;
                    case 4: Bai4(); Pause(); break;
                    case 5: Bai5(); Pause(); break;
                    case 6: Bai6(); Pause(); break;
                    case 7: Bai7(); Pause(); break;
                    case 8: Bai8(); Pause(); break;
                    case 9: Bai9(); Pause(); break;
                    case 10: Bai10(); Pause(); break;
                    case 11: Bai11(); Pause(); break;
                    case 0:
                        Console.WriteLine("Tam biet!");
                        return;
                }
            }
        }

        // ===== Bai 1 =====
        static void Bai1()
        {
            double a = ReadDouble("Nhap chieu dai (>0): ", v => v > 0, "Phai > 0!");
            double b = ReadDouble("Nhap chieu rong (>0): ", v => v > 0, "Phai > 0!");
            Console.WriteLine("Chu vi = {0}", 2 * (a + b));
            Console.WriteLine("Dien tich = {0}", a * b);
        }

        // ===== Bai 2 =====
        static void Bai2()
        {
            int a = ReadInt("Nhap so nguyen a: ");
            int b = ReadInt("Nhap so nguyen b: ");
            Console.WriteLine("So lon hon = {0}", Math.Max(a, b));
        }

        // ===== Bai 3 =====
        static void Bai3()
        {
            int a = ReadInt("Nhap so a: ");
            int b = ReadInt("Nhap so b: ");
            int c = ReadInt("Nhap so c: ");
            int max = Math.Max(a, Math.Max(b, c));
            Console.WriteLine("So lon nhat = {0}", max);
        }

        // ===== Bai 4 =====
        static void Bai4()
        {
            int nam = ReadInt("Nhap nam (>0): ", v => v > 0, "Nam phai > 0!");
            int thang = ReadInt("Nhap thang (1..12): ", v => v >= 1 && v <= 12, "Thang phai tu 1..12!");
            int ngay = DateTime.DaysInMonth(nam, thang);
            Console.WriteLine($"Thang {thang}/{nam} co {ngay} ngay.");
        }

        // ===== Bai 5 =====
        static void Bai5()
        {
            int n = ReadInt("Nhap so nguyen n: ");
            Console.WriteLine(n % 2 == 0 ? "n la so chan" : "n la so le");
            Console.WriteLine(n >= 0 ? "n khong am" : "n la so am");
        }

        // ===== Bai 6 =====
        static void Bai6()
        {
            double a = ReadDouble("Nhap chieu dai (>0): ", v => v > 0, "Phai > 0!");
            double b = ReadDouble("Nhap chieu rong (>0): ", v => v > 0, "Phai > 0!");
            Console.WriteLine("Chu vi = {0}", 2 * (a + b));
            Console.WriteLine("Dien tich = {0}", a * b);
        }

        // ===== Bai 7 =====
        static void Bai7()
        {
            double a = ReadDouble("Nhap do dai canh a (>0): ", v => v > 0, "Phai > 0!");
            double b = ReadDouble("Nhap do dai canh b (>0): ", v => v > 0, "Phai > 0!");
            double c = ReadDouble("Nhap do dai canh c (>0): ", v => v > 0, "Phai > 0!");

            if (a + b > c && a + c > b && b + c > a)
            {
                double p = (a + b + c) / 2;
                double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("La tam giac. Chu vi = {0}, Dien tich = {1}", (a + b + c), S);
            }
            else Console.WriteLine("Khong phai tam giac!");
        }

        // ===== Bai 8 =====
        static void Bai8()
        {
            double a = ReadDouble("Nhap a: ");
            double b = ReadDouble("Nhap b: ");
            double c = ReadDouble("Nhap c: ");

            if (a == 0)
            {
                // bx + c = 0
                if (b == 0)
                {
                    Console.WriteLine(c == 0 ? "Phuong trinh co vo so nghiem." : "Phuong trinh vo nghiem.");
                }
                else
                {
                    Console.WriteLine("Nghiem x = {0}", -c / b);
                }
                return;
            }

            double delta = b * b - 4 * a * c;
            if (delta < 0) Console.WriteLine("Vo nghiem thuc.");
            else if (delta == 0) Console.WriteLine("Nghiem kep x = {0}", -b / (2 * a));
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("Co 2 nghiem: x1 = {0}, x2 = {1}", x1, x2);
            }
        }

        // ===== Bai 9 =====
        static void Bai9()
        {
            int n = ReadInt("Nhap so luong phan tu (>=1): ", v => v >= 1, "Phai >= 1!");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = ReadInt($"Nhap arr[{i}]: ");
            }
            Console.WriteLine("Tong cac phan tu = {0}", arr.Sum());
        }

        // ===== Bai 10 =====
        static void Bai10()
        {
            int n = ReadInt("Nhap so luong phan tu (>=1): ", v => v >= 1, "Phai >= 1!");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = ReadInt($"Nhap arr[{i}]: ");
            }

            // Selection Sort
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIndex]) minIndex = j;

                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]); // swap tuple
            }

            Console.WriteLine("Mang sau khi sap xep: " + string.Join(", ", arr));
        }

        // ===== Bai 11 =====
        static void Bai11()
        {
            int n = ReadInt("Nhap so luong phan tu (>=0): ", v => v >= 0, "Phai >= 0!");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = ReadInt($"Nhap arr[{i}]: ");
            }

            Array.Sort(arr);
            int x = ReadInt("Nhap so can chen: ");

            int[] newArr = new int[n + 1];
            int k = 0;
            bool inserted = false;
            for (int i = 0; i < n; i++)
            {
                if (!inserted && x <= arr[i]) // chen truoc cac phan tu bang x de duoc day khong giam
                {
                    newArr[k++] = x;
                    inserted = true;
                }
                newArr[k++] = arr[i];
            }
            if (!inserted) newArr[k++] = x;

            Console.WriteLine("Mang moi: " + string.Join(", ", newArr));
        }
    }
}
