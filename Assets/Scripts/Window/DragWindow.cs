using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler
{
    bool holdWindow = false; 
    Vector3 offset; 
    public GameObject handle;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != gameObject)
        {
            return;
        }
      
        holdWindow = true;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z);
        offset = this.transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        holdWindow = false;
    }
    void Update()
    {
        if (holdWindow)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - this.transform.position.z); 
            this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        }
    }
}