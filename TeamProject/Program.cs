using TeamProject;
Console.WriteLine("Введите количество строк:");
int nrow = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов:");
int ncolumn = int.Parse(Console.ReadLine());

Person[,] mas2 = new Person[nrow, ncolumn];
Person[][] mas3 = new Person[nrow][];

for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        mas2[i, j] = new Person();
    }
}
for (int i = 0; i < nrow; i++)
{
    mas3[i] = new Person[ncolumn];
    for (int j = 0; j < ncolumn; j++)
    {
        mas3[i][j] = new Person();
    }
}

int start = Environment.TickCount;
int end = Environment.TickCount;

start = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        mas2[i, j].BirthYear = 2025;
    }
}
end = Environment.TickCount;
int mas2Time = end - start;
start = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        mas3[i][j].BirthYear = 2025;
    }
}
end = Environment.TickCount;
int mas3Time = end - start;

Console.WriteLine("кол-во строк " + nrow + " кол-во столбцов " + ncolumn);
Console.WriteLine("время выполнения mas2 - двумерный прямоугольный " + mas2Time + " мс");
Console.WriteLine("время выполнения mas3 - двумерный ступенчатый " + mas3Time + " мс");