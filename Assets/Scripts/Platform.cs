using UnityEngine;
using PingPong.Data;

namespace PingPong
{
    public class Platform : MonoBehaviour
    {
        private const float POS_Z = -2;
        readonly Color color = Color.white;
        PlatformData data;
        SpriteRenderer spriteRenderer;
        MouseObserver mouse;

        public void SetData(PlatformData data)
        {
            this.data = data;
            if (spriteRenderer == null)
                InitializeSprite(color);
            var width = data.GetWidth();
            transform.localScale = new Vector3(width, 3, 1);
            UpdatePosition();
            mouse = gameObject.AddComponent<MouseObserver>();
        }

        private void InitializeSprite(Color color)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            var texture = Resources.Load<Sprite>("white_pixel");
            if (texture != null)
            {
                spriteRenderer.sprite = texture;
                spriteRenderer.color = color;
            }
        }

        private void UpdatePosition()
        {
            var position = data.GetPosition();
            transform.localPosition = new Vector3(position.x, position.y, POS_Z);
        }

        void Update()
        {
            var deltaX = mouse.DeltaX;
            if (deltaX > 0 || deltaX < 0)
            {
                var lastPosition = data.GetPosition();
                data.SetPositionX(lastPosition.x + deltaX);
                data.SetSpeed(new Vector2(deltaX / Time.deltaTime, 0));
                UpdatePosition();
            }
            else
            {
                data.SetSpeed(Vector2.zero);
            }
        }
    }
}
