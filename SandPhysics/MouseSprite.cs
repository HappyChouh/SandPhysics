using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SandPhysics
{
    internal class MouseSprite : ScaledSprite
    {
        public MouseSprite(Texture2D texture, Vector2 position): base(texture, position) { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position.X = Mouse.GetState().X;
            Position.Y = Mouse.GetState().Y;
        }
    }
}
