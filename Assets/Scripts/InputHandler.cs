using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InputHandler : MonoBehaviour
{
	private Camera _camera;
	
	void Start()
	{
		_camera = GetComponent<Camera>();
		Events.RegisterEvent(Events.EventType.LEVEL_VICTORY, LockInput);
		Events.RegisterEvent(Events.EventType.LEVEL_START, UnlockInput);
	}

	private void LockInput()
	{
		movementLock++;
	}

	private void UnlockInput()
	{
		movementLock--;
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
			if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
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
					StartCoroutine(MoveCoroutine(moveMarker));
					return;
				}
				
			}
						
			Deselect();
		}
	}

	IEnumerator MoveCoroutine(MoveMarker moveMarker)
	{
		LockInput();
		The.Board.ClearPiece(The.selectedPiece);
		yield return The.selectedPiece.Move(moveMarker);
		The.Board.RegisterPiece(The.selectedPiece);
		Deselect();
		UnlockInput();
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
