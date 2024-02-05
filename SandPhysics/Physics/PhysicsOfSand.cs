using Microsoft.Xna.Framework;

namespace SandPhysics.Physics
{
    public class PhysicsOfSand
    {
        public PhysicsOfSand()
        {

        }

        public float GetYPosition(float grainOfSandPositionY, float grainOfSandSpeed, GameTime gameTime)
        {
            return grainOfSandPositionY += grainOfSandSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
