using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransitionEffect : MonoBehaviour
{
    [SerializeField] public float fadetime;
    [SerializeField] CanvasGroup myFadingGroup;
    public void transition()
    {
        myFadingGroup.gameObject.SetActive(true);
        myFadingGroup.DOFade(0.7f, fadetime)
            .OnComplete(() => myFadingGroup.DOFade(0, fadetime)
            .OnComplete(() => myFadingGroup.gameObject.SetActive(false)));
    }
}
