using SudokyConstants;

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

int[,] CopyArray(int[,] field, int[,] array)
{
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int j = 0; j < field.GetLength(1); j++)
        {
            array[i, j] = field[i, j];
        }
    }

    return array;
}

void DrawField(int[,] field)
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

void DrawLine()
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

void Level1(int[,] field)
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

void Level2(int[,] field)
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

void Level3(int[,] field)
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

int CheckValue(int frontMany, int untilMany, string words) // проверка точности введенного значения
{
    bool isCorrectInput;
    int level;

    Console.WriteLine($"{words}");

    do
    {
        isCorrectInput = true;
        level = int.Parse(Console.ReadLine());
        if (level < frontMany || level > untilMany)
        {
            isCorrectInput = false;
            Console.WriteLine("Вы ввелим не точное значение, введите его заново");
        }
    } while (isCorrectInput == false);
    return level;
}

void LevelSelection(int[,] field)
{
    int level;

    level = CheckValue(1, 3, "Выберите уровень от 1 до 3");

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

int CheckElement(int[,] mainField, int numberZero, int cellI, int cellJ, int value, ref int[,] field, ref int health)
// Проверка введенного значения на правильность
{


    for (int i = 0; i < mainField.GetLength(0); i++)
    {
        for (int j = 0; j < mainField.GetLength(1); j++)
        {
            if (cellI == i && cellJ == j && value == mainField[i, j])
            {
                numberZero--;
                field[i, j] = value;
            }
            else if (cellI == i && cellJ == j && value != mainField[i, j])
            {
                health--;
                Console.WriteLine("XXX Вы ввели не правильное значение для этой клетки XXX");
            }
        }
    }
    return numberZero;
}

void CheckVin(int health) // Итоговая проверка значений
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

bool CheckVinOrLoss(int health, int numberZero) // Промежуточная проверка выйгрыша или проигрыша
{
    bool check = false;
    if (health > 0 && numberZero != 0)
    {
        check = true;
    }
    return check;
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

CopyArray(field, mainField);

LevelSelection(field);

int numberZero = NumberZero(field);
int health = (int)Constants.health;

Console.WriteLine("Начало отсчета идеит из верхнего левого угла и начинаеться с (1, 1).");
Console.WriteLine("Сначала введите значение по вертикали а затем значение по горизонтали.");
Console.ReadLine();

while (CheckVinOrLoss(health, numberZero))
{
    Console.Clear();

    Console.WriteLine($"количество оставшихся клеток: {numberZero}");
    Console.WriteLine($"количество оставшихся жизней: {health}");

    DrawField(field);

    int cellI;
    cellI = CheckValue(1, 9, "Введите координату по вертикали от 1 до 9") - 1;
    int cellJ;
    cellJ = CheckValue(1, 9, "Введите координату по горизонтали от 1 до 9") - 1;

    int value;
    value = CheckValue(1, 9, "Введите значение для заданной вами клетки");

    numberZero = CheckElement(mainField, numberZero, cellI, cellJ, value, ref field, ref health);

    Console.ReadLine();
}
Console.Clear();

CheckVin(health);

Console.ReadLine();