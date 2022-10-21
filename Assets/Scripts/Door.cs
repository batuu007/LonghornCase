using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : OfficeObject
{
    [SerializeField] private GameObject _finishVFX;
    [SerializeField] public GameObject _doorFinishVFX;
    public override void OnClick()
    {
        if (isObj)
        {
            OnClickVFX.SetActive(true);
            _doorFinishVFX.SetActive(false);
            this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 1.2f, 0.2f).OnComplete(() =>
               {
                   this.gameObject.transform.DOScale(this.gameObject.transform.localScale * .84f, 0.2f);
                   this.gameObject.transform.DORotate(new Vector3(0,60,0),1f).OnComplete(()=>
                   {
                       _finishVFX.SetActive(true);
                       OnClickVFX.SetActive(false);
                       DOTween.Sequence().SetDelay(1f).OnComplete(() =>
                       {
                           Level.Instance.ShowLevelCanvas();
                       });
                   });
               });
        }
    }
}
