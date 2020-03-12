using System;
namespace PingPong.Data
{
    public class PlatformData : MovingObject
    {
        float width;
        uint hitCounter;

        public PlatformData(float width)
        {
            this.width = width;
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
    }
}
