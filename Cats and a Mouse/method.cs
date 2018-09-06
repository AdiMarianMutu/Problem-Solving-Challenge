static string catAndMouse(int x, int y, int z) {
    if (Math.Abs((z - x)) > Math.Abs((z - y)))
        return "Cat B";
    else if (Math.Abs((z - x)) < Math.Abs((z - y)))
        return "Cat A";
    else
        return "Mouse C";
        
    return null;
}
