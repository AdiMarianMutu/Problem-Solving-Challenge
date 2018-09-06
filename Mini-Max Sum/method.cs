// Complete the miniMaxSum function below.
static long GetMinSum(ref int[] arr) {
    int  n   = arr.Length;
    long sum = 0;
        
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (arr[i] < arr[j]) {
                sum += arr[i];
                break;
            }
        }
    }
        
     // If sum is equal to 0 this means that every element in the array is the same number
     if (sum == 0)
         sum += arr[0] * (n - 1);
        
    return sum;
}
static long GetMaxSum(ref int[] arr) {
    int  n   = arr.Length;
    long sum = 0;
        
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (arr[i] > arr[j]) {
                sum += arr[i];
                break;
            }
        }
    }
        
     // If sum is equal to 0 this means that every element in the array is the same number
     if (sum == 0)
         sum += arr[0] * (n - 1);
        
    return sum;
}
    
static void miniMaxSum(int[] arr) {
    Console.WriteLine($"{GetMinSum(ref arr)} {GetMaxSum(ref arr)}");
}
