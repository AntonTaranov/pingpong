using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class CameraController : MonoBehaviour
    {
        GameObject gameFieldGameObject;
        Camera mainCamera;

        int width;
        int height;

        bool dirty = false;

        public void SetTargetGameObject(GameObject value)
        {
            gameFieldGameObject = value;
            mainCamera = Camera.main;
            dirty = true;
        }

        void Update()
        {
            if (mainCamera != null)
            {
                if (dirty || mainCamera.pixelHeight != height || mainCamera.pixelWidth != width)
                {
                    width = mainCamera.pixelWidth;
                    height = mainCamera.pixelHeight;

                    var fieldSize = gameFieldGameObject.transform.localScale;
                    var fieldMaxSize = fieldSize.x > fieldSize.y ? fieldSize.x : fieldSize.y;
                    if (height > width)
                    {
                        mainCamera.orthographicSize = fieldMaxSize * height / width * 0.5f;
                    }
                    else
                    {
                        mainCamera.orthographicSize = fieldMaxSize * 0.5f;
                    }
                    dirty = false;
                }
            }
        }
    }
}