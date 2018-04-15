using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Set", menuName = "Config/Piece Set")]
public class PieceSet : ScriptableObject
{
	public Pawn pawn;
	public Knight knight;
	public Bishop bishop;
	public Rook rook;
	public Queen queen;
	public King king;

	private Dictionary<PieceType, Piece> byType;

	private void OnEnable()
	{
		byType = new Dictionary<PieceType, Piece>();
		byType[PieceType.PAWN] = pawn;
		byType[PieceType.KNIGHT] = knight;
		byType[PieceType.BISHOP] = bishop;
		byType[PieceType.ROOK] = rook;
		byType[PieceType.QUEEN] = queen;
		byType[PieceType.KING] = king;
	}

	public Piece GetPiece(PieceType type)
	{
		return byType[type];
	}
}
