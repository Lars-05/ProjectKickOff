using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Button button;
    bool Checked = false;
    
    Image image;

    private void Awake()
    {
        image = button.GetComponent<Image>();
    }

    public void ButtonPressed()
    {
        
        if (!Checked)
        {
            image.sprite = sprites[1];
            Checked = true;
        }
        else
        {
            image.sprite = sprites[0];
            Checked = false;
        }
    }
}
