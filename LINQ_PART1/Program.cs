using System;
using System.Collections.Generic;
using System.Linq;

//Профессия C#-разработчик Язык C# Модуль 14. Основы LINQ.Часть 1
namespace LINQ_PART1
{    class Program
    {
        static void Main(string[] args)
        {
            /* 14.2. Проекция и выборка - Переменные в запросах, let

            Довольно часто бывает, что при формировании запросов LINQ нам необходимо выполнять промежуточные вычисления. Для этого 
            LINQ поддерживает объявление промежуточных переменных по ключевому слову let.

            Методы расширения, к сожалению, не поддерживают определение внутренних локальных переменных, и это одно из основных 
            преимуществ операторов перед ними.
            Но, как вы уже знаете, эти два инструмента можно сочетать, поэтому ту часть запроса, где переменные вам нужны, можно 
            написать с помощью операторов
            */

            //Возьмем список студентов из примера выше и добавим им всем в анкету фамилию:
            //Сначала нужно создать коллекцию студентов
            List<Student> students = new List<Student>
            {
                new Student { Name = "Анна", Age = 20, Languages = new List<string> { "английский", "немецкий" } },
                new Student { Name = "Борис", Age = 21, Languages = new List<string> { "английский", "французский" } },
                new Student { Name = "Мария", Age = 19, Languages = new List<string> { "испанский", "итальянский" } }
            };

            //В LINQ-запросе теперь используется from s in students вместо from s in Student
            var fullNameStudents = from s in students
                                       // временная переменная для генерации полного имени
                                   let fullName = s.Name + " Иванов"
                                   // проекция в новую сущность с использованием новой переменной
                                   select new
                                   {
                                       Name = fullName,
                                       Age = s.Age
                                   };

            foreach (var stud in fullNameStudents)
                Console.WriteLine(stud.Name + ", " + stud.Age);

            //Анна Иванов, 20
            //Борис Иванов, 21
            //Мария Иванов, 19
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
Задание 14.2.3
Даны те же данные:

// Наш список студентов
List<Student> students = new List<Student>
{
   new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
   new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
   new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
   new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
Выберите всех студентов моложе 27, сгенерируйте из них анкеты (модель класса расположена ниже).

public class Application
{
   public string Name { get; set; }
   public int YearOfBirth { get; set; }
}
При вычислении года рождения используйте ключевое слово let.

Ответ:

var youngStudentApplications = from s in students
   where s.Age < 27 // берем тех, кто младше 27
   let birthYear = DateTime.Now.Year - s.Age // Вычисляем год рождения
   select new Application() // создаем анкеты
   {
       Name = s.Name,
       YearOfBirth = birthYear
   };
 
//  вывод
foreach (var studApplication in youngStudentApplications)
   Console.WriteLine(studApplication.Name + ", " + studApplication.YearOfBirth);
*/
