using TeamProject;
Console.WriteLine("Введите количество строк:");
int nrow = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов:");
int ncolumn = int.Parse(Console.ReadLine());

Person[] mas1 = new Person[nrow * ncolumn];
Person[,] mas2 = new Person[nrow, ncolumn];

for (int i = 0; i < mas1.Length; i++)
{
    mas1[i] = new Person();
}

for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        mas2[i, j] = new Person();
    }
}

int start = Environment.TickCount;
for (int i = 0; i < mas1.Length; i++)
{
    mas1[i].BirthYear = 2025;
}
int end = Environment.TickCount;
int oneDimTime = end - start;

start = Environment.TickCount;
for (int i = 0; i < nrow; i++)
{
    for (int j = 0; j < ncolumn; j++)
    {
        mas2[i, j].BirthYear = 2025;
    }
}
end = Environment.TickCount;
int twoDimRectTime = end - start;

Console.WriteLine("Количество строк " + nrow + " Количество столбцов " + ncolumn);
Console.WriteLine("Время выполнения операций mas1 " + oneDimTime + " мс");
Console.WriteLine("Время выполнения операций mas2 " + twoDimRectTime + " мс");