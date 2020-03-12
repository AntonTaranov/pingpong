using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PingPong.Data;

namespace PingPong
{
    public class Ball : MonoBehaviour
    {
        private const float CIRCLE_Z = -1;
        readonly Color color = Color.white;
        BallData data;
        SpriteRenderer spriteRenderer;

        public void SetData(BallData data)
        {
            this.data = data;
            if (spriteRenderer == null)
                InitializeSprite(color);
            var radius = data.GetRadius();
            transform.localScale = new Vector3(radius, radius, 1);
            UpdatePosition();
        }

        private void InitializeSprite(Color color)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Sprite>("white_circle");
            if (texture != null)
            {
                spriteRenderer.sprite = texture;
                spriteRenderer.color = color;
            }
        }
                    
        private void UpdatePosition()
        {
            var position = data.GetPosition();
            transform.localPosition = new Vector3(position.x, position.y, CIRCLE_Z);
        }

        void Update()
        {
            if (data.IsAlive)
            {
                UpdatePosition();
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
