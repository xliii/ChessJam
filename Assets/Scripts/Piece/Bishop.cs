using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece {

	protected override List<Vector2Int> Moves()
	{
		List<Vector2Int> moves = new List<Vector2Int>();
		foreach (Vector2Int direction in Direction.Diagonal)
		{
			var pos = Position + direction;
			while (!The.Board.OutOfRange(pos) && The.Board.Empty(pos))
			{
				moves.Add(pos);
				pos = pos + direction;
			}
		}

		return moves;
	}
}
