static int sockMerchant(int n, int[] ar) {
    List < int > s     = new List < int > ();
    int          pairs = 0;

    for (int i = 0; i < ar.Length; i++) {
        if (!s.Contains(ar[i]))
            s.Add(ar[i]);
        else {
            pairs++;

            s.Remove(ar[i]);
        }
    }

    return pairs;
}
