static string kangaroo(int x1, int v1, int x2, int v2) {
    if ((x1 < x2) && (v1 < v2))
        return "NO";
    else {
        int k0Position = x1;
        int k1Position = x2;
        int maxJumps   = (v1 + v2) + x2 - x1;
            
        for (int i = 0; i < maxJumps; i++) {
            if (k0Position != k1Position) {
                k0Position += v1;
                k1Position += v2;
            } else
                return "YES";
        }
            
        return "NO";
    }
        
    return null;
}
