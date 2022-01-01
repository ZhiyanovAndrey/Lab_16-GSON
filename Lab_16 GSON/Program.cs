using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Lab_16_GSON
{
    /*16.1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
    Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число),
    «Название товара» (строка), «Цена товара» (вещественное число).
    Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
    Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/

        class Program
        {
            static void Main(string[] args)
            {
                const int n = 5;
                Product[] product = new Product[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите код товара» (целое число)");
                    int cod = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Название товара");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите цену товара (в формате 45,55)");
                    decimal price = Convert.ToDecimal(Console.ReadLine());
          //вызываем конструктор по умолчанию () и для инициализации {перечисляем свойства и присваиваем переменные}
                    product[i] = new Product() { CodOfProduct = cod, NameOfProduct = name, Price = price }; 
          //каждая ячейка массива это новый экземпляр класса Prodact              

                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true //добавляет Отступ вложенных маркеров JSON, Добавление новых строк,
                                         //Добавление пробелов между именами свойств и значениями.

                };
                string jsonString = JsonSerializer.Serialize(product, options);

                using (StreamWriter sw = new StreamWriter("Product.json"))
                {
                    sw.WriteLine(jsonString);
                }
            }
        }
}

    

