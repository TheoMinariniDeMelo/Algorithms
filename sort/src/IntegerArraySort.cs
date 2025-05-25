using BenchmarkDotNet.Attributes;
using sort.src.extensions;
using sort.src.exceptions;

namespace sort.src
{
	[MemoryDiagnoser]
	public class IntegerArraySort
	{
		[Params(100, 1000)]
		public int Length { get; set; }

		private int[] OriginalArray { get; set; }
		private int[] InsertionArray { get; set; }
		private int[] QuickArray { get; set; }
		private int[] ExpectedArray { get; set; }

		[GlobalSetup]
		public void Setup()
		{
			OriginalArray = IntegerArrayExtension.GenerateRandomArray(Length);
			ExpectedArray = OriginalArray.OrderBy(x => x).ToArray();

			Console.WriteLine("------------------ Default Array: ------------------");
			OriginalArray.Print();
			Console.WriteLine("----------------------------------------------------");

		}

		[Benchmark]
		public void InsertionSort()
		{
			InsertionArray = CloneArray(OriginalArray);
			PerformInsertionSort(InsertionArray);
		}

		[Benchmark]
		public void QuickSort()
		{
			QuickArray = CloneArray(OriginalArray);
			PerformQuickSort(QuickArray, 0, QuickArray.Length - 1);
		}

		//[GlobalCleanup]
		public void Cleanup()
		{
			ValidateAndPrint("Insertion", InsertionArray);
			ValidateAndPrint("Quick", QuickArray);
		}

		// ---------- Métodos auxiliares ----------

		private static int[] CloneArray(int[] source)
		{
			var clone = new int[source.Length];
			source.CopyTo(clone, 0);
			return clone;
		}

		private void ValidateAndPrint(string name, int[] result)
		{
			Console.WriteLine($"------------------ {name} Sorted Array: ------------------");
			result.Print();

			if (!ExpectedArray.IsEqualsSet(result))
			{
				Console.WriteLine($"{name} sort produced incorrect result:");
				Console.Write("Esperado: ");
				ExpectedArray.Print();
				Console.Write("Obtido: ");
				result.Print();
				throw new DifferentSetsExceptions(ExpectedArray, result);
			}
		}

		private static void PerformInsertionSort(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				int pivot = array[i];
				int j = i - 1;

				while (j >= 0 && array[j] > pivot)
				{
					array[j + 1] = array[j];
					j--;
				}

				array[j + 1] = pivot;
			}
		}

		private static void PerformQuickSort(int[] array, int low, int high)
		{
			if (low >= high) return;

			int pivot = array[(low + high) / 2];
			int i = low, j = high;

			while (i <= j)
			{
				while (array[i] < pivot) i++;
				while (array[j] > pivot) j--;

				if (i <= j)
				{
					(array[i], array[j]) = (array[j], array[i]);
					i++;
					j--;
				}
			}

			if (low < j) PerformQuickSort(array, low, j);
			if (i < high) PerformQuickSort(array, i, high);
		}
	}
}

