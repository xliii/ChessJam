using UnityEngine;

public class MoveMarker : MonoBehaviour {

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public string Position
    {
        get
        {
            var pos = transform.position;
            return string.Format("{0}:{1}", (int) pos.x, (int) pos.z);
        }
    }
}
