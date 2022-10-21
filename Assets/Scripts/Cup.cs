using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : OfficeObject
{
    [SerializeField] public GameObject _water;
    public override void OnClick()
    {
        if (isObj)
        {
            OnClickVFX.SetActive(true);
            gameObject.transform.DOScale(gameObject.transform.localScale * 2f, 0.2f).OnComplete(() =>
             {
                 gameObject.transform.DOScale(gameObject.transform.localScale * .5f, 0.2f);
                 DOTween.Sequence().SetDelay(.5f).OnComplete(() =>
                 {
                     OnClickVFX.SetActive(false);
                 });
                 nextObj.isObj = true;
                 nextObj.SetPreObject(this);
             });
        }
    }

}
