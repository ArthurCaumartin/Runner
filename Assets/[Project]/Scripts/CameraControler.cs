using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offSet = new Vector3(0, 0, -10);
    [SerializeField] private float _followSpeed;
    private Vector3 _velocity;

    private void OnValidate()
    {
        if(!_target) return;
        transform.position = _target.position + _offSet;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _target.position + _offSet
                                                , ref _velocity, 1 / _followSpeed);
    }
}
