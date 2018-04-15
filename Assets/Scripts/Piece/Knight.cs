using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knight : Piece
{

	private static List<Vector2Int> DIRECTIONS = new List<Vector2Int>
	{
		new Vector2Int(-2, +1),
		new Vector2Int(+2, +1),
		new Vector2Int(-2, -1),
		new Vector2Int(+2, -1),
		new Vector2Int(+1, -2),
		new Vector2Int(+1, +2),
		new Vector2Int(-1, -2),
		new Vector2Int(-1, +2)
	};
	
	protected override List<Vector2Int> Moves()
	{
		return DIRECTIONS.Select(move => move + Position).Where(pos =>
		{
			if (The.Board.OutOfRange(pos)) return false;
			return The.Board.Empty(pos);
		}).ToList();
	}

	public override PieceType Type()
	{
		return PieceType.KNIGHT;
	}
}
