using System;

    class BookOrders
    {
        static void Main()
        {
            int orders = int.Parse(Console.ReadLine());
            decimal sum = 0;
            int booksSum = 0;
            for (int i = 0; i < orders; i++)
            {
                int packets = int.Parse(Console.ReadLine());
                int booksPacket = int.Parse(Console.ReadLine());
                decimal bookPrice = decimal.Parse(Console.ReadLine());
                int books = packets * booksPacket;
                int discount = 0;
                int index = packets;
                decimal bookPriceOrder = 0;
                if (index >= 10 && index < 20)
                {
                    discount = 5;
                }

                else if (index >= 20 && index < 30)
                {
                    discount = 6;
                }

                else if (index >= 30 && index < 40)
                {
                    discount = 7;
                }

                else if (index >= 40 && index < 50)
                {
                    discount = 8;
                }

                else if (index >= 50 && index < 60)
                {
                    discount = 9;
                }

                else if (index >= 60 && index < 70)
                {
                    discount = 10;
                }

                else if (index >= 70 && index < 80)
                {
                    discount = 11;
                }

                else if (index >= 80 && index < 90)
                {
                    discount = 12;
                }

                else if (index >= 90 && index < 100)
                {
                    discount = 13;
                }

                else if (index >= 100 && index < 110)
                {
                    discount = 14;
                }

                else if (index >= 110)
                {
                    discount = 15;
                }
                decimal bookDiscount = bookPrice - discount * bookPrice / 100;
                bookPriceOrder = (decimal)books * bookDiscount;
                sum += bookPriceOrder;
                booksSum += booksPacket * packets;
            }
            Console.WriteLine(booksSum);
            Console.WriteLine("{0:F2}", sum);
        }
    }