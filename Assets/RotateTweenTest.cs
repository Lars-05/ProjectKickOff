using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateTweenTest : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DORotate(new Vector3(0, 30, 0), 0.2f, RotateMode.Fast).SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutSine);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
     
    }
}
