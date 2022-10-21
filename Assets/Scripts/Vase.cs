using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : OfficeObject
{
    [SerializeField] private GameObject _plant;
    [SerializeField] private GameObject _glass;
    public override void OnClick()
    {
        if (isObj)
        {
            gameObject.transform.DOScale(transform.localScale * 1.5f, 0.1f).OnComplete(() =>
            {
                gameObject.transform.DOScale(transform.localScale * .66f, 0.1f);
                preObj.gameObject.transform.DOMove(_glass.transform.position, 2f).OnComplete(() =>
                     {
                         preObj.gameObject.transform.DORotate(new Vector3(0, 0, 90), 1f).OnComplete(() =>
                         {
                             preObj.GetComponent<Cup>()._water.SetActive(false);
                         });
                         DOTween.Sequence().SetDelay(0.25f).OnComplete(() =>
                         {
                             _plant.SetActive(true);
                             DOTween.Sequence().SetDelay(.5f).OnComplete(() =>
                             {
                                 this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 1.5f, 0.1f);
                                 preObj.gameObject.transform.DORotate(new Vector3(0, 0, 0), .5f).OnComplete(() =>
                                    {
                                        nextObj.isObj = true;
                                        nextObj.SetPreObject(preObj);
                                        this.gameObject.transform.DOScale(this.gameObject.transform.localScale * .66f, 0.1f);
                                    });
                             });
                         });
                     });
            });
        }
    }
}
