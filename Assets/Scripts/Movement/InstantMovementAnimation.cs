using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/Instant", fileName = "Instant Movement")]
public class InstantMovementAnimation : MovementAnimation {
	
	public override IEnumerator Move(MoveMarker moveMarker)
	{
		yield break;
	}
}
