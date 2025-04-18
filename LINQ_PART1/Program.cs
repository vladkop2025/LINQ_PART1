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
            //2/6   14.1. Фильтрация Where() - WhereExample
            //А вот задача по коллекциям, которая с помощью LINQ становится значительно проще.

            // Добавим Россию с её городами
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            //Выберем города-миллионники:
            var bigCities = from russianCity in russianCities
                            where russianCity.Population > 1000000
                            orderby russianCity.Population descending
                            select russianCity;

            //То же самое с помощью методов расширения выглядит ещё проще: 
            //var bigCities = russianCities.Where(c => c.Population > 1000000)
            //    .OrderByDescending(c => c.Population);

            foreach (var bigCity in bigCities)
                Console.WriteLine(bigCity.Name + " - " + bigCity.Population);

            //Москва - 11900000
            //Санкт - Петербург - 4991000
            //Казань - 1169000
            //Волгоград - 1099000
        }

        // Создадим модель класс для города
        public class City
        {
            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }

        }
    }
}

/*
Задание 14.1.1

А теперь попробуйте выбрать все города, название у которых не длиннее 10 букв, и отсортируйте их по длине названия.

Ответ:
var shortNameCities = russianCities
   .Where(city => city.Name.Length <= 10) // выборка городов с коротким именем
   .OrderBy(city => city.Name.Length);  // сортировка по длине имени
*/