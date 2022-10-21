using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OfficeObject : MonoBehaviour
{
    public int ID;
    public bool isObj;
    public GameObject OnClickVFX;
    public GameManager manager;
    public OfficeObject nextObj;
    internal OfficeObject preObj;

    public abstract void OnClick();

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public int GetID()
    {
        return ID;
    }

    public OfficeObject GetNextObject()
    {
        return nextObj;
    }

    public OfficeObject GetPreObject()
    {
        return preObj;
    }

    public void SetPreObject(OfficeObject previousObj)
    {
        preObj = previousObj;
    }
    public GameObject GetVFX()
    {
        return OnClickVFX;
    }
}
