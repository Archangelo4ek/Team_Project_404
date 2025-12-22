using System;
using System.Collections;
using TeamProjectPart2;

Edition e1 = new Edition("Наука и жизнь", new DateTime(2023, 5, 1), 10000);
Edition e2 = new Edition("Наука и жизнь", new DateTime(2023, 5, 1), 10000);
Console.WriteLine("Проверка ссылок и равенства объектов Edition:");
Console.WriteLine("Ссылки равны (ReferenceEquals): " + ReferenceEquals(e1, e2));
Console.WriteLine("Объекты равны (Equals): " + e1.Equals(e2));
Console.WriteLine("HashCode объекта e1: " + e1.GetHashCode());
Console.WriteLine("HashCode объекта e2: " + e2.GetHashCode());
Console.WriteLine(new string('-', 60));
Console.WriteLine("Попытка присвоить отрицательный тираж (обработка исключения):");
try
{
    e1.Circulation = -5;
}
catch (Exception ex)
{
    Console.WriteLine("Перехвачено исключение: " + ex.Message);
}
Console.WriteLine(new string('-', 60));
Console.WriteLine("Создание журнала, добавление редакторов и статей, вывод журнала:");
Magazine mag = new Magazine("ТехноОбзор", Frequency.Monthly, new DateTime(2024, 1, 15), 5000);
Person editor1 = new Person("Иван", "Иванов", new DateTime(1980, 3, 10));
Person editor2 = new Person("Мария", "Петрова", new DateTime(1985, 7, 22));
mag.AddEditors(editor1, editor2);
Article art1 = new Article("Новые процессоры 2024", new Person("Алексей", "Сидоров", new DateTime(1990, 2, 2)), 4.5);
Article art2 = new Article("Искусственный интеллект в быту", new Person("Ольга", "Кузнецова", new DateTime(1992, 11, 11)), 3.8);
Article art3 = new Article("Обзор смартфонов", new Person("Пётр", "Николаев", new DateTime(1988, 6, 6)), 4.9);
mag.AddArticles(art1, art2, art3);
Console.WriteLine(mag.ToString());
Console.WriteLine(new string('-', 60));
Console.WriteLine("Свойство EditionSubObject у объекта Magazine:");
Edition sub = mag.EditionSubObject;
Console.WriteLine(sub.ToString());
Console.WriteLine(new string('-', 60));
Console.WriteLine("Глубокое копирование журнала и проверка независимости копии:");
Magazine magCopy = (Magazine)((IRateAndCopy)mag).DeepCopy();
mag.Title = "ТехноОбзор — спецвыпуск";
mag.Circulation = 8000;
mag.AddEditors(new Person("Новый", "Редактор", new DateTime(1995, 5, 5)));
mag.AddArticles(new Article("Эксклюзивное интервью", new Person("Журналист", "А", new DateTime(1991, 1, 1)), 2.5));
Console.WriteLine("Копия журнала (должна остаться без изменений):");
Console.WriteLine(magCopy.ToString());
Console.WriteLine("Исходный журнал (после изменений):");
Console.WriteLine(mag.ToString());
Console.WriteLine(new string('-', 60));
double threshold = 4.0;
Console.WriteLine("Статьи с рейтингом больше " + threshold + ":");
ArrayList highRated = mag.GetArticlesWithRatingGreaterThan(threshold);
foreach (object obj in highRated)
{
    Article a = obj as Article;
    if (a != null)
        Console.WriteLine(a.ToString());
}
Console.WriteLine(new string('-', 60));
string substr = "смартфон";
Console.WriteLine("Статьи, в названии которых есть строка \"" + substr + "\":");
ArrayList contains = mag.GetArticlesWithTitleContains(substr);
foreach (object obj in contains)
{
    Article a = obj as Article;
    if (a != null)
        Console.WriteLine(a.ToString());
}
Console.WriteLine(new string('-', 60));