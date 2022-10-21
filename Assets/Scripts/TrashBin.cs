using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : OfficeObject
{
    [SerializeField] private GameObject _trashVFX;
    public override void OnClick()
    {
        if (isObj)
        {
            OnClickVFX.SetActive(true);
            this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 2f, .25f).OnComplete(() =>
             {
                 this.gameObject.transform.DOScale(this.gameObject.transform.localScale * .5f, .25f);

                 preObj.gameObject.transform.DOMove(new Vector3(0.88f, 0.49871f, 5.39932f), 1f).OnComplete(() =>
                    {
                        _trashVFX.SetActive(true);
                        OnClickVFX.SetActive(false);
                        Destroy(preObj,.5f);
                        nextObj.GetComponent<Door>()._doorFinishVFX.SetActive(true);
                        nextObj.isObj = true;
                        nextObj.SetPreObject(this);
                    });
             });
        }
    }

}
