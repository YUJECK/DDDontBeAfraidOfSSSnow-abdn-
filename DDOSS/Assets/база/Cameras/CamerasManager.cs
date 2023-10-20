using UnityEngine;

namespace база.Cameras
{
    public sealed class CamerasManager
    {
        private readonly CamerasContainer _camerasContainer;

        public CamerasManager(CamerasContainer camerasContainer)
        {
            _camerasContainer = camerasContainer;
        }

        public Camera GetMain() => _camerasContainer.MainCamera;
    }
}