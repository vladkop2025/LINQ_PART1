using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{    class Program
    {
        static void Main(string[] args)
        {
            /* 14.2. Проекция и выборка - Skip(), Take()
            LINQ позволяет выбирать объекты из разных источников данных, соединяя их в одну сущность. 
            При выборке и других задачах нередко бывает, что надо учитывать не все элементы.

            К примеру, нужно пропустить первые несколько, либо же не включать элементы в выборку, пока не выполнится определенное условие.
            Для пропуска элементов существует метод Skip(), а для включения элементов в выборку — Take().

            Простой пример: 
            */

            Console.OutputEncoding = Encoding.UTF8;

            var cars = new[] { "Volvo", "Opel", "Suzuki", "Toyota", "Lada", "Kamaz" };

            // пропустим первые два элемента
            var skip2 = cars.Skip(2);

            foreach (var car in skip2)
                Console.WriteLine(car);

            //Suzuki
            //Toyota
            //Lada
            //Kamaz

            //Skip() и Take() удобно сочетать: 

            // пропустим первые два элемента и выведем следующие два
            //var skip2 = cars.Skip(2).Take(2);

            // foreach (var car in skip2)
            //    Console.WriteLine(car);

            //Особенно удобно эти методы применять вместе для создания постраничного вывода. 

            //К примеру, на первой странице вы показываете товары с 1 по 10, то есть в данном случае условный код будет выглядеть вот так:

            //var page1 = products.Take(10);
            //Далее, на второй и третьей странице:

            //var page2 = products.Skip(10).Take(10)
            //var page3 = products.Skip(20).Take(10)...и так далее.
        }
    }
}

/*
Задание 14.2.5
Давайте попробуем сделать свою мини-программу для просмотра контактов с постраничным выводом.

Дан список: 

var contacts = new List<Contact>()
{
   new Contact() { Name = "Андрей", Phone = 7999945005 },
   new Contact() { Name = "Сергей", Phone = 799990455 },
   new Contact() { Name = "Иван", Phone = 79999675 },
   new Contact() { Name = "Игорь", Phone = 8884994 },
   new Contact() { Name = "Анна", Phone = 665565656 },
   new Contact() { Name = "Василий", Phone = 3434 }
};
Сделайте вывод контактов в консоль по два в бесконечном цикле.

Выводить нужно постранично, например так: вы ввели 1 — показало Андрея и Сергея, 2 — Ивана и Игоря, 3 — Анну и Василия.

Ответ:

// бесконечный цикл, ожидающий ввод с консоли
while (true)
{
   var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
   Console.Clear();  //  очистка консоли от ввода
 
 
   if (!Char.IsDigit(keyChar))
   {
       Console.WriteLine("Ошибка ввода, введите число");
   }
   else
   {
       //  переменная для хранения запроса в зависимости от введенного с консоли числа
       IEnumerable<Contact> page = null;
      
       //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
       switch (keyChar)
       {
           case ('1'):
               page = contacts.Take(2);
               break;
           case ('2'):
               page = contacts.Skip(2).Take(2);
               break;
           case ('3'):
               page = contacts.Skip(4).Take(2);
               break;
       }
 
       //   проверим, что ввели существующий номер страницы
       if (page == null)
       {
           Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
           continue;
       }
      
       // вывод результата на консоль
       foreach (var contact in page)
           Console.WriteLine(contact.Name + " " + contact.Phone);
   }
}

*/

