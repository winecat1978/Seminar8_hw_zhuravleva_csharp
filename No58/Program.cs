// Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.

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
            Array[i, j] = rnd.Next(1, 3);
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

int[,] MatrixPow(int[,] Matrix1, int[,] Matrix2, int N1, int N2, int M1, int M2) // N1*M1 x N2*M2
{
    int[,] ResMatrix = new int[N1, M2];
    if (M1 != N2) Console.WriteLine("Вычислить произведение матриц невозможно.");
    else
    {
        for (int i = 0; i < N1; i++)
        {
            for (int j = 0; j < M2; j++)
            {
                for (int k = 0; k < M1; k++)
                {
                    ResMatrix[i, j] += Matrix1[i, k] * Matrix2[k, j];
                }
            }
        }
    }
    return ResMatrix;
}

string message1 = "Введите количество строк 1 матрицы: ";
string message2 = "Введите количество рядов 1 матрицы: ";
int N1 = GetNumber(message1);
int M1 = GetNumber(message2);

string message3 = "Введите количество строк 2 матрицы: ";
string message4 = "Введите количество рядов 2 матрицы: ";
int N2 = GetNumber(message3);
int M2 = GetNumber(message4);

int[,] Matrix1 = FillArray(N1, M1);
int[,] Matrix2 = FillArray(N2, M2);
PrintArray(Matrix1);
PrintArray(Matrix2);
int[,] Result = MatrixPow(Matrix1, Matrix2, N1, N2, M1, M2);
PrintArray(Result);
