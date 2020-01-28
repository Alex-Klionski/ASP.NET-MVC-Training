using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Задача: реализовать метод Filter, который должен возвращать входной массив, в котором удалены элементы, которые встречаются более одного раза.
//   * Значения в массиве должны следовать в том порядке, в котором они следуют в оригинальном массиве.
//   * Если в массиве встречаются повторяющиеся значения, то они ВСЕ значения должны быть удалены.
//   * Метод должен выбрасывать исключение ArgumentNullException в случае, если в метод передали null.
//   * В решении разрешается использовать только конструкции языка. Использовать LINQ запрещено.

public class Program
{
    public static int[] Filter(int[] source)
    {

      
        if(source == null)
        {
            ArgumentNullException argumentNull = new ArgumentNullException();
            throw argumentNull;
        }
        
        ArrayList tempList = new ArrayList();
        for (int i = 0; i < source.Length; i++)
        {
            for (int j = i + 1; j < source.Length; j++)
            {
                if (source[i] == source[j])
                {
                    int flag = 0;
                    for (int k = 0; k < i; k++)
                    {
                        if (source[k] == source[i])
                        {
                            flag = 1; break;
                        }
                    }
                    if (flag == 0)
                    {
                        tempList.Add(source[i]);
                    }
                    break;
                }
            }

        }
      
        for(int i = 0; i < tempList.Count; i++)
        {
            delByValue(ref source, Convert.ToInt32(tempList[i]));
        }

        return source;
    }
    public static void delByIndex(ref int[] data, int delIndex)
    {
        int[] newData = new int[data.Length - 1];
        for (int i = 0; i < delIndex; i++)
        {
            newData[i] = data[i];
        }
        for (int i = delIndex; i < newData.Length; i++)
        {
            newData[i] = data[i + 1];
        }
        data = newData;
    }

    public static void delByValue(ref int[] data, int delValue)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == delValue)
            {
                delByIndex(ref data, i);
                i--;
            }
        }
    }
    public static int[] BumbleSort(int[] array)
    {
        for (int k = 0; k < array.Length; k++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }
    // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

    public static void Main()
    {
        Console.WriteLine("Task is done when all test cases are correct:");

        int testCaseNumber = 1;

        TestReturnedValues(testCaseNumber++, new int[] { }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0 }, new int[] { 0 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1 }, new int[] { 0, 1 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 0 }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0 }, new int[] { 1 });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 0, 1 }, new int[] { });
        TestReturnedValues(testCaseNumber++, new int[] { 0, 1, 2, 2, 5, 4, 4, 5, 1, 8, 4, 9, 1, 3, 4, 5, 7 }, new int[] { 0, 8, 9, 3, 7 });
        TestException<ArgumentNullException>(testCaseNumber++, null);

        if (correctTestCaseAmount == testCaseNumber - 1)
        {
            Console.WriteLine("Task is done.");
        }
        else
        {
            Console.WriteLine("TASK IS NOT DONE.");
        }
    }

    private static void TestReturnedValues(int testCaseNumber, int[] array, int[] expectedResult)
    {
        try
        {
            var result = Filter(array);

            if (result.SequenceEqual(expectedResult))
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            else
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }
        catch (Exception)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
        }
    }

    private static void TestException<T>(int testCaseNumber, int[] array) where T : Exception
    {
        try
        {
            Filter(array);
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
        catch (T)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
            correctTestCaseAmount++;
        }
        catch (Exception)
        {
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
    }

    private static string correctCaseTemplate = "Case #{0} is correct.";
    private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
    private static int correctTestCaseAmount = 0;
}
