using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    [SerializeField] private Vector3 _center = Vector3.zero;
    [SerializeField] private Vector3 _axis = Vector3.up;
    [SerializeField] private float _period = 2;
    [SerializeField] private bool _updateRotation;
    [SerializeField] GameObject obj;


    private void Start()
    {
        _center = obj.transform.position;
    }
    private void Update()
    {
        var tr = transform;
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);
        var pos = tr.position;

        pos -= _center;
        pos = angleAxis * pos;
        pos += _center;

        tr.position = pos;

        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }
    }
}