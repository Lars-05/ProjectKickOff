using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TodoListTask : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleField;
    [SerializeField] private Toggle visibilityToggle;
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
            Destroy(this.gameObject);
        }
        
}
