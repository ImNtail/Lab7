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
        считывает данные из этого файла и проверяет, что данные были
        действительно отсортированы.
        */
        public static void Execute()
        {
            Random rand = new Random();
            const int length = 10;
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(-999, 999);
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("Array is created");
            Console.WriteLine();
            int select;
            do
            {
                Console.WriteLine("Choose the sort method\n1 - selection sort\n2 - insertion sort\n3 - bubble sort\n4 - shaker sort\n5 - Shell sort\nWrite 6 if you want to quit");
                Console.WriteLine();
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        Console.WriteLine("Selection sort");
                        selectionSort(array, length);
                        break;
                    case 2:
                        Console.WriteLine("Insertion sort");
                        insertionSort(array, length);
                        break;
                    case 3:
                        Console.WriteLine("Bubble sort");
                        bubbleSort(array, length);
                        break;
                    case 4:
                        Console.WriteLine("Shaker sort");
                        shakerSort(array, length);
                        break;
                    case 5:
                        Console.WriteLine("Shell sort");
                        shellSort(array, length);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Sorted array:");
                for (int i = 0; i < length; i++)
                {
                    Console.WriteLine(array[i]);
                }
                Console.WriteLine();
            }
            while (select != 6);
        }
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static void selectionSort(int[] array, int length)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                int min = i;
                for (int j = i - 1; j >= 0; j--)
                    if (array[j] < array[min])
                        min = j;
                Swap(ref array[i], ref array[min]);
            }
        }
        static void insertionSort(int[] array, int length)
        {
            for (int i = 1; i < length; i++)
            {
                int j = i;
                int temp = array[i];
                while (j > 0 && temp > array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
        }
        static void bubbleSort(int[] array, int length)
        {
            for (int i = 0; i < length; i++)
                for (int j = length-1; j > i; j--)
                    if (array[j - 1] < array[j])
                        Swap(ref array[j - 1], ref array[j]);
        }
        static void shakerSort(int[] array, int length)
        {
            int startIndex = 0;
            do
            {
                for (int i = startIndex; i < length - 1; i++)
                {
                    if (array[i] < array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
                length--;

                for (int i = length - 1; i > startIndex; i--)
                {
                    if (array[i] > array[i - 1])
                    {
                        Swap(ref array[i], ref array[i - 1]);
                    }
                }
                startIndex++;
            }
            while (startIndex <= length - 1);
        }
        static void shellSort(int[] array, int length)
        {
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
                        array[j] = array[j - step];
                        j -= step;
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
