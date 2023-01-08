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

DrawField(field);


