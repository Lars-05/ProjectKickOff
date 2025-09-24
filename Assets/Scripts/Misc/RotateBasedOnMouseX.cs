using UnityEngine;
using UnityEngine.EventSystems;

public class RotateBasedOnMouseX : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    private float currentRotation;
    bool holdWindow = false;
    private bool mouseIsMoving;
    float mousePosition;
    Vector3 offset;
    public float speed;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        var v3 = Input.mousePosition;
        v3.z = 1000.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        mousePosition = v3.x; 
        holdWindow = true;
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
            
            currentRotation += Input.GetAxis("Mouse X") * speed;
            
            this.transform.rotation = Quaternion.Euler(0, currentRotation , 0);
        }
        
    }

}
