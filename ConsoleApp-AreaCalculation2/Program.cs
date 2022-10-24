// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Reflection;
using ShapesLibrary;


//1. Trying two value for CIRCLE : positive and negative
try
{
    Circle circle = new Circle(4);
    circle.ShowData();

    Circle circleerror = new Circle(-4);
}
catch (ArgumentOutOfRangeException e)
{
    foreach (DictionaryEntry d in e.Data) Console.WriteLine("{0} {1}", d.Key, d.Value);
}
catch (Exception e)
{
    Console.WriteLine("\nCircle block : Calculation error\n" + e.Message );
}

//2. Trying two value for Triangle : positive and negative
try
{
    Triangle triangle = new Triangle(3, 4, 5);
    triangle.ShowData();

    Triangle triangleerror = new Triangle(3, 4, -5);
}
catch (ArgumentOutOfRangeException e)
{
    foreach (DictionaryEntry d in e.Data) Console.WriteLine("{0} {1}", d.Key, d.Value);
}
catch (Exception e)
{
    Console.WriteLine("\nTriangle block : Calculation error\n" + e.Message);
}

Console.WriteLine();
/// <summary>  
/// Calculating area of figure in compile-time
/// Implementati without try-catch
/// </summary>
/// 

Assembly asm = Assembly.LoadFrom("ShapesLibrary.dll");
Console.WriteLine($"Введите наименование фигуры (полный тип, с пространством имён, например: ShapesLibrary.Circle): ");
var typeName = Console.ReadLine();
Type? type = asm.GetType(typeName);

object[] parameters = new object[type.GetFields(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).
    Count()];
int i = 0;

foreach (FieldInfo field in type.GetFields(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
{
    Console.WriteLine($"Введите значение {field.FieldType.Name} {field.Name} : ");
    var parameter = Console.ReadLine();
    parameters[i] = Double.Parse(parameter);
    i++;
}

if (type != null)
{
    var figure = (Shape?)Activator.CreateInstance(type, parameters);
    Console.WriteLine("S(area) = " + figure?.CalcArea());
}
else
{
    Console.WriteLine("Неверный тип");
}
