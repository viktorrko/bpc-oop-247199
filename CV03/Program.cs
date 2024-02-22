class CV03
{
    public static void Main(string[] args)
    {
        Matrix a = new Matrix(new double[,] { { 1, 1 }, { 1, 1 } });
        Matrix b = new Matrix(new double[,] { { 1, 1 }, { 1, 3 } });

        Console.WriteLine(a);
        Console.WriteLine(b);

        try
        {
            Console.WriteLine("a + b=");
            Console.WriteLine(Matrix.Add(a, b));
            Console.WriteLine("a - b=");
            Console.WriteLine(Matrix.Substract(a, b));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba: {e.Message}");
        }

        try
        {
            Console.WriteLine("a * b=");
            Console.WriteLine(Matrix.Multiply(a, b));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba: {e.Message}");
        }

        
        Console.WriteLine("Rovnaju sa matice? " + Matrix.Equals(a, b));
        Console.WriteLine("Nerovnaju sa matice? " + Matrix.EqualsNot(a, b));
        Console.WriteLine("Dekrement matice a\n" +Matrix.Decrement(a));

        try
        {
            Console.WriteLine("Determinant matice a = " + Matrix.Determinant(a));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Chyba: {e.Message}");
        }
    }
}

class Matrix
{
    public double[,] matrix;

    public Matrix(double[,] matrixIn)
    {
        matrix = matrixIn;
    }

    // vypisanie na obrazovku cez ToString override
    public override string ToString()
    {
        int aRows = matrix.GetLength(0);
        int aColumns = matrix.GetLength(1);

        string str = "";

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                str += string.Format("{0,10:F2}", matrix[i, j]);
            }
            str += Environment.NewLine;
        }
        return str;
    }

    // +
    public static Matrix Add(Matrix a, Matrix b)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);
        int bRows = b.matrix.GetLength(0);
        int bColumns = b.matrix.GetLength(1);

        double[,] res = new double[aRows, aColumns];

        if (aRows != bRows || aColumns != bColumns)
        {
            throw new Exception("Matice nemaju rovnaky rozmer.");
        }

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                res[i, j] = a.matrix[i, j] + b.matrix[i, j];
            }
        }

        return new Matrix(res);
    }

    // -
    public static Matrix Substract(Matrix a, Matrix b)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);
        int bRows = b.matrix.GetLength(0);
        int bColumns = b.matrix.GetLength(1);

        double[,] res = new double[aRows, aColumns];

        if (aRows != bRows || aColumns != bColumns)
        {
            throw new Exception("Matice nemaju rovnaky rozmer.");
        }

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                res[i, j] = a.matrix[i, j] - b.matrix[i, j];
            }
        }

        return new Matrix(res);
    }

    // *
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);
        int bRows = b.matrix.GetLength(0);
        int bColumns = b.matrix.GetLength(1);

        if (aColumns != bRows)
        {
            throw new Exception("Matice maju neplatny rozmer.");
        }

        double[,] res = new double[aRows, bColumns];

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < bColumns; j++)
            {
                for (int k = 0; k < aColumns; k++)
                {
                    res[i, j] += a.matrix[i, k] * b.matrix[k, j];
                }
            }
        }

        return new Matrix(res);
    }
    
    // ==
    public static bool Equals(Matrix a, Matrix b)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);
        int bRows = b.matrix.GetLength(0);
        int bColumns = b.matrix.GetLength(1);

        if(aRows != bRows || aColumns != bColumns) return false;
        
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                if (a.matrix[i, j] != b.matrix[i, j]) return false;
            }
        }
        return true;
    }

    // !=
    public static bool EqualsNot(Matrix a, Matrix b)
    {
        if (Equals(a, b)) return false;
        else return true;
    }

    // unarny dekrement
    public static Matrix Decrement(Matrix a)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);

        double[,] res = new double[aRows, aColumns];

        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < aColumns; j++)
            {
                res[i, j] = a.matrix[i, j] - 1;
            }
        }

        return new Matrix(res);
    }

    // determinant
    public static double Determinant(Matrix a)
    {
        int aRows = a.matrix.GetLength(0);
        int aColumns = a.matrix.GetLength(1);

        double res = 0;

        if(aRows != aColumns)
        {
            throw new Exception("Matica nieje stvorcova.");
        }

        if(aRows > 3)
        {
            throw new Exception("Rozmer matice je vacsi ako 3x3.");
        }

        if(aRows == 1)
        {
            res = a.matrix[0, 0];

        }
        else if (aRows == 2)
        {
            res = (a.matrix[0, 0] * a.matrix[1, 1] - (a.matrix[1, 0] * a.matrix[0, 1]));
        }
        else
        {
            res =
                (
                (a.matrix[0, 0] * a.matrix[1, 1] * a.matrix[2, 2]) +
                (a.matrix[0, 1] * a.matrix[1, 2] * a.matrix[2, 0]) +
                (a.matrix[0, 2] * a.matrix[1, 0] * a.matrix[2, 1]) -
                (a.matrix[0, 2] * a.matrix[1, 1] * a.matrix[2, 0]) -
                (a.matrix[0, 0] * a.matrix[1, 2] * a.matrix[2, 1]) -
                (a.matrix[0, 1] * a.matrix[1, 0] * a.matrix[2, 2])
                );
        }

        return res;
    }
}