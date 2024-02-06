using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace SandPhysics
{
    public class Game1 : Game
    {
        //private Vector2 grainOfSandPosition;
        //private float grainOfSandSpeed;

        private List<MovingSprite> grainsOfSand;
        private MouseSprite grainOfSand;

        private Texture2D ground;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _previousMouseState = Mouse.GetState();

            // TODO: use this.Content to load your game content here
            Texture2D sandTexture = Content.Load<Texture2D>("sand");
            grainsOfSand = new List<MovingSprite>();

            grainOfSand = new MouseSprite(sandTexture, Vector2.One);

            ground = Content.Load<Texture2D>("ground");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                grainsOfSand.Add(new MovingSprite(grainOfSand.Texture, grainOfSand.Position, 0.5f));
                Debug.WriteLine("Button is pressed ");
            }
            grainOfSand.Update();
            foreach (MovingSprite movingSprite in grainsOfSand)
            {
                movingSprite.Update();
            }
            // TODO: Add your update logic 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp) ;
            _spriteBatch.Draw(ground, new Vector2(0, 480), Color.White);
            foreach(MovingSprite movingSprite in grainsOfSand)
            {
                _spriteBatch.Draw(movingSprite.Texture, movingSprite.Rect, Color.White);
            }
            _spriteBatch.Draw(grainOfSand.Texture, grainOfSand.Rect, Color.White);
            //_spriteBatch.Draw(grainOfSand, grainOfSandPosition, null, Color.White, 0f, new Vector2(grainOfSand.Width / 2, grainOfSand.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
