using System.Collections.Generic;
using UnityEngine;

public static class Direction {

	public static Vector2Int N  = Vector2Int.up;
	public static Vector2Int NE = Vector2Int.one;
	public static Vector2Int E  = Vector2Int.right;
	public static Vector2Int SE = new Vector2Int(1, -1);
	public static Vector2Int S  = Vector2Int.down;
	public static Vector2Int SW = Vector2Int.one * -1;
	public static Vector2Int W  = Vector2Int.left;
	public static Vector2Int NW = new Vector2Int(-1, 1);

	public static readonly List<Vector2Int> Horizontal = new List<Vector2Int> { W, E };
	
	public static readonly List<Vector2Int> Vertical = new List<Vector2Int> { N, S };

	public static readonly List<Vector2Int> Diagonal = new List<Vector2Int> { NE, SE, NW, SW };

	public static List<Vector2Int> NonDiagonal
	{
		get
		{
			List<Vector2Int> nonDiagonal = new List<Vector2Int>();
			nonDiagonal.AddRange(Horizontal);
			nonDiagonal.AddRange(Vertical);
			return nonDiagonal;
		}
	}

	public static List<Vector2Int> All
	{
		get
		{
			List<Vector2Int> all = new List<Vector2Int>();
			all.AddRange(Horizontal);
			all.AddRange(Vertical);
			all.AddRange(Diagonal);
			return all;
		}
	}
}
