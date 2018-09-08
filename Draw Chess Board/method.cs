static int[] CalculatePosition(int[][] piece, int k) {
    int[] r = new int[piece.Length];
        
    // k = board size
    // x = row
    // y = column
    // Formula below:
    // (((x + y) + (k * x)) - k) + x
    for (int i = 0; i < r.Length; i++) {
        int x = k - piece[i][0];
        r[i]  = (((piece[i][0] + piece[i][1]) + (k * x)) - k) + x;
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
