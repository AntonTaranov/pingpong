using System.Collections;
using System.Collections.Generic;
using PingPong.Data;
using UnityEngine;

namespace PingPong
{
    public class Simulator
    {
        List<BallData> balls;
        List<PlatformData> platforms;

        float halfWidth;
        float halfHeight;

        bool started = false;
        bool godMode = false;

        public Simulator(float width, float height)
        {
            balls = new List<BallData>();
            platforms = new List<PlatformData>();
            halfWidth = width * 0.5f;
            halfHeight = height * 0.5f;
        }

        public void SpawnBall(BallData circle)
        {
            balls.Add(circle);
        }

        public void AddPlatform(PlatformData platform)
        {
            platforms.Add(platform);
        }

        public void StartMoving(float minSpeed, float maxSpeed)
        {
            foreach(var ball in balls)
            {
                var speedValue = minSpeed + Random.value * (maxSpeed - minSpeed);
                var speed = new Vector2(Random.value - 0.5f, Random.value - 0.5f);
                speed.Normalize();
                ball.SetSpeed(speed * speedValue);               
            }

            started = true;
        }

        public void Update(float deltaTime)
        {
            if (!started) return;
            CheckFieldBoundsForPlatforms();
            foreach(var ball in balls)
            {
                ball.UpdatePosition(deltaTime);
                CheckCollisionWithWalls(ball);
                CheckCollisionWithHorizontalPlatforms(ball);
            }
        }

        void CheckFieldBoundsForPlatforms()
        {
            foreach(var platform in platforms)
            {
                var postition = platform.GetPosition();
                if (postition.x > halfWidth - platform.GetWidth() * 0.5f)
                {
                    platform.SetPositionX(halfWidth - platform.GetWidth() * 0.5f);
                }
                else if(postition.x < -halfWidth + platform.GetWidth() * 0.5f)
                {
                    platform.SetPositionX(-halfWidth + platform.GetWidth() * 0.5f);
                }
            }
        }

        void CheckCollisionWithHorizontalPlatforms(BallData ball)
        {
            var position = ball.GetPosition();
            var radius = ball.GetRadius();
            foreach (var platform in platforms)
            {
                var platformPosition = platform.GetPosition();
                if (platformPosition.y > 0 && position.y < platformPosition.y)
                {
                    if(platformPosition.y - position.y < radius)
                    {
                        if (position.x + radius > platformPosition.x - platform.GetWidth() &&
                            position.x - radius < platformPosition.x + platform.GetWidth())
                        {
                            HitPlatform(ball, platform);
                            return;
                        }
                    }
                }
                if (platformPosition.y < 0 && position.y > platformPosition.y)
                {
                    if (position.y - platformPosition.y <= radius)
                    {
                        if (position.x + radius > platformPosition.x - platform.GetWidth() &&
                            position.x - radius < platformPosition.x + platform.GetWidth())
                        {
                            HitPlatform(ball, platform);
                            return;
                        }
                    }
                }
            }
        }

        void HitPlatform(BallData ball, PlatformData platform)
        {
            float deltaY = 0;
            var ballPosition = ball.GetPosition();
            var platformPosition = platform.GetPosition();
            if (ballPosition.y > platformPosition.y)
            {
                deltaY = platformPosition.y - ballPosition.y + ball.GetRadius();
            }
            else
            {
                deltaY = platformPosition.y - ballPosition.y - ball.GetRadius();
            }
            float updateTime = deltaY / ball.GetSpeed().y;

            ball.UpdatePosition(updateTime);
            ball.InvertSpeed(false, true);
            ball.UpdatePosition(-updateTime);

        }

        void CheckCollisionWithWalls(BallData ball)
        {
            var position = ball.GetPosition();
            var radius = ball.GetRadius();
            var invertX = false;
            var invertY = false;
            float deltaX = 0;
            float deltaY = 0;
            if (position.x + radius > halfWidth)
            {
                invertX = true;
                deltaX = halfWidth - position.x - radius;
            }
            else if (position.x - radius < -halfWidth)
            {
                invertX = true;
                deltaX = -halfWidth - position.x + radius;
            }

            if (godMode)
            {
                if (position.y + radius > halfHeight)
                {
                    invertY = true;
                    deltaY = halfHeight - position.y - radius;
                }
                else if (position.y - radius < -halfHeight)
                {
                    invertY = true;
                    deltaY = -halfHeight - position.y + radius;
                }
            }
            
            float updateTimeX = 0;
            float updateTimeY = 0;
            var speed = ball.GetSpeed();
            if(invertX)
            {
                updateTimeX = deltaX / speed.x;
            }
            if (invertY)
            {
                updateTimeY = deltaY / speed.y;
            }

            if (invertX || invertY)
            {
                var updateTime = Mathf.Min(updateTimeX, updateTimeY);
                ball.UpdatePosition(updateTime);
                ball.InvertSpeed(invertX, invertY);
                ball.UpdatePosition(-updateTime);
            }

        }
           
    }
}
