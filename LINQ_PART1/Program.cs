using System;
using System.Collections.Generic;
using System.Linq;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{
    class Program
    {

        static void Main(string[] args)
        {
            /* 14.2. Проекция и выборка - Select()
            
            В предыдущем юните мы рассмотрели возможность применения простых фильтров для выборки данных по заданным условиям. Часто бывают ситуации, 
            когда выбранные данные необходимо преобразовать в новый тип. 

            Пример такой задачи: вам нужно создать отчёты по всем сотрудникам определенного возраста. Отчет — новая сущность, и скорее всего в вашей 
            программе она будет представлена отдельным классом.Здесь вам пришлось бы сначала выбрать данные по условиям, а потом создать из них отчеты, 
            но LINQ дает возможность соединить эти операции в одну, используя проекцию.

            Проекция позволяет преобразовать данные текущей выборки в какой-либо другой тип.
            Для этого используется оператор select (также есть соответствующий метод расширения).
            */

            //спроецировали сущности класса Student в новый тип — в строки, сохранив туда значения свойства Name.

            // Подготовим данные
            List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var names = from s in students select s.Name; //В выборке у нас — коллекция строк

            // Выведем результат
            foreach (var name in names)
                Console.WriteLine(name);

            //Андрей
            //Сергей
            //Дмитрий
            //Василий

        }
        // Создадим модель Student
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
    }
}

/*
В выборке у нас — коллекция строк. 

В данном случае мы спроецировали сущности класса Student в новый тип — в строки, сохранив туда значения свойства Name.

Но точно также мы могли бы спроецировать и в другой более сложный тип, в том числе анонимный.

Допустим, из данных по студентам мы хотим выгрузить для них анкеты, но описывать модель класса анкеты не хотим, ведь 
больше нигде она нам не понадобится. 

// Наш список студентов
List<Student> students = new List<Student>
{
   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
   new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
};
 
var studentApplications = from s in students
   // создадим анонимный тип для представления анкеты
   select new
   {
       FirstName = s.Name,
       YearOfBirth = DateTime.Now.Year - s.Age
   };
Либо, если модель Анкеты у нас есть, так: 

var studentApplications = from s in students
   // спроецируем в новую сущеность анкеты
   select new Application()
   {
       FirstName = s.Name,
       YearOfBirth = DateTime.Now.Year - s.Age
   };
Вывод будет одинаковым как для анонимного класса, так и для обычного: 

// Выведем результат
foreach (var application in studentApplications)
   Console.WriteLine($"{application.FirstName}, {application.YearOfBirth}");

            //Андрей,   1997
            //Сергей,   1993
            //Дмитрий,  1991
            //Василий,  1996


С методами расширения то же самое, ещё проще: 

// выборка имен в строки
var names = students.Select(u => u.Name);
 
// проекция в анонимный тип
var applications = students.Select(u => new
{
   FirstName = u.Name,
   YearOfBirth = DateTime.Now.Year - u.Age
});
 
// проекция в другой тип
var applications1 = students.Select(u => new Application()
{
   FirstName = u.Name,
   YearOfBirth = DateTime.Now.Year - u.Age
});


Задание 14.2.1
Дан массив слов:

string [] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха"};
Сделайте выборку в анонимный тип с одновременной сортировкой слов по длине. Результат выведите в консоль.

Ответ:
var wordsInfo =  words.Select(w =>
   new
   {  // Выборка в анонимный тип
       Name = w,
       Length = w.Length // Длину слова сохраняем сразу в свойство нового анонимного типа
   })
   .OrderBy( word => word.Length); //  сортируем коллекцию по длине
 
 
// выводим
foreach (var word in wordsInfo)
   Console.WriteLine($"{word.Name} - {word.Length} букв");
*/