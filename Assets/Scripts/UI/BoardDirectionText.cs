using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[ExecuteInEditMode]
public class BoardDirectionText : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    
    public void Update()
    {
        text.text = The.Board.direction.ToString();
    }
}
