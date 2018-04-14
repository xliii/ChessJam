using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    [HideInInspector] 
    public bool moved = false;
	
    protected override List<Vector2Int> Moves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        var direction = The.Board.direction.value();

        var pos = Position + direction;
        if (!The.Board.OutOfRange(pos) && The.Board.Empty(pos))
        {
            moves.Add(pos);
        }

        if (!moved)
        {
            pos = pos + direction;
            if (!The.Board.OutOfRange(pos) && The.Board.Empty(pos))
            {
                moves.Add(pos);
            }
        }        
        return moves;
    }

    public override IEnumerator Move(MoveMarker marker)
    {
        yield return base.Move(marker);
        moved = true;
    }
}