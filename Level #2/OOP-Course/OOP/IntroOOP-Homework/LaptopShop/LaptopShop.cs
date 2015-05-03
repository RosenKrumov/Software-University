using System;

    class LaptopShop
    {
        static void Main()
        {
            Battery firstBattery = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5);
            Battery secondBattery = new Battery("Li-Ion, 8-cells, 6000 mAh");
            Laptop firstLaptop = new Laptop("Lenovo Yoga 2 Pro", 699.00M, "Lenovo", "Intel Core i5-4210U", "8 GB", "Intel HD Graphics 4400", "128GB SSD", "13.3\" (33.78 cm) ", firstBattery);
            Laptop secondLaptop = new Laptop("Acer", 890.21M);
            Laptop thirdLaptop = new Laptop("Asus ", 1929.12M, ram:"16 GB", battery:secondBattery);

            Console.WriteLine(firstLaptop);
            Console.WriteLine(secondLaptop);
            Console.WriteLine(thirdLaptop);
        }
    }