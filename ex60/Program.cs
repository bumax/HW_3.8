// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Console.Write("Введите количество строк: ");
var rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
var cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите глубину: ");
var depth = Convert.ToInt32(Console.ReadLine());


int Factorial(int n)
{
    if (n <= 1)
        return 1;
    else
        return n * Factorial(n - 1);
}



// замахнулся на генерацию трехмерного массива с неповторяющимися n-значными числами (разрядность задается параметром)
int[,,] Get3DArray(int m = 2, int n = 2, int d = 2, int digits = 2)
{
    int max = Factorial(10) / Factorial(10 - digits); // вспоминаем комбинаторику, вычисляем максимальное количество элементов, которое может быть в массиве
    if (m * n * d > max)
    {           // проверяем, сможем ли мы построить заданный массив из неповторяющихся n - значных чисел
        System.Console.WriteLine("Ошибка! такой массив нельзя построить!");
        return new int[0, 0, 0]; // возвращаем пустой массив
    }
    int[,,] result = new int[m, n, d];

    // генерируем массив с n-значными числами
    int[] digitData = new int[max];
    for (int i = 0; i < max; i++)
        if (digits == 1)
            digitData[i] = i;
        else
            digitData[i] = (int)Math.Pow(10, digits - 1) + i;
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < d; k++)
            {
                var rndIndex = new Random().Next(0, max);
                do
                {
                    if (digitData[rndIndex] != -1)
                    {
                        result[i, j, k] = digitData[rndIndex];
                        digitData[rndIndex] = -1; // метим ячейки, которые мы использовали, маркером "-1"
                    }
                    else
                        rndIndex = new Random().Next(0, max);
                } while (result[i, j, k] == 0);
            }
        }
    }
    return result;
}

void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(2); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int k = 0; k < array.GetLength(1); k++)
            {
                Console.Write(array[j, k, i] + $"({j},{k},{i})\t"); // вывод как в задании
            }
            Console.WriteLine();
        }

    }

}

Print3DArray(Get3DArray(rows, cols, depth, 2));