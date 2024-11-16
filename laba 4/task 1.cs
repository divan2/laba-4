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
}