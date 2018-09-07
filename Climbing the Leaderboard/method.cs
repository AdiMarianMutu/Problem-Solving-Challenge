static int[] climbingLeaderboard(int[] scores, int[] alice) {
    int[] sBoard        = scores.Distinct().ToArray();
    int[] aScores       = alice;
    int[] aRanks        = new int[aScores.Length];
    int   sBoardLastPos = 0;
        
    // We can already set the first value of 'aliceRanks' as worst score
    aRanks[0] = sBoard.Length + 1;
        
    for (int i = aScores.Length - 1; i >= 0; i--) {
        for (int j = sBoardLastPos; j < sBoard.Length; j++) {
            if (aScores[i] >= sBoard[j]) {
                aRanks[i] = j + 1;
                sBoardLastPos = j;
                break;
            }
        }
    }
        
    return aRanks;
}
