using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour
{
    [SerializeField] bool Map;
    [SerializeField] bool Button;
    [SerializeField] Canvas curent;
    [SerializeField] Canvas goTo;
    Button button;
    [SerializeField] FadeTransitionEffect transitionEffect;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        if (Map) return;
        if (!Button) return;
        button.onClick.AddListener(btnpressEffect);
    }
    public void OnClick()
    {
        StartCoroutine(delayTransition());
        transitionEffect.transition();
    }
    IEnumerator delayTransition()
    {
        yield return new WaitForSeconds(transitionEffect.fadetime);
        goTo.gameObject.SetActive(true);
        curent.gameObject.SetActive(false);
    }
    public void btnpressEffect()
    {
        Vector3 startPos = this.button.transform.position;
        Vector3 targetPos = startPos - new Vector3(1.5f, -2f, 0);
        this.button.transform.DOMove(targetPos, 0.05f)
            .OnComplete(() => {
                this.button.transform.DOMove(startPos, 0.05f); 
            });
    }
}
