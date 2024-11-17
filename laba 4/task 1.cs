class MyMatrix
{
    private double[,] matrix;
    public MyMatrix(int n, int m, double minValue, double maxValue)
    {
        matrix = new double[m, n];
        Random rand = new Random();

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.NextDouble() * (maxValue - minValue) + minValue;
            }
        }
    }

    public double this[int n, int m]
    {
        get
        {
            if (n >= 0 && n < matrix.GetLength(0) && m >= 0 && m < matrix.GetLength(1))
            {
                return matrix[n, m];
            }
            else
            {
                throw new IndexOutOfRangeException("Неверные индексы для установки элементов матрицы");
            }
        }
            set
        {
            if (n >= 0 && n < matrix.GetLength(0) && m >= 0 && m < matrix.GetLength(1))
            {
                matrix[n, m] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Неверные индексы для установки элементов матрицы");
            }
        }
    }

    public int height
    {
        get { return matrix.GetLength(0); }
    }

    public int len
    {
        get { return matrix.GetLength(1); }
    }


    public void Print()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < len; j++)
            {
                Console.Write($"{matrix[i, j]:F2}\t");
            }
            Console.WriteLine();
        }
    }

    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.height != b.height || a.len != b.len)
        {
            throw new InvalidOperationException("Матрицы должны быть одинакового размера для сложения");
        }

        MyMatrix result = new MyMatrix(a.height, a.len, 0, 0);

        for (int i = 0; i < a.height; i++)
        {
            for (int j = 0; j < a.len; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        if (a.height != b.height || a.len != b.len)
        {   
            throw new InvalidOperationException("Матрицы должны быть одинакового размера для вычитания");
        }

        MyMatrix result = new MyMatrix(a.height, a.len, 0, 0);

        for (int i = 0; i < a.height; i++)
        {
            for (int j = 0; j < a.len; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }

        return result;
    }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.len != b.height)
        {
            throw new InvalidOperationException("Для умножения количество столбцов первой матрицы должно быть равно количеству строк второй матрицы");
        }

        MyMatrix result = new MyMatrix(a.height, b.len, 0, 0);

        for (int i = 0; i < a.height; i++)
        {
            for (int j = 0; j < b.len; j++)
            {
                result[i, j] = 0;       
                for (int k = 0; k < a.len; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }
    public static MyMatrix operator *(MyMatrix a, double scalar)
    {
        MyMatrix result = new MyMatrix(a.height, a.len, 0, 0);

        for (int i = 0; i < a.height; i++)
        {
            for (int j = 0; j < a.len; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }

        return result;
    }

    public static MyMatrix operator /(MyMatrix a, double scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Деление на ноль недопустимо");
        }

        MyMatrix result = new MyMatrix(a.height, a.len, 0, 0);

        for (int i = 0; i < a.height; i++)
        {
            for (int j = 0; j < a.len; j++)
            {
                result[i, j] = a[i, j] / scalar;
            }
        }

        return result;
    }
}
class program
{
    static void Main(string[] args)
    {
        MyMatrix matrix1 = new MyMatrix(3, 3, 1, 10);
        MyMatrix matrix2 = new MyMatrix(3, 3, 1, 10);

        matrix1.Print();

        Console.WriteLine("Матрица 2:");
        matrix2.Print();

        MyMatrix sumMatrix = matrix1 + matrix2;
        Console.WriteLine("Сумма матриц:");
        sumMatrix.Print();

        MyMatrix multipliedMatrix = matrix1 * 2;
        Console.WriteLine("Матрица 1, умноженная на 2:");
        multipliedMatrix.Print();

        MyMatrix productMatrix = matrix1 * matrix2;
        Console.WriteLine("Произведение матриц:");
        productMatrix.Print();


    }
}