using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private bool _isTouched;
    [SerializeField] private OfficeObject _nextObj;
    [SerializeField] private OfficeObject _lastObj;

    private RaycastHit _hit;
    private bool _isStarted;

    private void Start()
    {
        _isStarted = true;
    }
    public void TouchDown()
    {
        if (_isStarted)
        {
            _isTouched = true;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit, 200f))
            {
                if (_hit.collider.tag == "Object")
                {
                    if (!_nextObj)
                    {
                        if (_hit.collider.GetComponent<OfficeObject>().ID == 0)
                        {
                            _hit.collider.GetComponent<OfficeObject>().OnClick();
                            _lastObj = _hit.collider.gameObject.GetComponent<OfficeObject>();
                            _nextObj = _lastObj.GetNextObject();
                        }
                    }
                    else
                    {
                        if (_hit.collider.gameObject == _nextObj.gameObject && _hit.collider.GetComponent<OfficeObject>().isObj) ;
                        {
                            _hit.collider.GetComponent<OfficeObject>().OnClick();
                            _lastObj = _hit.collider.gameObject.GetComponent<OfficeObject>();
                            _nextObj = _lastObj.GetNextObject();
                        }
                    }
                }
            }
        }
    }
    public void TouchUp()
    {
        _isTouched = false;
    }
}
