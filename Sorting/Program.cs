using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Sorting {
	class Program {

		private static List<long>[] lists = new List<long>[4];

		static void Main(string[] args) {
			InitializeLists();
			Console.Write("Enter the number of elements: ");
			int n = int.Parse(Console.ReadLine());
			for (int i = 0; i < 20; i++) {
				ExecuteTest(n);
			}
			PrintResults();
		}

		private static void InitializeLists() {
			for (int i = 0; i < lists.Length; i++) {
				lists[i] = new List<long>();
			}
		}

		private static void ExecuteTest(int n) {
			Stopwatch stopwatch;
			int[] rands = Algorithms.GenerateNumbers(n);
			int[] cache = (int[])rands.Clone();
			int listIndex = 0;
			PrintArr(rands);

			Console.WriteLine("Sorting with bubble sort...");
			stopwatch = Stopwatch.StartNew();
			Algorithms.BubbleSort(ref rands);
			stopwatch.Stop();
			lists[listIndex++].Add(stopwatch.ElapsedMilliseconds);
			PrintArr(rands);

			rands = (int[])cache.Clone();

			Console.WriteLine("Sorting with insertion sort...");
			stopwatch = Stopwatch.StartNew();
			Algorithms.InsertionSort(ref rands);
			stopwatch.Stop();
			lists[listIndex++].Add(stopwatch.ElapsedMilliseconds);
			PrintArr(rands);

			rands = (int[])cache.Clone();
			Console.WriteLine("Sorting with selection sort...");
			stopwatch = Stopwatch.StartNew();
			Algorithms.SelectionSort(ref rands);
			stopwatch.Stop();
			lists[listIndex++].Add(stopwatch.ElapsedMilliseconds);
			PrintArr(rands);

			rands = (int[])cache.Clone();

			Console.WriteLine("Sorting with merge sort...");
			stopwatch = Stopwatch.StartNew();
			Algorithms.MergeSort(ref rands);
			stopwatch.Stop();
			lists[listIndex++].Add(stopwatch.ElapsedMilliseconds);
			PrintArr(rands);
		}

		private static void PrintResults() {
			string[] names = { "bubble sort", "insertion sort", "selection sort", "merge sort" };
			for (int i = 0; i < lists.Length; i++) {
				var list = lists[i];
				double avg = 0d;
				list.ForEach((x) => {
					avg += (x / 1000d);
				});
				avg /= list.Count;
				Console.WriteLine($"{names[i]} performed with an average of: {avg} seconds!");

			}
		}

		private static void PrintArr(int[] arr) {
			Console.WriteLine(string.Join(",", arr));
		}
	}
}
