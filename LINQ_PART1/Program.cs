using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 14.2. Проекция и выборка - Множественная выборка
            LINQ позволяет выбирать объекты из разных источников данных, соединяя их в одну сущность. 
            */

            //Допустим, у нас есть студенты и курсы:

            // Список студентов
            var students = new List<Student>
            //List<Student> students = new List<Student>
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };


            // Список курсов
            var coarses = new List<Course>
            {
                new Course {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
                new Course {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            // добавим студентов в курсы
            var studentsWithCoarses = from stud in students
                                      from coarse in coarses
                                      select new { Name = stud.Name, CoarseName = coarse.Name };

            // выведем результат
            foreach (var stud in studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");

            //Здесь, при выборке данных из двух источников, каждая сущность из первого источника сопоставляется с сущностью из второго.
            //Всего выборка даст 6 новых сущностей.

            //Студент Андрей добавлен курс Язык программирования C#
            //Студент Андрей добавлен курс Язык SQL и реляционные базы данных
            //Студент Сергей добавлен курс Язык программирования C#
            //Студент Сергей добавлен курс Язык SQL и реляционные базы данных
            //Студент Дмитрий добавлен курс Язык программирования C#
            //Студент Дмитрий добавлен курс Язык SQL и реляционные базы данных
        }

        // Создадим модель Student
        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }

        // Создадим модель Course
        class Course
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
    }
}

/*
Задание 14.2.4
Теперь добавьте всех студентов младше 29 лет, владеющих английским языком, в курс «Язык программирования C#». 

Новая анонимная сущность для выборки должна иметь следующие поля:

имя (строка);
год рождения студента (целое число);
имя курса (строка).

Ответ:

var studentsWithCoarses = from stud in students
   where  stud.Age < 29 // берем всех студентов младше 29
   where stud.Languages.Contains("английский") // ищем тех, у кого в списке языков есть английский
   let birthYear = DateTime.Now.Year - stud.Age // Вычисляем год рождения
   from coarse in coarses
   where coarse.Name.Contains("C#") // теперь выбираем только курс по C#
   select new // выборка в новую сущность
   {
       Name = stud.Name,
       BirthYear = birthYear,
       CoarseName = coarse.Name
   };
 
// выведем результат
foreach (var stud in studentsWithCoarses)
   Console.WriteLine($"Студент {stud.Name} ({stud.BirthYear}) добавлен курс {stud.CoarseName}");
*/
