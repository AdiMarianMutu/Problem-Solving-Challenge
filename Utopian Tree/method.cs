static int utopianTree(int n) {
    // Constraints
    if (n == 0 || (n < 0 || n > 60))
        return 1;
        
    int h = 1;

    for (int i = 0; i < n; i++) {
        if ((i % 2) == 0)
            h *= 2;
        else 
            h++;
    }
        
    return h;
}
