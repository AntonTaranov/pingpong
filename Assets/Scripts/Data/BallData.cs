﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong.Data
{
    public class BallData : MovingObject
    {
        float radius;

        public BallData(float radius)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return radius;
        }

        public void UpdatePosition(float deltaTime)
        {
            position.x += deltaTime * speed.x;
            position.y += deltaTime * speed.y;
        }

        public void InvertSpeed(bool x, bool y)
        {
            speed.x = x ? -speed.x : speed.x;
            speed.y = y ? -speed.y : speed.y;
        }
    }
}