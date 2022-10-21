using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pencil : OfficeObject
{
    public override void OnClick()
    {
        OnClickVFX.SetActive(true);
        gameObject.transform.DOScale(gameObject.transform.localScale * 2f, 0.1f).OnComplete(() =>
           {
               gameObject.transform.DOScale(gameObject.transform.localScale * 0.5f, 0.1f);
               DOTween.Sequence().SetDelay(.5f).OnComplete(() =>
               {
                   OnClickVFX.SetActive(false);
               });
               nextObj.SetPreObject(this);
               nextObj.isObj = true; 
           });
    }

}
