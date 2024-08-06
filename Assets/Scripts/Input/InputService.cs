using System;
using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    public event Action<int> OnClickNumberButton;
    public event Action<MovementType> OnClickMovementButton;
    public event Action<Vector3> OnMouseButtonHold;
    public event Action<Vector3> OnMouseButtonUp;
    public event Action<Vector3> OnMouseButtonDown;

    private void Update()
    {
        CheakMouseButton();

        if (Input.anyKey)
        {
            CheakAlphaKey();
            CheakWASDKey();
        }
    }

    private void CheakAlphaKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnClickNumberButton?.Invoke(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnClickNumberButton?.Invoke(2);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnClickNumberButton?.Invoke(3);
            return;
        }
    }

    private void CheakWASDKey()
    {
        var type = MovementType.None;

        if (Input.GetKey(KeyCode.W))
        {
            type |= MovementType.Forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            type |= MovementType.Left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            type |= MovementType.Back;
        }

        if (Input.GetKey(KeyCode.D))
        {
            type |= MovementType.Right;
        }

        OnClickMovementButton?.Invoke(type);
    }

    private void CheakMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseButtonDown?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            OnMouseButtonHold?.Invoke(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnMouseButtonUp?.Invoke(Input.mousePosition);
        }
    }
}
