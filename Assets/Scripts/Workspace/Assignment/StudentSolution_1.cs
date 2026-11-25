using System;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        row = i;
                        col = j;                        
                        return new[] { row, col };
                    }
                }
            }

            return new[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return index;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1) first = i;
                    last = i;
                }
            }

            if (first == -1)
                return new[] { -1 };

            return new[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            int result = -1;
            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target && (!found || array[i] > result))
                {
                    result = array[i];
                    found = true;
                }
            }

            return result;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                    count++;
            }

            int[] result = new int[count];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    result[k] = array[i];
                    k++;
                }
            }

            return result;
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            int n = enemyHPs.Length;

            int[] keys = (int[])enemyHPs.Clone();
            int[] indices = new int[n];
            for (int i = 0; i < n; i++) indices[i] = i;
            Array.Sort(keys, indices);

            bool[] chosen = new bool[n];
            int remaining = mana;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (keys[i] <= remaining)
                {
                    remaining -= keys[i];
                    chosen[indices[i]] = true;
                    count++;
                }
                else
                {
                    break; 
                }
            }

            int[] result = new int[count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (chosen[i])
                {
                    result[k] = enemyHPs[i];
                    k++;
                }
            }

            return result;
        }

        #endregion
    }
}
