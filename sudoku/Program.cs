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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
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
        int empty = random.Next(1, (int)square + 1);
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == empty / 10 && j == empty % 10)
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
        int empty = random.Next(1, (int)square + 1);
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == empty / 10 && j == empty % 10)
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
        int empty = random.Next(1, (int)square + 1);
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == empty / 10 && j == empty % 10)
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
}

//------------------------

int[,] field = new int[(int)Constants.rows, (int)Constants.cols];

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

LevelSelection(field);

DrawField(field);

Console.ReadLine();


