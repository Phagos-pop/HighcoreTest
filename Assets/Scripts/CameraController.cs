using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private MainCharacter _targetTranform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float LerpSpeed;

    [SerializeField] private float _maxAngle;
    [SerializeField] private float _sentivity;

    private float _rotationX;
    private float _rotationY;

    private void LateUpdate()
    {
        var vector = _targetTranform.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, vector, LerpSpeed);


        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _targetTranform.SetRotation(mouseX);

        _rotationX -= mouseY * _sentivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxAngle, _maxAngle);
        _rotationY = _targetTranform.transform.rotation.eulerAngles.y;
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    }
}
