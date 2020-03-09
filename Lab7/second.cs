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
            int countOfTranspositions = 0, countOfComparisons = 0;
            const int length = 3;
            int[] originalArray = new int[length];
            int[] originalSortedArray = new int[length];
            int[] originalReversSortedArray = new int[length];
            int[] array = new int[length];
            int[] sortedArray = new int[length];
            int[] reverseSortedArray = new int[length];
            for (int i = 0; i < length; i++)
            {
                originalArray[i] = rand.Next(-999, 999);
                array[i] = originalArray[i];
                originalSortedArray[i] = array[i];
                originalReversSortedArray[i] = array[i];
                Console.WriteLine(originalArray[i]);
            }
            Console.WriteLine("First array is created");
            Console.WriteLine();
            shellSort(originalSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
            Array.Reverse(originalSortedArray);
            Console.WriteLine("Sorted array is created");
            Console.WriteLine();
            shellSort(originalReversSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
            Console.WriteLine("Reverse array is created");
            Console.WriteLine();
            int select = 0;
            while (select != 4)
            {
                Console.WriteLine("Choose array:\n1 - random array\n2 - ascending sorted array\n3 - descending sorted array\nWrite 4 if you want to quit");
                Console.WriteLine();
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Random array is chosen");
                        Console.WriteLine();

                        selectionSort(array, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        array = originalArray;
                        Console.WriteLine();

                        insertionSort(array, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        array = originalArray;
                        Console.WriteLine();

                        bubbleSort(array, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        array = originalArray;
                        Console.WriteLine();

                        shakerSort(array, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        array = originalArray;
                        Console.WriteLine();

                        shellSort(array, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shellWorkTime, countOfTranspositions, countOfComparisons);
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(array[i]);
                        }
                        array = originalArray;
                        Console.WriteLine();
                        break;
                    case 2:
                        sortedArray = originalSortedArray;
                        Console.WriteLine("Ascending sorted array is chosen");
                        Console.WriteLine();

                        selectionSort(sortedArray, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        sortedArray = originalSortedArray;
                        Console.WriteLine();

                        insertionSort(sortedArray, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        sortedArray = originalSortedArray;
                        Console.WriteLine();

                        bubbleSort(sortedArray, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        sortedArray = originalSortedArray;
                        Console.WriteLine();

                        shakerSort(sortedArray, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        sortedArray = originalSortedArray;
                        Console.WriteLine();

                        shellSort(sortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shellWorkTime, countOfTranspositions, countOfComparisons);
                        sortedArray = originalSortedArray;
                        Console.WriteLine();
                        break;
                    case 3:
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine("Descending sorted array is chosen");
                        Console.WriteLine();

                        selectionSort(reverseSortedArray, length, out selectionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Selection sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", selectionWorkTime, countOfTranspositions, countOfComparisons);
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine();

                        insertionSort(reverseSortedArray, length, out insertionWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Insertion sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", insertionWorkTime, countOfTranspositions, countOfComparisons);
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine();

                        bubbleSort(reverseSortedArray, length, out bubbleWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Bubble sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", bubbleWorkTime, countOfTranspositions, countOfComparisons);
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine();

                        shakerSort(reverseSortedArray, length, out shakerWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shaker sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shakerWorkTime, countOfTranspositions, countOfComparisons);
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine();

                        shellSort(reverseSortedArray, length, out shellWorkTime, out countOfComparisons, out countOfTranspositions);
                        Console.WriteLine("Shell sort is done at {0}\nCount of transpositions: {1}\nCount of comparisons: {2}", shellWorkTime, countOfTranspositions, countOfComparisons);
                        reverseSortedArray = originalReversSortedArray;
                        Console.WriteLine();
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
        static void selectionSort(int[] array, int length, out TimeSpan selectionWorkTime, out int countOfComparisons, out int countOfTranspositions)
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
        static void insertionSort(int[] array, int length, out TimeSpan insertionWorkTime, out int countOfComparisons, out int countOfTranspositions)
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
                array[j] = temp;
                countOfTranspositions++;
                countOfComparisons++;
            }
            DateTime endTime = DateTime.Now;
            insertionWorkTime = endTime - startTime;
        }
        static void bubbleSort(int[] array, int length, out TimeSpan bubbleWorkTime, out int countOfComparisons, out int countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < length; i++)
                for (int j = length - 1; j > i; j--)
                {
                    if (array[j - 1] < array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        countOfTranspositions++;
                    }
                    countOfComparisons++;
                }
            DateTime endTime = DateTime.Now;
            bubbleWorkTime = endTime - startTime;
        }
        static void shakerSort(int[] array, int length, out TimeSpan shakerWorkTime, out int countOfComparisons, out int countOfTranspositions)
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
        static void shellSort(int[] array, int length, out TimeSpan shellWorkTime, out int countOfComparisons, out int countOfTranspositions)
        {
            countOfComparisons = 0;
            countOfTranspositions = 0;
            DateTime startTime = DateTime.Now;
            int[] steps = {57, 23, 10, 4, 1};
            int choosenStep = steps.Length;
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
                    countOfTranspositions++;
                }
            }
            DateTime endTime = DateTime.Now;
            shellWorkTime = endTime - startTime;
        }
    }
}
