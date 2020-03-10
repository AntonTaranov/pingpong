using System;
namespace PingPong.Data
{
    public class PlatformData : MovingObject
    {
        float width;

        public PlatformData(float width)
        {
            this.width = width;
        }

        public float GetWidth()
        {
            return width;
        }
    }
}
