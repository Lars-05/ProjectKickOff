using DG.Tweening;
using UnityEngine;using UnityEngine.EventSystems;

public class TweenScale : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 orginalScale;
    public void Awake()
    {
        orginalScale = transform.localScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(new Vector3(orginalScale.x + 0.1f, orginalScale.z + 0.1f, orginalScale.z + 0.1f), 0.1f)
            .SetEase(Ease.OutBounce);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(orginalScale, 0.1f)
            .SetEase(Ease.OutBounce);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
     
    }
    
    public void OnClicked() 
    {
        transform.DOScale(1.2f, 0.2f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() => transform.DOScale(1f, 0.2f));
    }
}
