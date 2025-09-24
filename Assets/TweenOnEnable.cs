using System;
using DG.Tweening;
using UnityEngine;

public class TweenOnEnable : MonoBehaviour
{
    private Vector3 orginalScale;
    public void Awake()
    {
        orginalScale = transform.localScale;
    }
    private void OnEnable()
    {
        transform.DOKill();
        
        Sequence seq = DOTween.Sequence();
        
        seq.Append(transform.DORotate(new Vector3(0, 0, 2), 0.2f, RotateMode.Fast)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutSine));
        
        seq.Join(transform.DOScale(orginalScale + new Vector3(0.1f, 0.1f, 0.1f), 0.1f)
            .SetEase(Ease.OutBounce)
            .SetLoops(2, LoopType.Yoyo));
    }
}
