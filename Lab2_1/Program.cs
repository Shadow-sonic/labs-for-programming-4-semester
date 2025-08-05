using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Введите что-нибудь: ");
            string? input = Console.ReadLine();

            if (input == null)
            {
                throw new Exception("вводные данные не могут быть пустыми");
            }

            int variant = ComputeVariant(input);
            Console.WriteLine($"Вариант: {variant}");
        }
    }
    
    // Метод для вычисления варианта
    public static int ComputeVariant(string input)
    {
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach (char c in input)
        {
            int codePoint = (int)c; // Получаем Unicode-код символа
            Console.WriteLine($"Код символа '{c}' : {codePoint}");
            if (charCounts.ContainsKey(c))
                charCounts[c]++;
            else
                charCounts[c] = 1;
        }

        long sum = 0;
        foreach (var pair in charCounts)
        {
            sum += (long)Math.Pow((int)pair.Key, pair.Value);
            System.Console.WriteLine(sum);
        }

        return (int)(sum % 8);
    }

}