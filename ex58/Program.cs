// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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

int[,] MultiplyMatrix(int[,] matrixOne, int[,] matrixTwo)
{
    if(matrixOne.GetLength(1) != matrixTwo.GetLength(0)){
        System.Console.WriteLine("Ошибка! Данные матрицы несовместимы!");
        return new int[0,0]; // возвращаем пустой массив
    }

    int[,] result = new int[matrixOne.GetLength(0), matrixTwo.GetLength(1)];

    for (int i = 0; i < matrixOne.GetLength(0); i++)
    {
        for (int j = 0; j < matrixTwo.GetLength(1); j++)
        {
            for (int n = 0; n < matrixOne.GetLength(1); n++)
            {
                result[i, j] += matrixOne[i, n] * matrixTwo[n, j];
            }
        }
    }
    return result;
}

var firstArray = GetArray(rows, cols);
var secondArray = GetArray(cols, rows); // попробуем перемножить прямоугольные матрицы
System.Console.WriteLine("Первый массив:");
Print2DArray(firstArray);
System.Console.WriteLine("Второй массив:");
Print2DArray(secondArray);
System.Console.WriteLine("Произведение матриц:");
Print2DArray(MultiplyMatrix(firstArray, secondArray));