using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaterDrinker : OfficeObject
{
    [SerializeField] private GameObject _glass;
    [SerializeField] private Cup _cup;

    public override void OnClick()
    {
        if (preObj.GetID() == ID - 1 && isObj)
        {
            OnClickVFX.SetActive(true);
            gameObject.transform.DOScale(gameObject.transform.localScale * 1.5f, 0.2f).OnComplete(() =>
               {
                   gameObject.transform.DOScale(gameObject.transform.localScale * .66f, 0.2f);
                   preObj.gameObject.transform.DOMove(_glass.transform.position, .5f).OnComplete(() =>
                    {
                        OnClickVFX.SetActive(false);
                        _cup._water.SetActive(true);
                        preObj.gameObject.transform.DOScale(preObj.transform.localScale * 2f, 0.1f).SetDelay(1f).OnComplete(() =>
                           {
                               preObj.gameObject.transform.DOScale(preObj.transform.localScale * .5f, 0.1f);
                               nextObj.isObj = true;
                               nextObj.SetPreObject(preObj);
                               preObj.nextObj = nextObj;
                           });
                    });
               });
        }
    }
}
