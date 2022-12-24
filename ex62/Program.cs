// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

Console.Write("Введите количество строк: ");
var rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов: ");
var cols = Convert.ToInt32(Console.ReadLine());

int i = 1;


void FillSpiralArray(int[,] array, int m, int n, int dir)
{
    //dir - направление движения (0 - вправо, 1 - вниз, 2 - влево, 3 - вверх)

    // заполняем в заданном направлении, пока не упремся
    while (IsValidPoint(array, m, n))
    {
        array[m, n] = i;
        i++;
        switch (dir)
        {
            case 0:
                n++;
                break;
            case 1:
                m++;
                break;
            case 2:
                n--;
                break;
            case 3:
                m--;
                break;
        }
    }

    if (array.Length == i - 1) // если заполнили весь массив, завершаем работу
        return;

    // поворачиваем на 90 градусов по часовой стрелке
    switch (dir)
    {
        case 0:
            m++;
            n--;
            FillSpiralArray(array, m, n, 1);
            break;
        case 1:
            m--;
            n--;
            FillSpiralArray(array, m, n, 2);
            break;
        case 2:
            m--;
            n++;
            FillSpiralArray(array, m--, n++, 3);
            break;
        case 3:
            m++;
            n++;
            FillSpiralArray(array, m++, n--, 0);
            break;
    }

}

// условия валидности точки - она не за границами массива и в этой точке записан 0 (т.е. ее ещё не заполняли)
bool IsValidPoint(int[,] array, int m, int n)
{
    if (array.GetLength(0) > m && array.GetLength(1) > n && m >= 0 && n >= 0)
        return array[m, n] == 0;
    else
        return false;
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

int[,] testArray = new int[rows, cols];
FillSpiralArray(testArray, 0, 0, 0);
Print2DArray(testArray);
