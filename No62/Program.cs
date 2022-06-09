// Заполните спирально массив 4 на 4.

int GetNumber(string msg)
{
    Console.WriteLine(msg);
    string ValueFromConsole = Console.ReadLine();
    if (int.TryParse(ValueFromConsole, out int num))
    {
        if (num > 0) return num;
        else
        {
            Console.WriteLine("Введите положительное число.");
        }
    }
    else
    {
        Console.WriteLine("Введите число.");
    }
    return num;
}

(int, int, int) FillRight(int[,] Array, int count, int a, int b)
{
    if (Array[a, b] != 0) b++;
    while (Array[a, b] == 0)
    {
        Array[a, b] = count;
        count++;
        if (b + 1 == Array.GetLength(1)) break;
        else if (Array[a, b + 1] == 0) b++;
    }
    return (a, b, count);
}

(int, int, int) FillDown(int[,] Array, int count, int a, int b)
{
    if (Array[a, b] != 0) a++;
    while (Array[a, b] == 0)
    {
        Array[a, b] = count;
        count++;
        if (a + 1 == Array.GetLength(0)) break;
        else if (Array[a + 1, b] == 0) a++;
    }
    return (a, b, count);
}

(int, int, int) FillLeft(int[,] Array, int count, int a, int b)
{
    if (Array[a, b] != 0) b--;
    while (Array[a, b] == 0)
    {
        Array[a, b] = count;
        count++;
        if (b == 0) break;
        else if (Array[a, b - 1] == 0) b--;
    }
    return (a, b, count);
}

(int, int, int) FillUp(int[,] Array, int count, int a, int b)
{
    if (Array[a, b] != 0) a--;
    while (Array[a, b] == 0)
    {
        Array[a, b] = count;
        count++;
        if (a == 0) break;
        else if (Array[a - 1, b] == 0) a--;
    }
    return (a, b, count);
}

int [,] FillArray(int Stroka, int Stolbec)
{
    int[,] Array = new int[Stroka, Stolbec];
    int count = 1;
    int a = 0;
    int b = 0;
    int direction = 1;

    do
    {
        if (direction == 1 )
        {
            (a,b,count) = FillRight(Array, count, a, b);
            direction = 2;
        }
        else if (direction == 2)
        {
            (a,b,count) = FillDown(Array, count, a, b);
            direction = 3;
        }
        else if (direction == 3)
        {
            (a,b,count) = FillLeft(Array, count, a, b);
            direction =4;
        }
        else 
        {
            (a,b,count) = FillUp(Array, count, a, b);
            direction = 1;
        }
    }
    while (count <= Stolbec*Stroka);
    return Array;
}



void PrintArray(int[,] ResultArray)
{
    for (int i = 0; i < ResultArray.GetLength(0); i++)
    {
        for (int j = 0; j < ResultArray.GetLength(1); j++)
        {
            Console.Write($"\t{ResultArray[i,j],1}");
        }
        Console.WriteLine();
    }
}

string message1 = "Укажите количество строк массива: ";
string message2 = "Укажите количество столбцов массива: ";
int Stroka = GetNumber(message1);
int Stolbec = GetNumber(message2);

int [,] ResultArray = FillArray(Stroka, Stolbec);
PrintArray(ResultArray);