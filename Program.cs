//CPRG 211 F Lab 0 - Basics of C#
//Michael (Zi) Liang 000921925
//Jan 14, 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CPRG211FLab0
{
    class Program
    {
        static void Main(string[] args)
        {
			int lowNum = GetLowNumber();
			int highNum = GetHighNumber(lowNum);

			int diff = highNum - lowNum;
			Console.WriteLine($"The difference between the two numbers is: {diff}");

			int[] numsBetween = new int[diff + 1]; //+1 because list will include lowNum and highNum themselves

			for (int i = 0; i <= diff; i++)
            {
				numsBetween[i] = lowNum + i;
				//Console.WriteLine($"The value at index {i} is: {numsBetween[i]}");
			}

			//write to numbers.txt
			//Absolute pathing is required for reasons I don't know
			using (StreamWriter sw = new StreamWriter("C:/Users/zimic/source/repos/CPRG211FLab0/numbers.txt"))
			{
				for (int i = numsBetween.Length - 1; i >= 0; i--)
				{
					sw.WriteLine(numsBetween[i]);
				}
			}

			//read from numbers.txt
			//Reference for Peek(): https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader.peek?view=net-8.0
			//Reference for Readline(): https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader.readline?view=net-8.0
			int sum = 0;
			using (StreamReader sr = new StreamReader("C:/Users/zimic/source/repos/CPRG211FLab0/numbers.txt"))
            {
				while (sr.Peek() >= 0)
                {
					int num;
					bool t = int.TryParse(sr.ReadLine(), out num);
					if (t)
                    {
						sum += num;
                    }
                }
            }
			Console.WriteLine($"The sum of all numbers in the file is: {sum}");


			//Instead of asking user for new inputs, the List of doubles uses the same inputs highNum and lowNum as the array numsBetween.
            List<double> ListOfNumbers = new List<double>();
            for (int i = 0; i <= diff; i++)
            {
                ListOfNumbers.Add(lowNum + i);
                //Console.WriteLine($"The value at index {i} of the List is: {ListOfNumbers[i]}");
            }

			//write to numbers_list.txt
			using (StreamWriter sw = new StreamWriter("C:/Users/zimic/source/repos/CPRG211FLab0/numbers_list.txt"))
			{
				foreach (double number in ListOfNumbers) //In ascending, not reverse, order.
				{
					sw.WriteLine(number);
				}
			}

			//read from numbers_list.txt
			using (StreamReader sr = new StreamReader("C:/Users/zimic/source/repos/CPRG211FLab0/numbers_list.txt"))
			{
				while (sr.Peek() >= 0)
				{
					int num;
					bool t = int.TryParse(sr.ReadLine(), out num);
					if (t && IsPrime(num))
					{
						Console.WriteLine($"{num} is prime.");
					}
				}
			}
		}

		public static int GetLowNumber()
		{
			int newLow;
			Console.WriteLine("Please enter low number");
			while (true)
			{
				string userInput = Console.ReadLine();
				bool t = int.TryParse(userInput, out newLow);
				if (t && newLow > 0)
				{
					return newLow;
				}
				else
				{
					Console.WriteLine("Invalid input, please re-enter new positive number");
				}
			}
		}

		public static int GetHighNumber(int lowNum)
		{
			int newHigh;
			Console.WriteLine("Please enter high number");
			while (true)
			{
				string userInput = Console.ReadLine();
				bool t = int.TryParse(userInput, out newHigh);
				if (t && newHigh > lowNum)
				{
					return newHigh;
				}
				else
				{
					Console.WriteLine($"Invalid input, please re-enter number greater than {lowNum}");
				}
			}
		}

		public static bool IsPrime(int num)
        {
			if (num <= 1)
            {
				return false;
            }
			for (int i = 2; i <= Math.Sqrt(num); i++)
            {
				if (num % i == 0)
                {
					return false;
                }
            }
			return true;
        }
	}
}
