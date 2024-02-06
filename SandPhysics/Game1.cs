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

        private List<SandSprite> grainsOfSand;
        private MouseSprite grainOfSand;

        private ScaledSprite ground;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        private bool mouse_pressed = false;



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
            grainsOfSand = new List<SandSprite>();

            grainOfSand = new MouseSprite(sandTexture, Vector2.One);

            Texture2D groundTexture = Content.Load<Texture2D>("ground");
            ground = new ScaledSprite(groundTexture, new Vector2(0, _graphics.PreferredBackBufferHeight - groundTexture.Height));
        }

        protected override async void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!mouse_pressed && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mouse_pressed = true;
                grainsOfSand.Add(new SandSprite(grainOfSand.Texture, grainOfSand.Position, 10f));

            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                mouse_pressed = false;

            }
            grainOfSand.Update(gameTime);

            foreach (SandSprite sandSprite in grainsOfSand)
            {
                foreach (SandSprite sandSprite1 in grainsOfSand)
                {
                    if (sandSprite.Position.Y > sandSprite1.Position.Y && sandSprite1.Rect.Intersects(sandSprite.Rect) && sandSprite.OnSomething == false)
                    {
                        sandSprite.Position.Y = sandSprite1.Position.Y - sandSprite1.Texture.Height;
                        sandSprite.speed = 0.1f;
                        sandSprite.OnSomething = true;
                    }
                }
                if (sandSprite.Position.Y <= ground.Position.Y - sandSprite.Texture.Height && sandSprite.OnSomething == false)
                {
                    sandSprite.Update(gameTime);
                }
                else if (sandSprite.Position.Y > ground.Position.Y - sandSprite.Texture.Height)
                {
                    sandSprite.Position.Y = (float)_graphics.PreferredBackBufferHeight - (float)sandSprite.Texture.Height - (float)ground.Texture.Height;
                    sandSprite.speed = 0.1f;
                    sandSprite.OnSomething = true;
                }

            }
            // TODO: Add your update logic 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(ground.Texture, ground.Rect, Color.White);
            foreach (SandSprite movingSprite in grainsOfSand)
            {
                _spriteBatch.Draw(movingSprite.Texture, movingSprite.Rect, Color.White);
            }
            _spriteBatch.Draw(grainOfSand.Texture, grainOfSand.Rect, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
