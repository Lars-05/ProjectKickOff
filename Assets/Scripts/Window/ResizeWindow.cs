using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeWindow : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler,
    IPointerUpHandler
{
    
    
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
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

            RectTransform rectTransform = parent.GetComponent<RectTransform>();
            float width = rectTransform.rect.width; 
            float height = rectTransform.rect.height;
            rectTransform.sizeDelta = new Vector2(Mathf.Clamp(width -= (deltaMousePosition.x) / 200, xMin, xMax),
                Mathf.Clamp(height += (deltaMousePosition.y) / 200, yMin, yMax));
            //Debug.Log(-deltaMousePosition.x / 200);


        }
    }
}