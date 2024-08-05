using System;
using UnityEngine;

public interface IInputService
{
    public event Action<MovementType> OnClickMovementButton;
    public event Action<int> OnClickNumberButton;
    public event Action<Vector3> OnMouseButtonHold;
    public event Action<Vector3> OnMouseButtonUp;
    public event Action<Vector3> OnMouseButtonDown;
}
