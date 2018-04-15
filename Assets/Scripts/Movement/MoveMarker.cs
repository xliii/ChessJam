using UnityEngine;

public class MoveMarker : MonoBehaviour {

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public Vector2Int Position
    {
        get
        {
            return new Vector2Int((int) transform.position.x, (int) transform.position.z);
        }
    }
}
