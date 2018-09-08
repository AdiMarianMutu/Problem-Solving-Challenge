static int[] CalculatePosition(int[][] piece, int k) {
    int[] r = new int[piece.Length];
        
    // k = board size
    // x  = row
    // x1 = current row => k - x
    // y  = column
    // Formula below:
    // (((x + y) + (k * x1)) - k) + x1
    for (int i = 0; i < r.Length; i++) {
        int x1 = k - piece[i][0];
        r[i]   = (((piece[i][0] + piece[i][1]) + (k * x1)) - k) + x1;
    }
        
    return r;
}

static int DrawBoard(int n, int k, int[][] pieces) {
    int[]  piece = CalculatePosition(pieces, n);

    for (int i = 1, j = 1; i <= (n*n) + n ; i++) {
        if (i % (n+1) == 0) {
            Console.WriteLine("");
        } else {
            Console.Write(Array.IndexOf(piece, j) != -1 ? 'x' : '#');
                
            j++;
        }
    }
                
    return 0;
}
