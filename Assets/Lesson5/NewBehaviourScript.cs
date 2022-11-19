using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Задание 1: " + SummEvenNumbers(7, 21));
        Debug.Log("Задание 2: " + SummEvenNumbers(new int[10] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 }));
        Debug.Log("Задание 3: " + SearchIndex(34, new int[10] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 }));
        Debug.Log("Задание 3: " + SearchIndex(55, new int[10] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 }));
        
        int[] array = SortArray(new int[10] {4, 9, 5, 2, 4, 6, 7, 1, 8, 5});
        
        Debug.Log("Задание 4:");
        
        foreach (int i in array)
        {
            Debug.Log(i);
        }
    }

    private int SummEvenNumbers(int minD, int maxD)
    {
        int result = 0;

        for (int i = minD; i <= maxD; i++)
        {
            if (i % 2 == 0)
            {
                result += i;
            }
        }
        return result;
    }

    private int SummEvenNumbers(int[] array)
    {
        int result = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                result += array[i];
            }
        }
        return result;
    }

    private int SearchIndex(int number, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                return i;
            }
        }
        return -1;
    }

    private int[] SortArray(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > k)
            {
                array[j + 1] = array[j];
                array[j] = k;
                j--;
            }
        }

        return array;
    }
}
