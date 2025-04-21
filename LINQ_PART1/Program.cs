using System;
using System.Collections.Generic;
using System.Linq;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{    class Program
    {
        static void Main(string[] args)
        {
            /* 14.3. Сортировка (Простая сортировка)
             * 
            Теперь мы умеем фильтровать объекты и знаем различные конструкции для их выборки в новую сущность. При этом результат как фильтрации, 
            так и выборки мы не всегда получаем в удобном для нас виде, но, применив сортировку, мы сразу можем упорядочить объекты так, как нам надо.

            В стандартной библиотеке у большинства коллекций, как вы знаете, есть метод Sort(), но его функционал крайне ограничен и не идёт ни 
            в какое сравнение с тем, что нам предлагает LINQ.
            */

            //Простая сортировка
            //Базовые методы расширения LINQ, выполняющие эту функцию: OrderBy(),OrderByDescending().Вы уже видели их в примерах в начале модуля.

            //Здесь мы остановимся на них подробнее.

            //Отсортируем наших студентов по возрасту(в качестве аргумента мы тут передаем свойство класса):

            // Список студентов
            var students = new List<Student>
            {
            new Student {Name="Алёна", Age=23, Languages = new List<string> {"английский", "немецкий" }},
            new Student {Name="Яков", Age=23, Languages = new List<string> {"английский", "немецкий" }},
            new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
             new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
            new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
            new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            // Сортировка по возрасту
            var sortedStuds = from s in students orderby s.Age select s;

            foreach (var stud in sortedStuds)
                Console.WriteLine(stud.Name + ", " + stud.Age);

            //По умолчанию orderby сортирует по возрастанию. Для обратного порядка добавляем ключевое слово descending:

            //Алёна, 23
            //Яков, 23
            //Андрей, 23
            //Василий, 24
            //Сергей, 27
            //Дмитрий, 29

            // Сортировка по убыванию возраста
            //var sortedStuds = from s in students orderby s.Age descending select s;

            //foreach (var stud in sortedStuds)
            //    Console.WriteLine(stud.Name + ", " + stud.Age);

            /*
            То же самое через методы расширения: 

            //  По возрастанию
            var sortedStudentsAsc = students.OrderBy(s => s.Age);

            //  По убыванию
            var sortedStudentsDesc = students.OrderByDescending(s => s.Age)
            */;
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
