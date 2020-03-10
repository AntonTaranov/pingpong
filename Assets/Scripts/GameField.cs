using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPong
{
    public class GameField : MonoBehaviour
    {
        float width;
        float height;

        SpriteRenderer fieldSprite;

        public void CreateField(float width, float height)
        {
            this.width = width;
            this.height = height;

            if (fieldSprite == null)
            {
                InitializeSprite();
            }

            var size = transform.localScale;
            size.x = width;
            size.y = height;
            transform.localScale = size;
        }

        private void InitializeSprite()
        {
            fieldSprite = gameObject.AddComponent<SpriteRenderer>();
            var fieldTexture = Resources.Load<Sprite>("white_pixel");
            if (fieldTexture != null)
            {
                fieldSprite.sprite = fieldTexture;
                fieldSprite.color = new Color(0.43f, 0.5f, 0.5f, 1);
            }
        }
    }
}