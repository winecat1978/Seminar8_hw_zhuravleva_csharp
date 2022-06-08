// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов

int GetNumber(string msg)
{
    while (true)
    {
        Console.WriteLine(msg);
        string value = Console.ReadLine();
        if (int.TryParse(value, out int num))
        {
            if (num > 0) return num;
            else Console.WriteLine("Введите положительное число!");
        }
        else
        {
            Console.WriteLine("Вы ввели не число, попробуйте еще раз!");
        }
    }
}

int[,] FillArray(int N, int M)
{
    int[,] Array = new int[N, M];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            Array[i, j] = rnd.Next(1, 100);
        }
    }
    return Array;
}

void PrintArray(int[,] TwoSetArray)
{
    Console.WriteLine();
    for (int i = 0; i < TwoSetArray.GetLength(0); i++)
    {
        for (int j = 0; j < TwoSetArray.GetLength(1); j++)
        {
            Console.Write(TwoSetArray[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int MinSumm (int[,] TwoSetArray, int N, int M)
{
    int [] Summs = new int [N];
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            Summs[i] +=TwoSetArray[i,j];
        }
    }
    int MinSumm = Summs[0];
    int MinRow = 0;
    for (int k = 0; k < N; k++)
    {
        if(MinSumm > Summs[k])
        {
            MinSumm = Summs[k];
            MinRow = k;
        }
    }
    return MinRow;
}

int MinSummCount (int [,] TwoSetArray, int N, int M, int result)
{
    int Summary = 0;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            if(i == result)
            {
                Summary += TwoSetArray[i,j];
            }
        }
    }
    return Summary;
}

string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int[,] TwoSetArray = FillArray(N, M);
PrintArray(TwoSetArray);
int result = MinSumm(TwoSetArray, N, M);
int SummRes = MinSummCount(TwoSetArray, N, M, result);
Console.WriteLine($"Наименьшая сумма элементов равна {SummRes} и располагается на строке {result + 1}");
