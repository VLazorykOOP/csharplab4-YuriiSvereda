using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class MatrixShort
    {
        uint[,] ShortArray; // масив  

        int n, m; // розміри матриці  

        int codeError; // код помилки  

        static int num_m; // кількість матриць 


        //CONSTRUCTORS
        static MatrixShort() => num_m = 0;
        public MatrixShort()
        {
            n = 1;
            m = 1;
            ShortArray = new uint[n, m];
            ShortArray[0, 0] = 0;
            num_m++;
        }
        public MatrixShort(int n, int m)
        {
            if (n < 0 || m < 0)
            {
                Console.WriteLine("WRNING! value of matrix size cannot be negative, so matrix will inicialise by default");
                n = 0;
                m = 0;
            }
            this.n = n;
            this.m = m;
            ShortArray = new uint[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortArray[i, j] = 0;
                }
            }
            num_m++;
        }
        public MatrixShort(int n, int m, uint val)
        {
            if (n < 0 || m < 0)
            {
                Console.WriteLine("WRNING! value of matrix size cannot be negative, so matrix will inicialise by default");
                n = 0;
                m = 0;
            }
            this.n = n;
            this.m = m;
            ShortArray = new uint[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortArray[i, j] = val;
                }
            }
            num_m++;
        }
        ~MatrixShort()
        {
            Console.WriteLine("Message from destructor");
        }


        //PROPERTIES
        public int RowsNumber
        {
            get { return n; }
        }
        public int ColumnsNumber
        {
            get { return m; }
        }

        public int CodeError
        {
            get { return codeError; }
            set
            {
                codeError = value;
            }
        }


        //METHODES
        public void EnterMatrixUsingConsole()
        {
            int nSize, mSize;
            Console.WriteLine("enter number of rows of matrix:");
            while (!int.TryParse(Console.ReadLine(), out nSize))
            {
                if (nSize < 0)
                {
                    continue;
                }
                Console.WriteLine("invalid input, value must be bigger or equal 0 \ntry again: ");
            }

            Console.WriteLine("enter number of columns of matrix:");
            while (!int.TryParse(Console.ReadLine(), out mSize))
            {
                if (nSize < 0)
                {
                    continue;
                }
                Console.WriteLine("invalid input, value must be bigger or equal 0 \ntry again: ");

            }
            n = nSize;
            m = mSize;
            ShortArray = new uint[n, m];
            Console.WriteLine("enter your matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"[{i},{j}] = ");
                    while (!uint.TryParse(Console.ReadLine(), out ShortArray[i, j]))
                    {
                        Console.WriteLine("invalid input, value must be uint type 0 \ntry again: ");
                    }
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"[{i},{j}] = {ShortArray[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
        public void FillMatrixByValue(uint value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ShortArray[i, j] = value;
                }
            }
        }
        public static int NumberOfMatrixes()
        {
            return num_m;
        }


        //INDEXERS
        public uint this[int iIndex, int jIndex]
        {
            get
            {
                if (iIndex < 0 || jIndex < 0 ||
                    iIndex >= n || jIndex >= m)
                {
                    codeError = -1;
                    return 0;
                }
                return ShortArray[iIndex, jIndex];
            }
            set
            {
                if (iIndex >= 0 && jIndex >= 0 &&
                    iIndex < n && jIndex < m)
                {
                    ShortArray[iIndex, jIndex] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }


        //OVERRIDING
        public static MatrixShort operator ++(MatrixShort matrix)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    matrix.ShortArray[i, j]++;
                }
            }
            return matrix;
        }
        public static MatrixShort operator --(MatrixShort matrix)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    matrix.ShortArray[i, j]--;
                }
            }
            return matrix;
        }

        public static implicit operator bool(MatrixShort matrix)
        {
            if (matrix.n == 0 && matrix.m == 0)
            {
                return false;
            }
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator !(MatrixShort matrix)
        {
            return matrix.n != 0 && matrix.m != 0;
        }
        public static MatrixShort operator ~(MatrixShort matrix)
        {
            var newMat = new MatrixShort(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    newMat.ShortArray[i, j] = ~matrix.ShortArray[i, j];
                }
            }
            return newMat;
        }

        public static MatrixShort operator +(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat1.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return result;

        }
        public static MatrixShort operator +(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] + scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator -(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat1.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result[i, j] = mat1[i, j] - mat2[i, j];
                }
            }
            return result;
        }
        public static MatrixShort operator -(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] - scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator *(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.m != mat2.n)
            {
                throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat2.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat2.m; j++)
                {
                    for (int k = 0; k < mat1.m; k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }
            return result;
        }
        public static MatrixShort operator *(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] * scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator /(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] / scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator %(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] % scalar);
                }
            }
            return resMat;
        }

        public static MatrixShort operator |(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.m || mat1.m != mat2.m)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat1.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result[i, j] = mat1[i, j] | mat2[i, j];
                }
            }
            return result;
        }
        public static MatrixShort operator |(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] | scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator &(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat1.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result[i, j] = mat1[i, j] & mat2[i, j];
                }
            }
            return result;
        }
        public static MatrixShort operator &(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] & scalar);
                }
            }
            return resMat;
        }
        public static MatrixShort operator ^(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            MatrixShort result = new MatrixShort(mat1.n, mat1.m);
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    result[i, j] = mat1[i, j] ^ mat2[i, j];
                }
            }
            return result;
        }
        public static MatrixShort operator ^(MatrixShort mat, short scalar)
        {
            var resMat = new MatrixShort(mat.n, mat.m);
            for (int i = 0; i < resMat.n; i++)
            {
                for (int j = 0; j < resMat.m; j++)
                {
                    resMat.ShortArray[i, j] = (uint)(mat.ShortArray[i, j] ^ scalar);
                }
            }
            return resMat;
        }

        public static bool operator ==(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                return false;
            }
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    if (mat1[i, j] != mat2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !=(MatrixShort mat1, MatrixShort mat2)
        {
            if (mat1.n != mat2.n || mat1.m != mat2.m)
            {
                return true;
            }
            for (int i = 0; i < mat1.n; i++)
            {
                for (int j = 0; j < mat1.m; j++)
                {
                    if (mat1[i, j] != mat2[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator <(MatrixShort mat1, MatrixShort mat2)
        {
            if(mat1.ShortArray.Length != mat2.ShortArray.Length)
            {
                return mat1.ShortArray.Length < mat2.ShortArray.Length;
            }
            ulong mat1Sum = 0, mat2Sum = 0;
            foreach(var el in mat1.ShortArray)
            {
                mat1Sum += el;
            }
            foreach(var el in mat2.ShortArray)
            {
                mat2Sum += el;
            }
            return mat1Sum < mat2Sum;
        }
        public static bool operator >(MatrixShort mat1, MatrixShort mat2)
        {
            if(mat1.ShortArray.Length != mat2.ShortArray.Length)
            {
                return mat1.ShortArray.Length > mat2.ShortArray.Length;
            }
            ulong mat1Sum = 0, mat2Sum = 0;
            foreach(var el in mat1.ShortArray)
            {
                mat1Sum += el;
            }
            foreach(var el in mat2.ShortArray)
            {
                mat2Sum += el;
            }
            return mat1Sum > mat2Sum;
        }
        public static bool operator >=(MatrixShort mat1, MatrixShort mat2)
        {
            if(mat1.ShortArray.Length != mat2.ShortArray.Length)
            {
                return mat1.ShortArray.Length >= mat2.ShortArray.Length;
            }
            ulong mat1Sum = 0, mat2Sum = 0;
            foreach(var el in mat1.ShortArray)
            {
                mat1Sum += el;
            }
            foreach(var el in mat2.ShortArray)
            {
                mat2Sum += el;
            }
            return mat1Sum >= mat2Sum;
        }
        public static bool operator <=(MatrixShort mat1, MatrixShort mat2)
        {
            if(mat1.ShortArray.Length != mat2.ShortArray.Length)
            {
                return mat1.ShortArray.Length <= mat2.ShortArray.Length;
            }
            ulong mat1Sum = 0, mat2Sum = 0;
            foreach(var el in mat1.ShortArray)
            {
                mat1Sum += el;
            }
            foreach(var el in mat2.ShortArray)
            {
                mat2Sum += el;
            }
            return mat1Sum <= mat2Sum;
        }
    }
}
