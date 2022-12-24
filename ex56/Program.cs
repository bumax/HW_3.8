// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Console.Write("Введите количество строк: ");
var rows = Convert.ToInt32(Console.ReadLine());
var cols = new int();
do
{
    Console.Write("Введите количество столбцов: ");
    cols = Convert.ToInt32(Console.ReadLine());
    if (rows == cols) Console.WriteLine("Ошибка! Вы задали квадратную матрицу!");
} while (rows == cols); // вот и do...while пригодился :-)



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


int GetMinSumRows(int[,] array)
{
    int index = new int();
    int sum = new int(); // массив с результатом суммирования строк
    var min = int.MaxValue;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        // ищем имнимальное значение
        if (sum < min)
        {
            min = sum;
            index = i;
        }
        sum = 0;
    }

    return index + 1; // строки мы считаем с 1
}


var testArray = GetArray(rows, cols);
Print2DArray(testArray);
System.Console.WriteLine($"Строка с минимальной суммой элементов: {GetMinSumRows(testArray)}");