using TMPro;
using UnityEngine;

public class TodoListTask : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleField;
    private bool crossedOut = false;
    public void ToggleCrossout()
    {
        if (crossedOut) { crossedOut = false;
            titleField.fontStyle = FontStyles.Normal;
        } 
        else {crossedOut = true;
            titleField.fontStyle = FontStyles.Strikethrough;
        }
    }
}
