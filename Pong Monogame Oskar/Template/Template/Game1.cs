using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        //KeyboardState kstate = Keyboard.GetState();
        Rectangle ball = new Rectangle(100, 100, 20, 20);
        Rectangle left_paddle = new Rectangle(10, 150, 20, 150);
        Rectangle right_paddle = new Rectangle(770, 150, 20, 150);

        int x_speed = 2;
        int y_speed = 2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState kstate = Keyboard.GetState();

            ball.X += x_speed;
            ball.Y += y_speed;

            // TODO: Add your update logic here

            base.Update(gameTime);
            if (kstate.IsKeyDown(Keys.Up))
                right_paddle.Y -= 5;
            if (kstate.IsKeyDown(Keys.Down))
                right_paddle.Y += 5;
            if (kstate.IsKeyDown(Keys.W))
                left_paddle.Y -= 5;
            if (kstate.IsKeyDown(Keys.S))
                left_paddle.Y += 5;

            if (left_paddle.Y < 0)
                left_paddle.Y = 0;
            if (left_paddle.Y > Window.ClientBounds.Height - left_paddle.Height)
                left_paddle.Y = Window.ClientBounds.Height - left_paddle.Height;
            if (right_paddle.Y < 0)
                right_paddle.Y = 0;
            if (right_paddle.Y > Window.ClientBounds.Height - left_paddle.Height)
                right_paddle.Y = Window.ClientBounds.Height - left_paddle.Height;

            if (ball.Y < 0 || ball.Y > Window.ClientBounds.Height - ball.Height)
                y_speed *= -1;

            if (ball.Intersects(left_paddle) || ball.Intersects(right_paddle))
                x_speed *= -1;

            if (ball.X < 0 || ball.X > Window.ClientBounds.Width - ball.Width)
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            // TODO: Add your drawing code here.

            spriteBatch.Begin();
            spriteBatch.Draw(pixel, ball, Color.Green);
            spriteBatch.Draw(pixel, left_paddle, Color.Green);
            spriteBatch.Draw(pixel, right_paddle, Color.Green);
            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
