static int minimumSwaps(int[] arr) {
    int swaps = 0;
    int aLen = arr.Length;
        
    int x, y = 0;
    for (int i = 0; i < aLen; i++) {
        if (arr[i] != i + 1) {
            x = arr[i];
            y = arr[x - 1];
                
            arr[i] = y;
            arr[x - 1] = x;
                
            swaps++;
            i--;
        }
    }
        
    return swaps;
}
