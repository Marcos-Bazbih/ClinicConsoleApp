using System;

namespace ClinicConsoleApp
{
    class Journal
    {
        public int rows;
        public int columns;

        public int[,] journal2dArray;

        public Journal(int _rows, int _columns)
        {
            this.rows = _rows;
            this.columns = _columns;
            this.journal2dArray = new int[this.rows, this.columns];
        }
        public void PrintJournal()
        {

            for (int i = 0; i < this.journal2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.journal2dArray.GetLength(1); j++)
                {
                    this.journal2dArray[i, j] = new Random().Next(0, 10);
                    if (j == this.journal2dArray.GetLength(1) - 1)
                    {
                        this.journal2dArray[i, j] = 0;
                    }

                }
            }

            for (int i = 0; i < this.journal2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < this.journal2dArray.GetLength(1); j++)
                {
                    if (this.journal2dArray[i, j] > 5)
                    {
                        Console.Write("busy ");
                    }
                    else
                    {
                        Console.Write(this.journal2dArray[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
