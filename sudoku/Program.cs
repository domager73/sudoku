using SudokyConstants;
using System.Reflection.Emit;

void AssignMainRow(int[,] field)  // создание основной строки 
{
    Random random = new Random();

    for (int i = 0; i < field.GetLength(1); i++)
    {
        int countThereIs = 0;
        while (countThereIs != 1)
        {
            countThereIs = 0;
            field[0, i] = random.Next(1, 9 + 1);
            foreach (int j in field)
            {
                if (field[0, i] == j)
                {
                    countThereIs++;
                }
            }
        }
    }
}

void CreatRow(int[,] field, int muchShift, int fromWhat, int inWhich)  // создание строки в зависимости от ее места
{
    for (int i = 0; i < field.GetLength(1); i++)
    {
        if (i + muchShift < 9)
        {
            field[inWhich, i] = field[fromWhat, i + muchShift];
        }
        else
        {
            field[inWhich, i] = field[fromWhat, i - field.GetLength(1) + muchShift];
        }
    }
}

void DrawField(int[,] field) // прорисовка поля
{
    for (int i = 0; i < field.GetLength(0); i++)
    {
        if (i == (int)Constants.SeparatI1 || i == (int)Constants.SeparatI2)
        {
            DrawLine();
        }
        for (int j = 0; j < field.GetLength(1); j++)
        {
            switch (field[i, j])
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
            if (j == (int)Constants.SeparatJ1 || j == (int)Constants.SeparatJ2)
            {

                Console.Write($" {field[i, j]} |");
            }
            else
            {
                Console.Write($" {field[i, j]} ");
            }
        }
        Console.WriteLine();
    }

}

void DrawLine() // прорисовка горизонтальых линий
{
    for (int i = 0; i < (int)Constants.rows; i++)
    {
        if (i == (int)Constants.SeparatJ2 || i == (int)Constants.SeparatJ1)
        {
            Console.Write($" - |");
        }
        else
        {
            Console.Write($" - ");
        }
    }
    Console.WriteLine();
}

void Level1(int[,] field) // создание 1 уровня
{
    Random random = new Random();
    double square = Math.Pow(field.GetLength(0), 2);
    for (int k = 0; k < (int)Constants.Level1; k++)
    {
        int emptyI = random.Next(0, field.GetLength(0));
        int emptyJ = random.Next(0, field.GetLength(1));
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == emptyI && j == emptyJ)
                {
                    field[i, j] = 0;
                }
            }

        }
    }
}

void Level2(int[,] field) // создание 2 уровня
{
    Random random = new Random();
    double square = Math.Pow(field.GetLength(0), 2);
    for (int k = 0; k < (int)Constants.Level2; k++)
    {
        int emptyI = random.Next(0, field.GetLength(0));
        int emptyJ = random.Next(0, field.GetLength(1));
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == emptyI && j == emptyJ)
                {
                    field[i, j] = 0;
                }
            }

        }
    }
}

void Level3(int[,] field) // создание 3 уровня
{
    Random random = new Random();
    double square = Math.Pow(field.GetLength(0), 2);
    for (int k = 0; k < (int)Constants.Level3; k++)
    {
        int emptyI = random.Next(0, field.GetLength(0));
        int emptyJ = random.Next(0, field.GetLength(1));
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == emptyI && j == emptyJ)
                {
                    field[i, j] = 0;
                }
            }

        }
    }
}

void LevelSelection(int[,] field) // Выбор уровня
{
    int level;
    bool isCorrectInput;
    Console.WriteLine("Выберите уровень от 1 до 3");

    do
    {
        isCorrectInput = true;
        level = int.Parse(Console.ReadLine());
        if (level < 1 || level > 3)
        {
            isCorrectInput = false;
            Console.WriteLine("Вы ввелим не точное значение");
        }
    } while (isCorrectInput == false);

    switch (level)
    {
        case 1:
            Level1(field);
            break;

        case 2:
            Level2(field);
            break;

        case 3:
            Level3(field);
            break;
    }
    Console.Clear();
}

int NumberZero(int[,] field, int numberZero = 0) // Количество нулей
{
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int j = 0; j < field.GetLength(1); j++)
        {
            if (field[i, j] == 0)
            {
                numberZero++;
            }
        }
    }
    return numberZero;
}

int CheckElement(int[,] mainField, int numberZero, int CellI, int CellJ, int value, ref int[,] field, ref int health)  
    // Проверка введенного значения
{


    for (int i = 0; i < mainField.GetLength(0); i++)
    {
        for (int j = 0; j < mainField.GetLength(1); j++)
        {
            if (CellI == i && CellJ == j && value == mainField[i, j])
            {
                numberZero--;
                field[i, j] = value;
            }
            else if (CellI == i && CellJ == j && value != mainField[i, j])
            {
                health--;
                Console.WriteLine("Вы ввели не точное значение");
            }
        }
    }
    return numberZero;
}

bool CheckValues(int CellI, int CellJ) // проверка введенных координат 
{
    bool checkValues = true;

    if (CellI > (int)Constants.rows && CellI < 0 || CellJ > (int)Constants.rows && CellJ < 0) 
    {
        Console.WriteLine("Вы ввели не правильные значения");
        checkValues = false;
    }
    return checkValues;
}

int Read() // считывание 
{
    return int.Parse(Console.ReadLine());
}

void CheckVin(int health) 
{
    if (health == 0)
    {
        Console.WriteLine("Вы проиграли. Ничего в следующий раз получистья");
    }
    else
    {
        Console.WriteLine("Вы победили");
    }
}

//----------------------------------------------------------------------------------------

int[,] field = new int[(int)Constants.rows, (int)Constants.cols];
int[,] mainField = new int[(int)Constants.rows, (int)Constants.cols];

// Make the first grid

AssignMainRow(field);
CreatRow(field, 3, 0, 1);
CreatRow(field, 3, 1, 2);

// Make the second grid
CreatRow(field, 1, 0, 3);
CreatRow(field, 3, 3, 4);
CreatRow(field, 3, 4, 5);

// Make the third grid

CreatRow(field, 2, 0, 6);
CreatRow(field, 3, 6, 7);
CreatRow(field, 3, 7, 8);

for (int i = 0; i < field.GetLength(0); i++)
{
    for (int j = 0; j < field.GetLength(1); j++)
    {
        mainField[i, j] = field[i, j];
    }
}

LevelSelection(field);

int numberZero = NumberZero(field);
int health = (int)Constants.health;

Console.WriteLine("Начало отсчета идеит из верхнего левого угла и начинаеться с (1, 1).");
Console.WriteLine("Сначала введите значение по вертикали а затем значение по горизонтали.");
Console.ReadLine();

while (health > 0 && numberZero != 0)
{
    Console.Clear();

    Console.WriteLine($"количество оставшихся клеток: {numberZero}");
    Console.WriteLine($"количество оставшихся жизней: {health}");

    DrawField(field);

    Console.WriteLine("Введите координату по вертикали");
    int CellI = Read() - 1;
    Console.WriteLine("Введите координату по горизонтали");
    int CellJ = Read() - 1;

    Console.WriteLine("Введите значение которе вы хотите вставить ");
    int value = Read();

    if (CheckValues(CellI, CellJ))
    {
        numberZero = CheckElement(mainField, numberZero, CellI, CellJ, value, ref field, ref health);
    }
    Console.ReadLine();
}
Console.Clear();



Console.ReadLine();