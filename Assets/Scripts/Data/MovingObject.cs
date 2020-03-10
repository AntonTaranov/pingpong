using UnityEngine;
namespace PingPong.Data
{
    public class MovingObject
    {
        protected Vector2 position;
        protected Vector2 speed;

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPositionX(float x)
        {
            position.x = x;
        }

        public void SetPositionY(float y)
        {
            position.y = y;
        }

        public void SetSpeed(Vector2 value)
        {
            speed = value;
        }

        public Vector2 GetSpeed()
        {
            return speed;
        }
    }
}
