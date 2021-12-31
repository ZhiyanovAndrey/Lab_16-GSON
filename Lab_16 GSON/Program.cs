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
                Product[] employees = new Product[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите номер");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите зп");
                    int summa = Convert.ToInt32(Console.ReadLine());
                    employees[i] = new Product() { Num = num, Name = name, Summa = summa };
                }

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(employees, options);

                using (StreamWriter sw = new StreamWriter("../../../Employees.json"))
                {
                    sw.WriteLine(jsonString);
                }
            }
        }
  class 
    

}

    

