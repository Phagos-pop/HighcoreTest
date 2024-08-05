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
            CheakArrowKey();
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
        if (Input.GetKey(KeyCode.W))
        {
            OnClickMovementButton?.Invoke(MovementType.Forward);
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            OnClickMovementButton?.Invoke(MovementType.Left);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            OnClickMovementButton?.Invoke(MovementType.Back);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnClickMovementButton?.Invoke(MovementType.Right);
            return;
        }
    }

    private void CheakArrowKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            OnClickMovementButton?.Invoke(MovementType.Forward);
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnClickMovementButton?.Invoke(MovementType.Left);
            return;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            OnClickMovementButton?.Invoke(MovementType.Back);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnClickMovementButton?.Invoke(MovementType.Right);
            return;
        }
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
