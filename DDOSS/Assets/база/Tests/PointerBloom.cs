using UnityEngine;
using база.Player;

namespace база
{
    public class PointerBloom : MonoBehaviour, IPointable
    {
        public SpriteRenderer spriteRenderer;

        private void Awake()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Point()
        {
            var color = spriteRenderer.color;
            color = new Color(color.r, color.g, color.b, 180);
            
            spriteRenderer.color = color;
        }
    }
}