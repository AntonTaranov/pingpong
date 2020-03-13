using System;
using UnityEngine;

namespace PingPong.Data
{
    public class PlatformData : MovingObject
    {
        float width;
        uint hitCounter;
        Vector2 normal;

        public PlatformData(float width, Vector2 normal)
        {
            this.width = width;
            this.normal = normal;
        }

        public float GetWidth()
        {
            return width;
        }

        public void Restart()
        {
            hitCounter = 0;
        }

        public void Hit()
        {
            hitCounter++;
        }

        public uint Score
        {
            get => hitCounter;
        }

        public Vector2 Normal
        {
            get => normal;
        }
    }
}
