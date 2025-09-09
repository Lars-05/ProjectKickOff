using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowbatWidth : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,
    IPointerUpHandler
{
    bool holdWindow = false; 
    Vector2 mousePosition;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        mousePosition = (Vector2)Input.mousePosition;
        holdWindow = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        holdWindow = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("I LOVE WOMAN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
    
    void Update()
    {
        
        if (holdWindow)
        {
            
            this.transform.position = new Vector2(-Input.mousePosition.x, Input.mousePosition.y);

        }
    }

    
}

        

