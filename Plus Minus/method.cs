static void plusMinus(int[] arr) {
    int[]  r = new int[3];
    double n = arr.Length;
        
    foreach (var i in arr) {
        if (i > 0)
            r[0]++; // Positive
        else if (i != 0)
            r[1]++; // Negative
        else
            r[2]++; // Zero
    }
        
    for (int i = 0; i < 3; i++)
        Console.WriteLine("{0:N6}", r[i] / n);
}
