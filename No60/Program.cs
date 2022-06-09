// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

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

int[,,] FillArray(int N, int M, int K)
{
    int[,,] Array = new int[N, M, K];
    Random rnd = new Random();
    for (int i = 0; i < N; i++)

        for (int j = 0; j < M; j++)

            for (int k = 0; k < K; k++)
            {
                bool simular_checker = true;
                while (simular_checker)
                {
                    Array[i, j, k] = rnd.Next(10, 100);
                    simular_checker = LookForSim(Array[i, j, k], Array);
                }
            }
    return Array;
}


bool LookForSim(int num, int[,,] Array)
{
    bool answer = true;
    for (int a = 0; a < Array.GetLength(0); a++)
    {
        for (int b = 0; b < Array.GetLength(1); b++)
        {
            for (int c = 0; c < Array.GetLength(2); c++)
            {
                if (num == Array[a, b, c]) answer = false;
            }
        }
    }
    return answer;
}

void PrintArray(int[,,] XYZ)
{
    Console.WriteLine();
    for (int i = 0; i < XYZ.GetLength(0); i++)
    {
        for (int j = 0; j < XYZ.GetLength(1); j++)
        {
            for (int k = 0; k < XYZ.GetLength(2); k++)
            {
                Console.Write(XYZ[i, j, k] + $"({i + 1},{j + 1},{k + 1})" + " ");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine();
}

string message1 = "Введите X: ";
string message2 = "Введите Y: ";
string message3 = "Введите Z: ";
int N = GetNumber(message1);
int M = GetNumber(message2);
int K = GetNumber(message3);


if (N * M * K > 90) Console.WriteLine("Невозможно вывести только уникальные числа.");
else
{
    int[,,] XYZ = FillArray(N, M, K);
    PrintArray(XYZ);
}
