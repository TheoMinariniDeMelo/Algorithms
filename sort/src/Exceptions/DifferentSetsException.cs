namespace sort.src.exceptions{
	public class DifferentSetsExceptions : Exception{
		public DifferentSetsExceptions(int[] arr1, int[] arr2) : base($"The default [{string.Join(", ", arr1)}] set and [{string.Join(", ", arr2)}] are not equal"){

		}
	}
}
