public class Chessboard {
    int[] Obstacles;
    int   Size;

    public Chessboard(int[][] obstacles, int size) {
        this.Size      = size;
        this.Obstacles = CalculateObstaclePositionTo1DArray(obstacles);
    }

    private int CalculatePosition(int r, int c) {
        // n = board size
        // r = row
        // x = current row => n - x
        // c = column
        // Formula below:
        // (((r + c) + (n * x)) - n) + x
        int n = Size;
        int x = n - r;
        return (((r + c) + (n * x)) - n) + x;
    }

    private int[] CalculateObstaclePositionTo1DArray(int[][] obst) {
        int[] r = new int[obst.Length];

        for (int i = 0; i < obst.Length; i++)
            r[i] = CalculatePosition(obst[i][0], obst[i][1]);

        return r;
    }

    public bool ObstacleExists(int r, int c) {
        if (Obstacles.Length == 0)
            return false;
                
        int qPos = CalculatePosition(r, c);

        for (int i = 0; i < Obstacles.Length; i++) {
            if (qPos == Obstacles[i])
                return true;
        }

        return false;
    }
}

static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) {
    Chessboard board = new Chessboard(obstacles, n);
            
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
        if (qSouth && (r_q - i) == 0) 
            qSouth = false;
        // Southeast direction
        if (qSoutheast && (r_q - i == 0 || c_q + i == n + 1))
            qSoutheast = false;
        // East direction
        if (qEast && (c_q + i) == n + 1)
            qEast = false;
        // Northeast direction
        if (qNortheast && (r_q + i == n + 1 || c_q + i == n + 1))
            qNortheast = false;
        // North direction
        if (qNorth && (r_q + i) == n + 1)
            qNorth = false;
        // Northwest direction
        if (qNorthwest && (r_q + i == n + 1 || c_q - i == 0))
            qNorthwest = false;
        // West direction
        if (qWest && (c_q - i) == 0)
            qWest = false;
        // Southwest direction
        if (qSouthwest && (r_q - i == 0 || c_q - i == 0))
            qSouthwest = false;

        // Now we can check for the obstacles
        // Verify South way
        if (qSouth)
            if (!board.ObstacleExists(r_q - i, c_q))
                qAttacks++;
            else
                qSouth = false;
        // Verify Southeast way
        if (qSoutheast)
            if (!board.ObstacleExists(r_q - i, c_q + i))
                qAttacks++;
            else
                qSoutheast = false;
        // Verify East way
        if (qEast)
            if (!board.ObstacleExists(r_q, c_q + i))
                qAttacks++;
            else
                qEast = false;
        // Verify Northeast
        if (qNortheast)
            if (!board.ObstacleExists(r_q + i, c_q + i))
                qAttacks++;
            else
                qNortheast = false;
        // Verify North way
        if (qNorth)
            if (!board.ObstacleExists(r_q + i, c_q))
                qAttacks++;
            else
                qNorth = false;
        // Verify Northwest way
        if (qNorthwest)
            if (!board.ObstacleExists(r_q + i, c_q - i))
                qAttacks++;
            else
                qNorthwest = false;
        // Verify West way
        if (qWest)
            if (!board.ObstacleExists(r_q, c_q - i))
                qAttacks++;
            else
                qWest = false;
        // Verify Southwest way
        if (qSouthwest)
            if (!board.ObstacleExists(r_q - i, c_q - i))
                qAttacks++;
            else
                qSouthwest = false;

        // If the queen can't move anymore we break the for loop
        if (!qSouth && !qSoutheast && !qEast && !qNortheast && !qNorth && !qNorthwest && !qWest && !qSouthwest)
            break;
    }

    return qAttacks;
}
