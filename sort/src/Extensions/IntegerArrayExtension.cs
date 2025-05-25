namespace sort.src.extensions{
	public static class IntegerArrayExtension{

		public static bool IsEqualsSet(this int[] arr1, int[] arr2){
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
		public static int[] GenerateRandomArray(int length){
			Random rd = new Random();
			int[] arr = new int[length];
			for(int i = 0; i < length; i++){
				arr[i] = rd.Next(1200);
			}
			return arr;
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
