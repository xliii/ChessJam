using System.Collections;
using UnityEngine;

public abstract class MovementAnimation : ScriptableObject
{
    public abstract IEnumerator Move(MoveMarker moveMarker);
}
