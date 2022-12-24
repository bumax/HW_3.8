// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

Console.Write("Введите количество строк: ");
var rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
var cols = Convert.ToInt32(Console.ReadLine());

int[,] GetArray(int m = 10, int n = 10, int min = 0, int max = 100)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }
    }
    return result;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }

}

void SortArray(int[,] array) // так как мы передаем в функцию не массив, а ссылку на него, то ничего возвращать не будем!
{
    for (int n = 0; n < array.GetLength(0); n++)
    // start bubble sort
        for (int i = 0; i < array.GetLength(1) - 1; i++)
        {
            bool flag = new bool(); // флаг сортировки
            for (int j = 0; j < array.GetLength(1) - 1 - i; j++)
            {
                if (array[n, j] < array[n, j + 1])
                {
                    int tmp = array[n, j + 1];
                    array[n, j + 1] = array[n, j];
                    array[n, j] = tmp;
                    flag = true;
                }
            }
            if(!flag) break; // если уже всё отсортировано, дальше не идем
        }
}


var testArray = GetArray(rows, cols);
System.Console.WriteLine("Исходный массив:");
Print2DArray(testArray);
System.Console.WriteLine("Сортированный массив:");
SortArray(testArray);
Print2DArray(testArray);