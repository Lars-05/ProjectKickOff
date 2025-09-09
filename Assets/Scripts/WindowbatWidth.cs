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

        Vector3 v3 = Input.mousePosition;
        v3.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z);
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(v3);
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
            Vector3 v3 = Input.mousePosition;
            v3.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z); 
            this.transform.position = Camera.main.ScreenToWorldPoint(v3) + offset;
        }
    }
}