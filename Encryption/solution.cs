static string encryption(string s) {
    s = s.Replace(" ", "");

    string sEn  = "";
    int    sLen = s.Length;
    double sqrt = Math.Sqrt(sLen);
    int    r    = Convert.ToInt32(Math.Floor(sqrt));
    int    c;

    c = r >= sqrt ? r : r + 1;

    for (int i = 0; i < c; i++) {
        for (int j = i; j < sLen; j += c)
            sEn += s[j];
        sEn += " ";
    }

    return sEn;
}
