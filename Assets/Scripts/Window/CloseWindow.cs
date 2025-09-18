using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CloseWindow : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent MakeWindowInvisible;
    
    
 
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != gameObject)
            return;
        MakeWindowInvisible.Invoke();
    }
}