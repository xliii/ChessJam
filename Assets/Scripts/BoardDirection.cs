using System;
using UnityEngine;

public enum BoardDirection {
	NORTH,
	SOUTH,
	EAST,
	WEST
}

public static class BoardDirectionExtensions
{
	public static Vector2Int value(this BoardDirection direction)
	{
		switch (direction)
		{
			case BoardDirection.NORTH:
				return Direction.N;
			case BoardDirection.SOUTH:
				return Direction.S;
			case BoardDirection.EAST:
				return Direction.E;
			case BoardDirection.WEST:
				return Direction.W;
			default:
				throw new Exception("Unknown board direction: " + direction);	
		}
	}
}
