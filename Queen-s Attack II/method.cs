static int CalculatePosition(int x, int y, int k) {
    // k  = board size
    // x  = row
    // x1 = current row => k - x
    // y  = column
    // Formula below:
    // (((x + y) + (k * x1)) - k) + x1
    int x1 = k - x;
    return (((x + y) + (k * x1)) - k) + x1;
}
    
static int[] GetObstaclePosition(int[][] piece, int k) {
    int[] r = new int[piece.Length];

    for (int i = 0; i < r.Length; i++)
        r[i] = CalculatePosition(piece[i][0], piece[i][1], k);
        
    return r.OrderBy(i => i).ToArray();
}
    
static bool ObstacleExists(int[] obst, int pos) {
    if (obst.Length == 0)
        return false;
        
    int n = obst.Length / 2;
        
    if (pos == obst[n])
        return true;
                
    if (pos > obst[n]) {
        for (int i = n; i < obst.Length; i++) {
            if (obst[i] == pos)
                return true;
        }
    } else {
        for (int i = n; i > 0; i--) {
            if (obst[i] == pos)
                return true;
        }
    }
        
    return false;
}
    
static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) {
    int[] obsPos    = GetObstaclePosition(obstacles, n);
        
    int  qRow       = r_q;
    int  qColumn    = c_q;
    int  qAttacks   = 0;
        
    bool qSouth     = true;
    bool qSoutheast = true;
    bool qEast      = true;
    bool qNortheast = true;
    bool qNorth     = true;
    bool qNorthwest = true;
    bool qWest      = true;
    bool qSouthwest = true;
        
    for (int i = 1; i <= n; i++) {
        // First we check if the queen isn't on the board edges
        // South direction
        if (qSouth && (qRow - i) == 0)
            qSouth = false;
        // Southeast direction
        if (qSoutheast && (qRow - i == 0 || qColumn + i == n + 1))
            qSoutheast = false;
        // East direction
        if (qEast && (qColumn + i) == n + 1)
            qEast = false;
        // Northeast direction
        if (qNortheast && (qRow + i == n + 1 || qColumn + i == n + 1))
            qNortheast = false;
        // North direction
        if (qNorth && (qRow + i) == n + 1)
            qNorth = false;
        // Northwest direction
        if (qNorthwest && (qRow + i == n + 1 || qColumn - i == 0))
            qNorthwest = false;
        // West direction
        if (qWest && (qColumn - i) == 0)
            qWest = false;
        // Southwest direction
        if (qSouthwest && (qRow - i == 0 || qColumn - i == 0))
            qSouthwest = false;
            
        // Now we can check for the obstacles
        // Verify South way
        if (qSouth)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow - i, qColumn, n)))
                qAttacks++;
            else
                qSouth = false;
        // Verify Southeast way
        if (qSoutheast)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow - i, qColumn + i, n)))
                qAttacks++;
            else
                qSoutheast = false;
        // Verify East way
        if (qEast)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow, qColumn + i, n)))
                qAttacks++;
            else
                qEast = false;
        // Verify Northeast
        if (qNortheast)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow + i, qColumn + i, n)))
                qAttacks++;
            else
                qNortheast = false;
        // Verify North way
        if (qNorth)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow + i, qColumn, n)))
                qAttacks++;
            else
                qNorth = false;
        // Verify Northwest way
        if (qNorthwest)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow + i, qColumn - i, n)))
                qAttacks++;
            else
                qNorthwest = false;
        // Verify West way
        if (qWest)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow, qColumn - i, n)))
                qAttacks++;
            else
                qWest = false;
        // Verify Southwest way
        if (qSouthwest)
            if (!ObstacleExists(obsPos, CalculatePosition(qRow - i, qColumn - i, n)))
                qAttacks++;
            else
                qSouthwest = false;
    }
        
    return qAttacks;
}
