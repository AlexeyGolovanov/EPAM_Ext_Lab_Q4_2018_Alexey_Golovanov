namespace Task3
{
    using System;

    public class Array3d
    {
        private const int Dim = 3;

        public static void Array3DEnterPoint()
        {
            var rnd = new Random();
            var dimensions = new int[Dim];
            for (int i = 0; i < Dim; i++)
            {
                dimensions[i] = rnd.Next(1, 99);
            }

            Console.WriteLine(Resources.arrSize, dimensions[0], dimensions[1], dimensions[2]);
            var startArray = new int[dimensions[0], dimensions[1], dimensions[2]];
            startArray = InitArray(startArray, dimensions);
            Console.WriteLine(Resources.arr3dStart + CountPos(startArray, dimensions));
            startArray = PositiveToZero(startArray, dimensions);
            Console.WriteLine(Resources.arr3dFinish + CountPos(startArray, dimensions));
        }

        private static int[,,] InitArray(int[,,] emptyArr, int[] dims)
        {
            var rnd = new Random();
            for (var i = 0; i < dims[0]; i++)
            {
                for (var j = 0; j < dims[1]; j++)
                {
                    for (var k = 0; k < dims[2]; k++)
                    {
                        emptyArr[i, j, k] = rnd.Next(-999, 999);
                    }
                }
            }

            return emptyArr;
        }

        private static int[,,] PositiveToZero(int[,,] withPositive, int[] dims)
        {
            for (var i = 0; i < dims[0]; i++)
            {
                for (var j = 0; j < dims[1]; j++)
                {
                    for (var k = 0; k < dims[2]; k++)
                    {
                        if (withPositive[i, j, k] > 0)
                        {
                            withPositive[i, j, k] = 0;
                        }
                    }
                }
            }

            return withPositive;
        }

        private static int CountPos(int[,,] withPositive, int[] dims)
        {
            int n = 0;
            for (var i = 0; i < dims[0]; i++)
            {
                for (var j = 0; j < dims[1]; j++)
                {
                    for (var k = 0; k < dims[2]; k++)
                    {
                        if (withPositive[i, j, k] > 0)
                        {
                            n++;
                        }
                    }
                }
            }

            return n;
        }  
    }
}
