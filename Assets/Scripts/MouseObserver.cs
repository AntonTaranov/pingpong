using UnityEngine;

namespace PingPong
{
    public class MouseObserver : MonoBehaviour
    {
        public float DeltaX { get; private set; }

        Camera cam;

        private Vector3 lastMousePosition;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            DeltaX = 0;
            if (Input.GetMouseButton(0))
            {
                var mouseDelta = cam.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;

                DeltaX = mouseDelta.x;
            }
            lastMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
