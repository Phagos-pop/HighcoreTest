using Test.Character;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private MainCharacter _targetTranform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float LerpSpeed;

    [SerializeField] private float _maxAngle;
    [SerializeField] private float _sentivityX;
    [SerializeField] private float _sentivityY;

    private float _rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        var vector = _targetTranform.transform.position + _offset;
        transform.position = Vector3.Lerp(transform.position, vector, LerpSpeed);


        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _targetTranform.SetRotation(mouseX * _sentivityX);

        _rotationX -= mouseY * _sentivityY;
        _rotationX = Mathf.Clamp(_rotationX, -_maxAngle, _maxAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
    }
}
