using System;
using System.IO;

namespace Lab7
{
    public class Second
    {
        /*
        Реализовать в виде отдельных функций алгоритмы сортировки элементов
        массива (четные номера вариантов – по возрастанию, нечетные номера –
        по убыванию): выбором, вставками, пузырьком, шейкером, Шелла. Каждую
        функцию вызвать три раза для разных входных данных: 1) массив из
        100 000 элементов типа int, сгенерированный случайным образом; 2) тот же
        массив, отсортированный в порядке возрастания; 3) тот же массив,
        отсортированный в порядке убывания. Вывести на консоль и сравнить
        время работы всех алгоритмов в каждом случае ( «секунды : миллисекунды» ).
        Вывести количество сравнений и перестановок элементов для каждого
        метода сортировки во всех трех случаях. Результаты сортировки
        программно записать в файл sorted.dat. Написать также код, который
        считывает данные из этого файла и проверяет, что данные были действительно отсортированы.
        */
        public static void Execute()
        {
            Random rand = new Random();
            TimeSpan selectionWorkTime;
            TimeSpan insertionWorkTime;
            TimeSpan bubbleWorkTime;
            TimeSpan shakerWorkTime;
            TimeSpan shellWorkTime;
            ulong countOfTranspositions = 0, countOfComparisons = 0;
            const int length = 100;
            int[] originalArray = new int[length];
            int[] originalSortedArray = new int[length];
            int[] originalReversSortedArray = new int[length];
            int[] array = new int[length];
            int[] sortedArray = new int[length];
            int[] reverseSortedArray = new int[length];
            int[] arrayForCheck = new int[length];
            for (int i = 0; i < length; i++)
            {
                originalArray[i] = rand.Next(-999, 999);
                array[i] = originalArray[i];
                originalSortedArray[i] = array[i];
                originalReversSortedArray[i] = array[i];
            }
            Console.WriteLine("First array is created\n");
            shellSort(originalSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
            Array.Reverse(originalSortedArray);
            Console.WriteLine("Sorted array is created\n");
            shellSort(originalReversSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
            string directory = @"C:\Lab7_2";
            string path = directory + "\\sorted.dat";
            var directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            using (StreamReader readArray = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
            {
                try
                {
                    try
                    {
                        Console.WriteLine("Reading array from file...");
                        for (int i = 0; i < arrayForCheck.Length; i++)
                        {
                            arrayForCheck[i] = int.Parse(readArray.ReadLine());
                        }
                        Console.WriteLine("Checking array...");
                        shellSort(arrayForCheck, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        if (countOfTranspositions == 0)
                            Console.WriteLine("Array is sorted\n");
                        else
                            Console.WriteLine("Array is not sorted\n");
                    }
                    catch (ArgumentNullException)
                    {
                        bool isEmpty = true;
                        foreach (int number in arrayForCheck)
                        {
                            if (number != 0)
                                isEmpty = false;
                        }
                        if (isEmpty)
                            Console.WriteLine("File is empty!\n");
                        else
                            Console.WriteLine("Array is not full\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Array is broken\n");
                }
            }
            using (StreamWriter writeArray = new StreamWriter(new FileStream(path, FileMode.Create)))
            {
                Console.WriteLine("Writing array to file...");
                foreach (int number in originalReversSortedArray)
                {
                    writeArray.Write(number + "\n");
                }
                Console.WriteLine("Array is written\n");
            }
            Console.WriteLine("Reverse array is created\n");
            int select = 0;
            while (select != 4)
            {
                Console.WriteLine("Choose array:\n1 - random array\n2 - ascending sorted array\n3 - descending sorted array\nWrite 4 if you want to quit\n");
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Random array is chosen\n");

                        selectionSort(array, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalArray, array, length);

                        insertionSort(array, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalArray, array, length);

                        bubbleSort(array, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalArray, array, length);

                        shakerSort(array, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalArray, array, length);

                        shellSort(array, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shellWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalArray, array, length);
                        break;
                    case 2:
                        Array.Copy(originalSortedArray, sortedArray, length);
                        Console.WriteLine("Ascending sorted array is chosen\n");

                        selectionSort(sortedArray, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalSortedArray, sortedArray, length);

                        insertionSort(sortedArray, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalSortedArray, sortedArray, length);

                        bubbleSort(sortedArray, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalSortedArray, sortedArray, length);

                        shakerSort(sortedArray, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalSortedArray, sortedArray, length);

                        shellSort(sortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shellWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalSortedArray, sortedArray, length);
                        break;
                    case 3:
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);
                        Console.WriteLine("Descending sorted array is chosen\n");

                        selectionSort(reverseSortedArray, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);

                        insertionSort(reverseSortedArray, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);

                        bubbleSort(reverseSortedArray, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);

                        shakerSort(reverseSortedArray, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);

                        shellSort(reverseSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}\n", shellWorkTime, countOfTranspositions, countOfComparisons);
                        Array.Copy(originalReversSortedArray, reverseSortedArray, length);
                        break;
                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static void selectionSort(int[] array, int length, out TimeSpan selectionWorkTime, out ulong countOfComparisons, out ulong countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            for (int i = length - 1; i >= 0; i--)
            {
                int min = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] < array[min])
                        min = j;
                    countOfComparisons++;
                }
                Swap(ref array[i], ref array[min]);
                if(i != min)
                    countOfTranspositions++;
            }
            DateTime endTime = DateTime.Now;
            selectionWorkTime = endTime - startTime;
        }
        static void insertionSort(int[] array, int length, out TimeSpan insertionWorkTime, out ulong countOfComparisons, out ulong countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            for (int i = 1; i < length; i++)
            {
                int j = i;
                int temp = array[i];
                while (j > 0 && temp > array[j - 1])
                {
                    countOfComparisons++;
                    array[j] = array[j - 1];
                    j--;
                }
                countOfComparisons++;
                array[j] = temp;
                if (j != i)
                    countOfTranspositions++;
            }
            if (countOfTranspositions > 0)
                countOfTranspositions--;
            DateTime endTime = DateTime.Now;
            insertionWorkTime = endTime - startTime;
        }
        static void bubbleSort(int[] array, int length, out TimeSpan bubbleWorkTime, out ulong countOfComparisons, out ulong countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j > i; j--)
                {
                    if (array[j - 1] < array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        countOfTranspositions++;
                    }
                    countOfComparisons++;
                }
            }
            DateTime endTime = DateTime.Now;
            bubbleWorkTime = endTime - startTime;
        }
        static void shakerSort(int[] array, int length, out TimeSpan shakerWorkTime, out ulong countOfComparisons, out ulong countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            int startIndex = 0;
            DateTime startTime = DateTime.Now;
            do
            {
                for (int i = startIndex; i < length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        countOfTranspositions++;
                    }
                    countOfComparisons++;
                }
                length--;

                for (int i = length - 1; i > startIndex; i--)
                {
                    if (array[i] > array[i - 1])
                    {
                        Swap(ref array[i], ref array[i - 1]);
                        countOfTranspositions++;
                    }
                    countOfComparisons++;
                }
                startIndex++;
            }
            while (startIndex <= length - 1);
            DateTime endTime = DateTime.Now;
            shakerWorkTime = endTime - startTime;
        }
        static void shellSort(int[] array, int length, out TimeSpan shellWorkTime, out ulong countOfComparisons, out ulong countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            int[] steps = {57, 23, 10, 4, 1};
            foreach (int step in steps)
            {
                for (int i = step; i < length; i++)
                {
                    int j = i;
                    int temp = array[i];
                    while (j >= step && temp > array[j - step])
                    {
                        countOfComparisons++;
                        array[j] = array[j - step];
                        j -= step;
                    }
                    countOfComparisons++;
                    array[j] = temp;
                    if (j != i)
                        countOfTranspositions++;
                }
            }
            if(countOfTranspositions > 0)
                countOfTranspositions--;
            DateTime endTime = DateTime.Now;
            shellWorkTime = endTime - startTime;
        }
    }
}
