// Задайте двумерный массив. 
// Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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

void ArrayOrganiser(int[,] TwoSetArray, int N, int M)
{
    int remember;
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            for (int l = 0; l < M; l++)
            {
                if(TwoSetArray[i,j] > TwoSetArray[i,l])
                {
                    remember = TwoSetArray[i,l];
                    TwoSetArray[i,l] = TwoSetArray[i,j];
                    TwoSetArray[i,j] = remember;
                }
            }
        }
    }
}
string message1 = "Введите количество строк массива: ";
string message2 = "Введите количество рядов массива: ";
int N = GetNumber(message1);
int M = GetNumber(message2);

int[,] TwoSetArray = FillArray(N, M);
PrintArray(TwoSetArray);
ArrayOrganiser(TwoSetArray, N, M);
PrintArray(TwoSetArray);