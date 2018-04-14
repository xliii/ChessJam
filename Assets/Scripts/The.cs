using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The
{
	public static Piece selectedPiece;

	private static Board board;

	public static Board Board
	{
		get
		{
			if (board == null)
			{
				board = Object.FindObjectOfType<Board>();
				if (board == null)
				{
					Debug.LogError("Could not find Board");
				}
			}

			return board;
		}
		set
		{
			board = value;			
		}
	}

	public static Config config;
}
