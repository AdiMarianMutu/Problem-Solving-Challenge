static int diagonalDifference(int[][] arr) {
    int leftDiag  = 0;
    int rightDiag = 0;
        
    for (int i = 0; i < arr.Length; i++) {
        leftDiag  += arr[i][i];
        rightDiag += arr[i][(arr.Length - 1) - i];
    }
        
    return Math.Abs(leftDiag - rightDiag);
}
