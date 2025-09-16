using TMPro;
using UnityEngine;

public class TodoListTaskScript : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI titleField;
    [HideInInspector] public bool crossedOut = false;
    public void ToggleCrossout()
    {
        if (crossedOut) { crossedOut = false;
            titleField.fontStyle = FontStyles.Normal;
        } 
        else {crossedOut = true;
            titleField.fontStyle = FontStyles.Strikethrough;
        }
    }

    public void DeleteTask()
    {
        this.gameObject.SetActive(false);
    }
}
