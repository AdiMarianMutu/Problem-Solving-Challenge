static int[] countSubstrings(string s, int[][] queries) {
    // Gets the 'string' length and the number of queries
    int strLen    = s.Length, qLen = queries.Length;
    // Used to store the number of different substrings
    int[] ssCount = new int[qLen];
    
    for (int q = 0; q < qLen; q++) {
        // Retrieve the substring in the inclusive range between 'left' and 'right'
        string       subStr    = s.Substring(queries[q][0], (queries[q][1] - queries[q][0]) + 1);
        int          _ssLen    = subStr.Length;
        // Used to store the previously found substrings
        List<string> _ssPrev   = new List<string>();
        
        for (int i = 1; i <= _ssLen; i++) {
            for (int j = 0; j <= _ssLen - i; j++) {
                // Retrieves every permutation possible
                string _tmp = subStr.Substring(j, i);
                
                // If the current permutation is a new substring, increments the count by one
                if (!_ssPrev.Contains(_tmp)) {
                    _ssPrev.Add(_tmp);
                    ssCount[q]++;
                }
            }
        }
    }

    return ssCount;
}
