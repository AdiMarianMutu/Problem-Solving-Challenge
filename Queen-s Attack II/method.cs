public class Chessboard {
    int[][] obst;
        
    public Chessboard(int[][] obst) {
        this.obst = obst;
    }
        
    public bool ObstacleExists(int r, int c) {
        if (obst.Length == 0)
            return false;

        // To make the research of the obstacles on the chessboard
        // We start to loop the array from his half
        int n = obst.Length / 2;

        // Sometimes the obstacle can be exactly at half of the array
        // So if this happens and the current queen position is the same as the obstacle
        // We return immediately true without searching the whole array
        if (obst[n][0] == r && obst[n][1] == c)
            return true;

        // Otherwise if the current queen row is above the value picked from the array
        // We search the array starting from his half to his maximum length (to right)
        if (r > obst[n][0]) {
            for (int i = n; i < obst.Length; i++) {
                if (obst[i][0] == r && obst[i][1] == c)
                    return true;
            }
        // Same thing but from his half to 0 (to left)
        } else if (r < obst[n][0]) {
            for (int i = n; i >= 0; i--) {
                if (obst[i][0] == r && obst[i][1] == c)
                    return true;
            }
        // If the current queen row and the current array value are the same
        // We search the array based on the column, using exactly the same logic used for the rows
        } else {
            if (c > obst[n][1]) {
                for (int i = n; i < obst.Length; i++) {
                    if (obst[i][0] == r && obst[i][1] == c)
                        return true;
                }
            } else {
                for (int i = n; i >= 0; i--) {
                    if (obst[i][0] == r && obst[i][1] == c)
                        return true;
                }
            }
        }

        return false;
    }
}
    
static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) {
    Chessboard board = new Chessboard(obstacles.OrderBy(x => x[0]).ToArray());
        
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
    }
        
    return qAttacks;
}
