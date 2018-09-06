static int GetTallestCandle(ref int[] arr) {
    int tallestCandle = 0;
        
    for (int i = 0; i < arr.Length; i++) {
        if (arr[i] > tallestCandle)
            tallestCandle = arr[i];
    }
        
    return tallestCandle;
}
    
static int birthdayCakeCandles(int[] ar) {
    int candleCount   = 0;
    int tallestCandle = GetTallestCandle(ref ar);
        
    for (int i = 0; i < ar.Length; i++) {
        if (ar[i] == tallestCandle)
            candleCount++;
    }
    
    return candleCount;
}
