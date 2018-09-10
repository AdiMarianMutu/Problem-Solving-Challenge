public class Chessboard {
    HashSet<int> Obstacles = new HashSet<int>();
    int          Size;

    public Chessboard(int[][] obstacles, int size) {
        this.Size      = size;
        CalculateObstaclePosition(obstacles);
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

    private void CalculateObstaclePosition(int[][] obst) {
        for (int i = 0; i < obst.Length; i++)
            Obstacles.Add(CalculatePosition(obst[i][0], obst[i][1]));
    }

    public bool ObstacleExists(int r, int c) {
        if (Obstacles.Count == 0)
            return false;

        return Obstacles.Contains(CalculatePosition(r, c));
    }
}

static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) {
    Chessboard board = new Chessboard(obstacles, n);
            
    bool qN_Dir  = true;
    bool qNW_Dir = true;
    bool qNE_Dir = true;
    bool qS_Dir  = true;
    bool qSW_Dir = true;
    bool qSE_Dir = true;
    bool qE_Dir  = true;
    bool qW_Dir  = true;
    
    for (int i = 1; i <= n; i++) {
        // If the queen can't move anymore we can break the loop
        if (!qN_Dir && !qNW_Dir && !qNE_Dir && !qS_Dir && !qSW_Dir && !qSE_Dir && !qE_Dir && !qW_Dir)
            break;

        // North
        if (qN_Dir) {
            if ((r_q + i) != n + 1) {
                if (!board.ObstacleExists(r_q + i, c_q))
                    qAttacks++;
                else
                    qN_Dir = false;
            } else
                qN_Dir = false;
         }
         // Northeast
         if (qNE_Dir) {
            if (((r_q + i) != n + 1) && ((c_q + i) != n + 1)) {
                if (!board.ObstacleExists(r_q + i, c_q + i))
                    qAttacks++;
                else
                    qNE_Dir = false;
            } else
                qNE_Dir = false;
         }
         // East
         if (qE_Dir) {
            if ((c_q + i) != n + 1) {
                if (!board.ObstacleExists(r_q, c_q + i))
                    qAttacks++;
                else
                    qE_Dir = false;
            } else
                qE_Dir = false;
         }
         // Southeast
         if (qSE_Dir) {
            if (((r_q - i) != 0) && ((c_q + i) != n + 1)) {
                if (!board.ObstacleExists(r_q - i, c_q + i))
                    qAttacks++;
                else
                    qSE_Dir = false;
            } else
                qSE_Dir = false;
         }
         // South
         if (qS_Dir) {
            if ((r_q - i) != 0) {
                if (!board.ObstacleExists(r_q - i, c_q))
                    qAttacks++;
                else
                    qS_Dir = false;
            } else
                qS_Dir = false;
         }
         // Southwest
         if (qSW_Dir) {
            if (((r_q - i) != 0) && ((c_q - i) != 0)) {
                if (!board.ObstacleExists(r_q - i, c_q - i))
                    qAttacks++;
                else
                    qSW_Dir = false;
            } else
                        qSW_Dir = false;
         }
         // West
         if (qW_Dir) {
            if ((c_q - i) != 0) {
                if (!board.ObstacleExists(r_q, c_q - i))
                    qAttacks++;
                else
                    qW_Dir = false;
            } else
                qW_Dir = false;
         }
         // Northwest
         if (qNW_Dir) {
            if (((r_q + i) != n + 1) && ((c_q - i) != 0)) {
                if (!board.ObstacleExists(r_q + i, c_q - i))
                    qAttacks++;
                else
                    qNW_Dir = false;
            } else
                qNW_Dir = false;
         }
    }

    return qAttacks;
}
