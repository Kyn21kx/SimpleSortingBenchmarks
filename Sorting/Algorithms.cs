using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting {
	public static class Algorithms {
		
		public static int[] GenerateNumbers(int max) {
			Random r = new Random();
			int[] result = new int[max];
			for (int i = 0; i < max; i++) {
				result[i] = r.Next(0, max);
			}
			return result;
		}
		
		public static void BubbleSort(ref int[] arr) {
			bool sorted = true;
			while (true) {
				for (int i = 0; i < arr.Length; i++) {
					if (i >= arr.Length - 1) break;
					if (arr[i] > arr[i + 1]) {
						Swap(ref arr[i], ref arr[i + 1]);
						sorted = false;
					}
				}
				if (sorted) return;
				sorted = true;
			}
		}

		public static void InsertionSort(ref int[] arr) {
			for (int i = 1; i < arr.Length; i++) {
				InsertBackIndex(ref arr, i);
			}
		}

		public static void SelectionSort(ref int[] arr) {
			for (int i = 0; i < arr.Length; i++) {
				int minIndex = i;
				for (int j = i + 1; j < arr.Length; j++) {
					if (arr[minIndex] > arr[j]) {
						minIndex = j;
						Swap(ref arr[i], ref arr[minIndex]);
					}
				}
			}
		}

		public static void MergeSort(ref int[] arr) {
			if (arr.Length <= 1) return;
			int midPoint = arr.Length / 2;
			int offset = arr.Length % 2 == 0 ? 0 : 1;
			int[] leftSide = new int[midPoint];
			int[] rightSide = new int[midPoint + offset];
			Array.Copy(arr, 0, leftSide, 0, midPoint);
			Array.Copy(arr, midPoint, rightSide, 0, midPoint + offset);
			
			MergeSort(ref leftSide);
			MergeSort(ref rightSide);

			arr = Merge(ref leftSide, ref rightSide);
		}

		public static int[] Merge(ref int[] left, ref int[] right) {
			int resultLength = right.Length + left.Length;
			int[] result = new int[resultLength];
			//
			int indexLeft = 0, indexRight = 0, indexResult = 0;
			//while either array still has an element
			while (indexLeft < left.Length || indexRight < right.Length) {
				//if both arrays have elements  
				if (indexLeft < left.Length && indexRight < right.Length) {
					//If item on left array is less than item on right array, add that item to the result array 
					if (left[indexLeft] <= right[indexRight]) {
						result[indexResult] = left[indexLeft];
						indexLeft++;
						indexResult++;
					}
					// else the item in the right array wll be added to the results array
					else {
						result[indexResult] = right[indexRight];
						indexRight++;
						indexResult++;
					}
				}
				//if only the left array still has elements, add all its items to the results array
				else if (indexLeft < left.Length) {
					result[indexResult] = left[indexLeft];
					indexLeft++;
					indexResult++;
				}
				//if only the right array still has elements, add all its items to the results array
				else if (indexRight < right.Length) {
					result[indexResult] = right[indexRight];
					indexRight++;
					indexResult++;
				}
			}
			return result;
		}

		private static void InsertBackIndex(ref int[] arr, int index) {
			for (int i = index; i >= 0; i--) {
				if (i == 0) continue;
				if (arr[i] >= arr[i - 1]) return;
				Swap(ref arr[i], ref arr[i - 1]);
			}
		}

		private static void Swap(ref int a, ref int b) {
			int temp = a;
			a = b;
			b = temp;
		}

	}
}
