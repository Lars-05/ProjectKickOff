using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeWindow : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,
    IPointerUpHandler
{
    
    
    
    [SerializeField] private GameObject parent;
    bool holdWindow = false; 
    Vector3 prevMousePosition;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        holdWindow = true;

        prevMousePosition = Input.mousePosition;
        prevMousePosition.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z);
        Camera.main.ScreenToWorldPoint(prevMousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        holdWindow = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerExit(PointerEventData eventData)
    {
     
    }
    
    void Update()
    {
        if (holdWindow)
        {
            Vector3 mousePosition= Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z); 
            Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 deltaMousePosition = mousePosition - prevMousePosition;
            float scale = (1 + -deltaMousePosition.x/ 200) + (1 + deltaMousePosition.y / 200) / 100;

            parent.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}