using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCurve : MonoBehaviour
{
    [SerializeField] Transform [] _bezierCurve;
    [SerializeField] float _speedCoef;
    int _runningCurveNo = 0;
    public int _tour = 0;

    void Start()
    {
        StartCoroutine(MoveOnBezierRouteCoroutine());
    }

    IEnumerator MoveOnBezierRouteCoroutine()
    {
        Vector3 _goToPosition = transform.position;
        float t = 0f;

        while (t <= 1)
        {
            t += Time.deltaTime * _speedCoef;
            _goToPosition = CurveController.GetCurvePointByT(t, _bezierCurve[_runningCurveNo].GetChild(0).position,
               _bezierCurve[_runningCurveNo].GetChild(1).position, _bezierCurve[_runningCurveNo].GetChild(2).position, _bezierCurve[_runningCurveNo].GetChild(3).position);
            transform.position = _goToPosition;
            yield return new WaitForEndOfFrame();
        }

        _runningCurveNo++;

        if(_runningCurveNo >= _bezierCurve.Length)
        {
            _runningCurveNo = 0;
            _tour++;
            Debug.Log(gameObject.name + " has complated it's " + _tour + " tour.");
        }    

        StartCoroutine(MoveOnBezierRouteCoroutine());
        yield break;
    }    
}
