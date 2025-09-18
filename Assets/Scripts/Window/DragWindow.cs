using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler
{
    bool holdWindow = false; 
    Vector3 offset; 
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != gameObject)
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject);
            return;
        }

        Debug.Log("wawawwa");
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