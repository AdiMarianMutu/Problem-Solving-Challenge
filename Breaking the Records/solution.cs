static int[] breakingRecords(int[] scores) {
  int[] maxMinTracking = new int[2];

  int minScore = scores[0];
  int maxScore = scores[0];

  for (int i = 0; i < scores.Length; i++) {
    if (scores[i] > maxScore) {
      maxScore = scores[i];

      maxMinTracking[0]++;
    } else if (scores[i] < minScore) {
      minScore = scores[i];

      maxMinTracking[1]++;
    }
  }

  return maxMinTracking;
}
