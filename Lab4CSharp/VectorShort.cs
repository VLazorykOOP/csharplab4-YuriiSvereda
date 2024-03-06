using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class VectorShort
    {
        short[] shortArray; // масив  

        uint n; // розмір вектора  

        uint codeError; // код помилки  

        static uint num_v; // кількість векторів  


        static VectorShort()
        {
            num_v = 0;
        }
        public VectorShort()
        {
            num_v++;
            n = 1;
            shortArray = new short[n];
            shortArray[0] = 0;
            codeError = 0;
        }
        public VectorShort(uint size)
        {
            num_v++;
            n = size;
            shortArray = new short[n];
            for (int i = 0; i < n; i++)
            {
                shortArray[i] = 0;
            }
            codeError = 0;
        }
        public VectorShort(uint size, short valueToFill)
        {
            num_v++;
            n = size;
            shortArray = new short[n];
            for (int i = 0; i < n; i++)
            {
                shortArray[i] = valueToFill;
            }
            codeError = 0;
        }
        ~VectorShort()
        {
            Console.WriteLine("message in console");
        }

        public uint Lenth
        {
            get
            {
                return n;
            }
        }

        public uint CodeError
        {
            get
            {
                return codeError;
            }
            set
            {
                codeError = value;
            }
        }

        public short this[int index]
        {
            get
            {
                if (index < 0 || index >= n)
                {
                    codeError = 10;
                    return 0;
                }
                return shortArray[index];
            }
            set
            {
                if (index < 0 || index >= n)
                {
                    codeError = 10;
                }
                else
                {
                    shortArray[index] = value;
                }

            }
        }


        public void EnterVectorUsingConsole()
        {
            Console.WriteLine("enter size of your vector");
            uint size;
            while (!uint.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("invalid input, value must be bigger or equal 0 \ntry again: ");
            }
            n = size;
            this.shortArray = new short[n];
            Console.WriteLine("enter your vector:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i}] = ");
                while (!short.TryParse(Console.ReadLine(), out shortArray[i]))
                {
                    Console.WriteLine("invalid input, value must be short type 0 \ntry again: ");
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine($"[{i}] = {shortArray[i]}");
            }
        }
        public void FillVectorByValue(short value)
        {
            for (int i = 0; i < n; i++)
            {
                shortArray[i] = value;
            }
        }
        public static uint NumberOfVectors()
        {
            return num_v;
        }


        public static VectorShort operator ++(VectorShort v)
        {
            for (int i = 0; i < v.Lenth; i++)
            {
                v[i]++;
            }
            return v;
        }
        public static VectorShort operator --(VectorShort v)
        {
            for (int i = 0; i < v.Lenth; i++)
            {
                v[i]--;
            }
            return v;
        }

        public static implicit operator bool(VectorShort v)
        {
            if (v.n == 0)
            {
                return false;
            }
            for (int i = 0; i < v.Lenth; i++)
            {
                if (v[i] != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !(VectorShort v)
        {
            return v.n!=0;
        }

        public static VectorShort operator ~(VectorShort v)
        {
            for (int i = 0; i < v.Lenth; i++)
            {
                v[i] = (short)~v[i];
            }
            return v;
        }

        public static VectorShort operator +(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] + v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = v1[i];
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] + v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = v2[i];
                }
                return newVec;
            }
        }
        public static VectorShort operator +(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] + scalar);
            }
            return newVec;
        }

        public static VectorShort operator -(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] - v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = v1[i];
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] - v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = (short)-v2[i];
                }
                return newVec;
            }
        }
        public static VectorShort operator -(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] - scalar);
            }
            return newVec;
        }

        public static VectorShort operator *(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] * v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] * v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
        }
        public static VectorShort operator *(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] * scalar);
            }
            return newVec;
        }

        public static VectorShort operator /(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] / v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] / v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
        }
        public static VectorShort operator /(VectorShort v, ushort scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] / scalar);
            }
            return newVec;
        }

        public static VectorShort operator %(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] % v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] % v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = 0;
                }
                return newVec;
            }
        }
        public static VectorShort operator %(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] % scalar);
            }
            return newVec;
        }

        public static VectorShort operator |(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] | v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = v1[i];
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] | v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = v2[i];
                }
                return newVec;
            }
        }
        public static VectorShort operator |(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] | scalar);
            }
            return newVec;
        }

        public static VectorShort operator ^(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] ^ v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = v1[i];
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] + v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = v2[i];
                }
                return newVec;
            }
        }
        public static VectorShort operator ^(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] ^ scalar);
            }
            return newVec;
        }

        public static VectorShort operator &(VectorShort v1, VectorShort v2)
        {
            uint newSize;
            if (v1.n >= v2.n)
            {
                newSize = v1.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v2.n; i++)
                {
                    newVec[i] = (short)(v1[i] & v2[i]);
                }
                for (int i = (int)v2.n; i < newSize; i++)
                {
                    newVec[i] = (short)(v1[i] & 0);
                }
                return newVec;
            }
            else
            {
                newSize = v2.n;
                VectorShort newVec = new VectorShort(newSize);
                for (int i = 0; i < v1.n; i++)
                {
                    newVec[i] = (short)(v1[i] & v2[i]);
                }
                for (int i = (int)v1.n; i < newSize; i++)
                {
                    newVec[i] = (short)(0 & v2[i]);
                }
                return newVec;
            }
        }
        public static VectorShort operator &(VectorShort v, short scalar)
        {
            VectorShort newVec = new VectorShort(v.n);
            for (int i = 0; i < v.n; i++)
            {
                newVec[i] = (short)(v[i] & scalar);
            }
            return newVec;
        }
    }
}
