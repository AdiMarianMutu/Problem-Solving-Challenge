static void staircase(int n) {
    for (int i = 1; i < n + 1; i++)
        Console.WriteLine((string.Concat(Enumerable.Repeat('#', i))).PadLeft(n));
}
