using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program
{
    static void Main()
    {
        DateTime purchaseDate = DateTime.Now;

        Dictionary<string, double> itemsCost = new Dictionary<string, double>
        {
            { "Хлеб", 1 },
            { "Молоко", 1.5 },
            { "Чай", 8 },
            { "Сахар", 2 },
            { "Макароны", 6.3 }
        };

        Dictionary<string, int> itemsQuantity = new Dictionary<string, int>
        {
            { "Хлеб", 2 },
            { "Молоко", 2 },
            { "Чай", 3 },
            { "Сахар", 2 },
            { "Макароны", 1 }
        };

        string filePath = "C:\\Users\\User\\Desktop\\check.txt";

        WriteCheckToFile(filePath, purchaseDate, itemsCost, itemsQuantity, CultureInfo.CurrentCulture);

        Console.WriteLine("Информация из чека в формате текущей локали:");
        Console.WriteLine(File.ReadAllText(filePath));

        CultureInfo enUSCulture = new CultureInfo("en-US");
        CultureInfo.CurrentCulture = enUSCulture;
        string filePathEn = "C:\\Users\\User\\Desktop\\check_en-US.txt";

        WriteCheckToFile(filePathEn, purchaseDate, itemsCost, itemsQuantity, enUSCulture);

        Console.WriteLine("\nИнформация из чека в формате локали en-US:");
        Console.WriteLine(File.ReadAllText(filePathEn));
    }

    static void WriteCheckToFile(string filePath, DateTime purchaseDate, Dictionary<string, double> itemsCost, Dictionary<string, int> itemsQuantity, CultureInfo culture)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Дата покупки: " + purchaseDate.ToString("d", culture));

            foreach (var item in itemsCost)
            {
                string itemName = item.Key;
                double itemPrice = item.Value;
                int itemQuantity = itemsQuantity[itemName];
                double totalPrice = itemPrice * itemQuantity;

                string formattedPrice = itemPrice.ToString("C2", culture);
                string formattedTotalPrice = totalPrice.ToString("C2", culture);

                writer.WriteLine($"{itemName} – {formattedPrice} x {itemQuantity} = {formattedTotalPrice}");
            }
        }
    }
}
