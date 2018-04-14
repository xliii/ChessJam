using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class King : Piece {
    
    protected override List<Vector2Int> Moves()
    {
        return Direction.All.Select(move => move + Position).Where(pos =>
        {
            if (The.Board.OutOfRange(pos)) return false;
            return The.Board.Empty(pos);
        }).ToList();
    }
}
