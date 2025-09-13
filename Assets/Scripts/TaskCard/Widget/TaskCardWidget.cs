using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskCardWidget : IUpdaterBase
{
    [SerializeField] public TextMeshProUGUI titleField;
    [SerializeField] private Toggle visibilityToggle;
    [HideInInspector] public string title;
    [HideInInspector] public bool visible;
    [HideInInspector] public TaskCardScript taskCardScript;

    public override void SharedUpdate()
    {
	    visible = taskCardScript.visible;
        visibilityToggle.isOn = visible;
    }
    
    public void ToggleVisibility(bool on)
    {
        if (on) { taskCardScript.MakeVisible(); }
        else { taskCardScript.MakeInvisible(); }
    }
    
    public void DeleteTaskCardAndWidget()
    {
        Destroy(taskCardScript.gameObject);
        Destroy(this.gameObject);
      
    }
}
    
    

