using System.Collections;
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

    public override IEnumerator Move(MoveMarker marker)
    {
        yield return base.Move(marker);
        if (marker.Position == The.Board.Finish)
        {
            Events.TriggerEvent(Events.EventType.WIN);    
        }
    }
}
