using System;
using UnityEngine;

namespace база.InputService
{
    public interface IInputService
    {
        event Action<Vector2> OnMoved;
    }
}