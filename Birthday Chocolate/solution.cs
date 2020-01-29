static int birthday(List<int> s, int d, int m) {
  int cnt = 0;
  
  for (int i = 0; i <= s.Count - m; i++)
  cnt = (s.Skip(i).Take(m)).Sum() == d ? cnt + 1 : cnt;
  
  return cnt;
}
