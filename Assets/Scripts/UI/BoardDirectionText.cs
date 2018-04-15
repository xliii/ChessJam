using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[ExecuteInEditMode]
public class BoardDirectionText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    public void Update()
    {
        text.text = The.Board.Direction.ToString();
    }
}
