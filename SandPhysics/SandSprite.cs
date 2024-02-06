using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SandPhysics
{
    internal class SandSprite : ScaledSprite
    {
        public float speed;
        public bool OnSomething = false;
        public SandSprite(Texture2D texture, Vector2 position, float speed) : base(texture, position) {
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float acceleration = 400f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            speed += acceleration;
            Position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
