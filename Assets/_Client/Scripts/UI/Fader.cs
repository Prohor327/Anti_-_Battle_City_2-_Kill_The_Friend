using UnityEngine;
using DG.Tweening;
using System;

public class Fader : MonoBehaviour 
{   
    [SerializeField] private CanvasGroup _canvasGroup;

    public bool isFade { get; private set; } = false;

    public Action OnFaded;
    public Action OnUnFaded;

    public void Fade()
    {
        if(!isFade)
        {
            _canvasGroup.DOFade(1, 1).onComplete = CallAction;
            isFade = true;
        }
    }

    public void Unfade()
    {
        if(isFade)
        {
            _canvasGroup.DOFade(0, 1);
            isFade = false;
        }
    }


    private void CallAction()
    {
        OnFaded.Invoke();
    }
}