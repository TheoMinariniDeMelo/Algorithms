using System.Diagnostics;
namespace sort.src.extensions{
	public static class IntegerArrayExtension{
		public static void QuickSort(this int[] arr){
			QuickSort(arr, 0, arr.Length - 1);
		}
		public static void QuickSort(int[] arr, int low, int high){
			int pivo = arr[low];

			(int i, int j) = (low, high);	

			while(i <= j){
				while(arr[i] < pivo) i++;
				while(arr[j] > pivo) j--;

				if(i <= j){
					(arr[i], arr[j]) = (arr[j], arr[i]);
					i++;
					j--;
				};

			}
			if(low < j) QuickSort(arr, low, j);
			if(i < high) QuickSort(arr, i, high);

		}
		public static bool IsEqualsSet(int[] arr1, int[] arr2){
			if(arr1.Length != arr2.Length) return false;
			int size = arr1.Length;
			Dictionary<int, int> frequenceTax1 = new();
			Dictionary<int, int> frequenceTax2 = new();

			for(int i = 0; i < size; i++){
				int e1 = arr1[i];
				int e2 = arr2[i];

				frequenceTax1[e1] = frequenceTax1.GetValueOrDefault(e1) + 1;
				frequenceTax2[e2] = frequenceTax2.GetValueOrDefault(e2) + 1;
			};
			foreach(KeyValuePair<int, int> kvp in frequenceTax1){
				if(frequenceTax2.GetValueOrDefault(kvp.Key) != kvp.Value) return false; 	
			}
			return true;
		}
		public static int[] GenerateRandomArray(int amount){
			Random rd = new Random();
			int[] arr = new int[amount];
			for(int i = 0; i < amount; i++){
				arr[i] = rd.Next(1200);
			}
			return arr;
		}

		public static void InsertionSort(this int[] arr){
			var sw = new Stopwatch();

			sw.Start();

			for(int i = 0; i < arr.Length; i++){
				int pivo = arr[i];
				int j = i - 1;
				while(j >= 0 && pivo < arr[j]){
					(arr[j], arr[j + 1]) = (arr[j+1], arr[j]);
					j--;
				}
				arr[j + 1] = pivo;
			}
			sw.Stop();

			// Output total time elapsed on the Stopwatch.
			Console.WriteLine($"Elapsed time insertion Sort: {sw.ElapsedMilliseconds} ms");

		}
		public static bool IsSorted(this int[] arr){
			for(int i = 1; i < arr.Length; i++){ 
				if(arr[i - 1] > arr[i]){
					return false;
				}
			}
			return true;
		}
		public static void Print(this int[] arr){
			Console.WriteLine("[{0}]", string.Join(", ", arr));
		}
	}
}
