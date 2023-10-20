using System;
using UnityEngine;

namespace база.Cameras
{
    [Serializable]
    public sealed class CamerasContainer
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }

        public CamerasContainer(Camera mainCamera)
        {
            MainCamera = mainCamera;
        }
    }
}