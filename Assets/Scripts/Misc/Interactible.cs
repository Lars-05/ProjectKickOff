using UnityEngine;
using UnityEngine.EventSystems;

public class Interactible : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject window;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (window.activeSelf == false)
        {
            window.SetActive(true);
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
