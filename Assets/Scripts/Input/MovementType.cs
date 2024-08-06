using System;

[Flags]
public enum MovementType
{
    None = 0,
    Left = 1,
    Right = 2,
    Forward = 4,
    Back = 8
}
