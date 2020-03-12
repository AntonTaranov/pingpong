using UnityEngine;

namespace PingPong
{
    public class MouseObserver : MonoBehaviour
    {
        public float DeltaX { get; private set; }

        Camera cam;

        Vector3 lastMousePosition;
        bool mouseDown;

        void Start()
        {
            cam = Camera.main;
        }

        void Update()
        {
            DeltaX = 0;
            if (Input.GetMouseButton(0))
            {
                if (mouseDown)
                {
					var mouseDelta = cam.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;					
					DeltaX = mouseDelta.x;
                }
                else
                {
                    mouseDown = true;
                }
                lastMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                mouseDown = false;
            }
        }
    }
}
