using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Piece))]
public class PieceInputHandler : MonoBehaviour {
	
	void OnMouseDown()
	{
		//The.selectedPiece = GetComponent<Piece>();
		//Debug.Log(The.selectedPiece);
	}
}
