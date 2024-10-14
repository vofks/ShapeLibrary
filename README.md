![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/vofks/ShapeLibrary/run-tests.yml)

# Тестовое задание на позицию C# Developer Middle в [Mindbox](https://mindbox.ru/)

# Задание:

1. Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

    - Юнит-тесты
    - Легкость добавления других фигур
    - Вычисление площади фигуры без знания типа фигуры в compile-time
    - Проверку на то, является ли треугольник прямоугольным

2. В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

# Что сделано

-   Реализована библиотека ShapeLibrary, которая содержит классы [Circle](/ShapeLibrary/Circle.cs), [Triangle](/ShapeLibrary/Triangle.cs) и нтерфейс [IShape](/ShapeLibrary/IShape.cs).

-   Документация в коде.

-   Unit-тесты реализованы с ипользованием фреймворка xUnit и располагаются в проекте [ShapeLibrary.Tests](/ShapeLibrary.Tests/). Файлы [CircleTests.cs](/ShapeLibrary.Tests/ShapeTests/CircleTests.cs) и [TriangleTests.cs](/ShapeLibrary.Tests/ShapeTests/TriangleTests.cs) соответственно.

-   Пример использования находится в проекте [Example](/Example/Program.cs)

-   Библиотека собрана в NuGet пакет, опубликована и доступна по [ссылке](https://www.nuget.org/packages/Omgdev.Util.ShapeLibrary/1.0.0).

    Добавить в проект можно при помощи команды:

    ```powershell
    dotnet add package Omgdev.Util.ShapeLibrary --version 1.0.0
    ```

-   Решение SQL задачи представлено в файле [SQL/Solution.sql](/SQL/Solution.sql). Файл содержит запросы для создания схемы, заполнения таблиц данными и ответ к задаче. Быстро запустить можно, например, [тут](https://sqliteonline.com/).

# Решения

## Вычисление площади фигуры без знания типа фигуры в compile-time

Я предположил, что необходимо определить универсальный для всех фигур интерфейс, который позволит вычислять площадь без занания конкретного типа. Для этого был создан интерфейс **IShape** с методом **CalculateArea()**, который возвращает площадь фигуры типа **double**.

Предположим, что инициализация объектов фигур происходит где-то вне пользовательского кода. Пользователь получет сериализованные фигуры по сети при помощи клиенского интерфейса, в котором реализован метод **IEnumerable\<IShape\> GetShapes()**.

## Пример:

```c#
double sum = 0;
IEnumerable<IShape> shapes = client.GetShapes();

// Находим сумму площадей всех полученных фигур
foreach(var shape in shapes)
{
    sum += shape.CalculateArea();
}

sum = 0;

// Или с помощью LINQ
sum = shapes.Sum(s => s.CalculateArea());;
```

## Добавление новых фигур

Необходимо добавить класс, реализующий метод **CalculateArea()** интерфейса **IShape**.

## Пример

```c#
class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }
}
```
