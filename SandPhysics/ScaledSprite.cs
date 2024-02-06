using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SandPhysics
{
    internal class ScaledSprite : Sprite
    {
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
            }
        }
        public ScaledSprite(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }
    }
}
