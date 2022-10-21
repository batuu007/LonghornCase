using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : OfficeObject
{
    [SerializeField] private Renderer _boardRenderer;
    [SerializeField] private GameObject _pen;
    public override void OnClick()
    {
        if (preObj.GetID() == ID -1 && isObj)
        {
            OnClickVFX.SetActive(true);
            gameObject.transform.DOScale(gameObject.transform.localScale * 2f, 0.1f).OnComplete(() =>
            {
                gameObject.transform.DOScale(gameObject.transform.localScale * .5f, 0.1f);
                Vector3 newPenPos = new Vector3(-0.064f, 1.491f, 7.611f);
                preObj.gameObject.transform.DOMove(newPenPos, 0.5f).OnComplete(() =>
                {
                    preObj.gameObject.GetComponent<Animator>().enabled = true;
                    OnClickVFX.SetActive(false);
                    DOTween.Sequence().SetDelay(1f).OnComplete(() =>
                    {
                        preObj.gameObject.GetComponent<Animator>().enabled = false;
                        preObj.gameObject.transform.DOMove(_pen.transform.position, 0.25f).OnComplete(() =>
                        {
                            preObj.gameObject.transform.parent = this.gameObject.transform;
                            this.gameObject.transform.DOScale(this.gameObject.transform.localScale * 2f, 0.2f).OnComplete(()=>
                            {
                                this.gameObject.transform.DOScale(gameObject.transform.localScale * 0.5f, 0.1f);
                            });
                            nextObj.isObj = true;
                            nextObj.SetPreObject(this);
                            preObj.gameObject.transform.DORotate(new Vector3(0, -90, 0), .3f);
                        });
                        _boardRenderer.material.color = Color.black;
                    });
                });
                
            });
        }
    }
}
