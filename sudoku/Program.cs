using SudokyConstants;

void AssignMainRow(int[,] field)
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

void CreatRow(int[,] field, int muchShift, int fromWhat, int inWhich)
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

void DrawField(int[,] field)
{
    for (int i = 0; i < field.GetLength(0); i++)
    {
        if (i == 3 || i == 6)
            DrawLine();
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
            if (j == 2 || j == 5)
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
        if (i == 2 || i == 5)
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

void LevelSelection(int[,] field)
{
    int level;
    try
    {
        Console.WriteLine("Введите уровень который вы хотите пройти от 1 до 3");
        level = int.Parse(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Вы ввели не точное значение введите его заново от 1 до 3");
        level = int.Parse(Console.ReadLine());
    }
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

int NumberZero(int[,] field, int numberZero = 0)
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

int CheckElement(int[,] mainField,int numberZero, int CellI, int CellJ, int value, ref int[,] field, ref int health) 
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
            else if(CellI == i && CellJ == j && value != mainField[i, j])
            {
                health--;
                Console.WriteLine("Вы ввели не точное значение");
            }
        }
    }
    return numberZero;
} 

//------------------------

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

for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        mainField[i, j] = field[i, j];
    }
}

LevelSelection(field);

int numberZero = NumberZero(field);
int health = 3;

Console.WriteLine("Начало отсчета идеит из верхнего левого угла и начинаеться с (1, 1).");
Console.WriteLine("Сначала введите значение по вертикали а затем значение пог горизонтали.");
Console.ReadLine();

while (health > 0) 
{
    Console.Clear();
    Console.WriteLine($"количество оставшихся клеток: {numberZero}");
    Console.WriteLine($"количество оставшихся жизней: {health}");
    DrawField(field);
    Console.WriteLine("Сначала введеите кординату клетки");
    int CellI = int.Parse(Console.ReadLine()) - 1;
    int CellJ = int.Parse(Console.ReadLine()) - 1;
    Console.WriteLine("Введите значение котоое вы хотите вставить");
    int value = int.Parse(Console.ReadLine());
    numberZero = CheckElement(mainField, numberZero, CellI, CellJ, value, ref field, ref health);
    Console.ReadLine();
}

if (health == 0)
{
    Console.WriteLine("Ничего в следующий раз получистья");
}
else 
{
    Console.WriteLine("Ура вы победили");
}

Console.ReadLine();


