using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowbatWidth : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,
    IPointerUpHandler
{
    bool holdWindow = false; 
    Vector2 mousePosition;
    Vector3 offset; 
    
    public void OnPointerDown(PointerEventData eventData)
    {
        mousePosition = (Vector2)Input.mousePosition;
        holdWindow = true;
        var v3 = Input.mousePosition;
        v3.z = 1000;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        offset = this.transform.position - v3;
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
            var v3 = Input.mousePosition;
            v3.z = 1000.0f;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            this.transform.position = v3 + offset;
        }
    }

    
}

        

