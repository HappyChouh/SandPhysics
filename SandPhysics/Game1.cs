using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandPhysics.Physics;
using SharpDX.Direct3D9;

namespace SandPhysics
{
    public class Game1 : Game
    {
        private Texture2D grainOfSand;
        private Vector2 grainOfSandPosition;
        private float grainOfSandSpeed;

        private Texture2D ground;

        private PhysicsOfSand physics; 

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            grainOfSandPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            grainOfSandSpeed = 0.5f;

            physics = new PhysicsOfSand();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            grainOfSand = Content.Load<Texture2D>("sand");
            ground = Content.Load<Texture2D>("ground");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic 
            grainOfSandSpeed = grainOfSandSpeed + (grainOfSandSpeed * 0.3f);
            if (grainOfSandPosition.Y + grainOfSandSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds > 480)
            {
                grainOfSandPosition.Y = 470;
            }
            else
            {
                grainOfSandPosition.Y = physics.GetYPosition(grainOfSandPosition.Y, grainOfSandSpeed, gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ground, new Vector2(0, 480), Color.White);
            _spriteBatch.Draw(grainOfSand, grainOfSandPosition, null, Color.White, 0f, new Vector2(grainOfSand.Width / 2, grainOfSand.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
