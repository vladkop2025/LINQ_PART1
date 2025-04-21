using System;
using System.Collections.Generic;
using System.Linq;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{    class Program
    {
        static void Main(string[] args)
        {
            /* 14.3. Сортировка (Множественная сортировка)
  
            Очень часто приходится сортировать объекты последовательно, сразу по нескольким критериям. 
            Для LINQ нет ничего проще — просто перечислите критерии сортировки через запятую в том порядке, в каком хотите их применить: 
            */

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

            // Сортировка сначала по имени, а затем - по возрасту
            var sortedStuds = from s in students orderby s.Name, s.Age select s;

            foreach (var stud in sortedStuds)
                Console.WriteLine(stud.Name + ", " + stud.Age);

            //Алёна, 23
            //Андрей, 23
            //Василий, 24
            //Дмитрий, 29
            //Сергей, 27
            //Яков, 23

            /*
            // Сортировка по имени и возрасту (возрастание)

            var sortedStuds = students
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Age);
          
            foreach (var stud in sortedStuds)
            Console.WriteLine(stud.Name + ", " + stud.Age); 
            */

            /*
            И по убыванию:

            // Сортировка по имени и возрасту (убывание)

            var sortedStudsDesc = students
             .OrderByDescending(s => s.Name)
            .ThenByDescending(s => s.Age);
 
            foreach (var stud in sortedStudsDesc)
             Console.WriteLine(stud.Name + ", " + stud.Age);
            */

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
Задание 14.3.1
Как происходит сортировка в LINQ по умолчанию?

1. По возрастанию`                                                              X
2. По убыванию
3. Требует принудительного указания сортировки в виде аргумента
4. Для каждого вида сортировки предусмотрены отдельные методы расширения        X

Ответ:
1. Да, метод OrderBy() сортирует элементы по возрастанию.
4. Верно, это OrderBy() и OrderByDescending() соответственно.

Задание 14.3.2
Каким образом мы можем выполнить множественную сортировку, используя методы расширения?

методы расширения не поддерживают её, множественная сортировка доступна только в LINQ-выражениях
используя подряд несколько раз OrderBy()
через метод ThenBy()                                                                                X
нет верного ответа

Ответ:этот метод нужно вызывать после основной сортировки через OrderBy().

*/