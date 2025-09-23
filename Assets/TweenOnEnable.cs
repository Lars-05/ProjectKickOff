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
        transform.DORotate(new Vector3(0, 0, 2), 0.2f, RotateMode.Fast).SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.OutSine);
        transform.DOScale(new Vector3(orginalScale.x + 0.1f, orginalScale.z + 0.1f, orginalScale.z + 0.1f), 0.1f)
            .SetEase(Ease.OutBounce);
        transform.DOScale(orginalScale , 0.1f)
            .SetEase(Ease.OutBounce);
    }
}
