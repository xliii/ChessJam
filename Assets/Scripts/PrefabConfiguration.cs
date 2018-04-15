using UnityEngine;

[CreateAssetMenu(fileName = "PrefabConfig", menuName = "Config/Prefab")]
public class PrefabConfiguration : ScriptableObject
{
    public MoveMarker moveMarker;

    public GameObject whiteSquare;

    public GameObject blackSquare;

    public GameObject finishSquare;
}
