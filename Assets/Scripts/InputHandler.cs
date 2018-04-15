using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InputHandler : MonoBehaviour
{
	private Camera camera;
	
	void Start()
	{
		camera = GetComponent<Camera>();
		Events.RegisterEvent(Events.EventType.WIN, LockInput);
	}

	private void LockInput()
	{
		movementLock++;
	}

	private int movementLock;

	public bool MovementLocked
	{
		get { return movementLock > 0; }
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (MovementLocked) return;
		
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
			{
				var piece = hit.transform.GetComponent<Piece>();
				if (piece != null)
				{
					Deselect();
					The.selectedPiece = piece;
					piece.Select();
					return;					
				}

				var moveMarker = hit.transform.GetComponent<MoveMarker>();
				if (moveMarker != null)
				{
					Debug.Log("Move " + The.selectedPiece + " to " + moveMarker.Position);
					StartCoroutine(MoveCoroutine(moveMarker));
					return;
				}
				
			}
						
			Deselect();
		}
	}

	IEnumerator MoveCoroutine(MoveMarker moveMarker)
	{
		movementLock++;
		The.Board.ClearPiece(The.selectedPiece);
		yield return The.selectedPiece.Move(moveMarker);
		The.Board.RegisterPiece(The.selectedPiece);
		Deselect();
		movementLock--;
	}

	void Deselect()
	{
		if (The.selectedPiece != null)
		{
			The.selectedPiece.Deselect();
			The.selectedPiece = null;
		}		
	}
}
