using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TodoListWidget : IUpdaterBase
{
    private bool visible;
    [SerializeField] private Toggle visibilityToggle;
    [HideInInspector] public TodoListScript todoListScript;
    public TextMeshProUGUI titleField;
    
    public void ToggleVisibility(bool on)
    {
        if (on) { todoListScript.MakeVisible(); }
        else { todoListScript.MakeInvisible(); }
    }
    public void Configure(string title, bool isVisible)
    {
        visible = isVisible;
        titleField.text = title;
    }
    
    public override void SharedUpdate()
    {
        visible = todoListScript.visible;
        visibilityToggle.isOn = visible;
    }
    
    public void DeleteTodoList()
    {
        Destroy(todoListScript.gameObject);
        Destroy(this.gameObject);
    }
}
