using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseWindow : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TaskCardScript taskCardScript;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != gameObject)
            return;
        taskCardScript.MakeInvisible(); 
    }
}