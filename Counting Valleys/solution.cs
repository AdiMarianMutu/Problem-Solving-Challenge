static int countingValleys(int n, string s) {
  int cntV = 0;
  int _lvl = 0;

  for (int i = 0; i < s.Length; i++) {
    _lvl = s[i] == 'U' ? _lvl + 1 : _lvl - 1;
    
    if (_lvl == 0 && s[i] == 'U')
      cntV++;
  }

  return cntV;
}
