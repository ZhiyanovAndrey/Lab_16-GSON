using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Lab_16_GSON;

namespace Deserialize
{
   /*Необходимо разработать программу для получения информации о товаре из json-файла.
Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(@"C:\Users\Андрей\source\repos\Lab_16 GSON\Lab_16 GSON\bin\Debug\Product.json"))
            {
                jsonString = sr.ReadToEnd();//Readline считывает одну строку, ReadToEnd весь файл
            }
            Product[] employees = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxPrice = employees[0];
            foreach (Product e in employees)
            {
                if (e.Price > maxPrice.Price)
                {
                    maxPrice = e;
                }
            }
            Console.WriteLine($"Самый дорогой товар: {maxPrice.NameOfProduct} \nЦена товара: {maxPrice.Price}  Код товара: {maxPrice.CodOfProduct}");
            Console.ReadKey();
        }
    }
}
