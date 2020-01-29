static int[] circularArrayRotation(int[] a, int k, int[] queries) {
    int   aLen   = a.Length;
    int[] output = new int[queries.Length];
          k     %= aLen;
    int[] tmp    = new int[k];

    Array.Copy(a, aLen - k, tmp, 0, k);
    Array.Copy(a, 0, a, k, aLen - k);
    Array.Copy(tmp, a, k);

    for (int i = 0; i < queries.Length; i++)
        output[i] = a[queries[i]];

    return output;
}
