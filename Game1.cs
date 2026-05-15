using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rectangle_Collision_Lesson
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;

        MouseState mouseState;

        Texture2D barrierTexture, coinTexture, exitTexture, pacLeftTexture, pacRightTexture, pacUpTexture, pacDownTexture, currentPacTexture;

        Rectangle pacRect, exitRect, barrierRect1, barrierRect2, coinRect, window;

        Vector2 pacSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pacSpeed = Vector2.Zero;
            pacRect = new Rectangle(10, 10, 60, 60);

            barrierRect1 = new Rectangle(0, 250, 350, 75);
            barrierRect2 = new Rectangle(450, 250, 350, 75);

            //coinRect = new Rectangle(400, 50, coinTexture.Width, coinTexture.Height);

            coinRect = new Rectangle(400, 50, 60, 60);
            exitRect = new Rectangle(700, 380, 100, 100);

            window = new Rectangle(0, 0, 800, 450);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            barrierTexture = Content.Load<Texture2D>("rock_barrier");

            coinTexture = Content.Load<Texture2D>("coin");

            exitTexture = Content.Load<Texture2D>("hobbit_door");

            pacDownTexture = Content.Load<Texture2D>("pac_down");

            pacUpTexture = Content.Load<Texture2D>("pac_up");

            pacRightTexture = Content.Load<Texture2D>("pac_right");

            pacLeftTexture = Content.Load<Texture2D>("pac_left");

            currentPacTexture = pacRightTexture;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();

            pacSpeed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Left)) 
            {
                pacSpeed.X -= 2;
                currentPacTexture = pacLeftTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Right)) 
            {
                pacSpeed.X += 2;
                currentPacTexture = pacRightTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Up)) 
            {
                pacSpeed.Y -= 2;
                currentPacTexture = pacUpTexture;
            }

            if (keyboardState.IsKeyDown(Keys.Down)) 
            {
                pacSpeed.Y += 2;
                currentPacTexture = pacDownTexture;
            }
            pacRect.Offset(pacSpeed);

            if (pacRect.Intersects(coinRect)) 
            {
                coinRect.Location = new Point(800, 480);


            }

            if (pacRect.Intersects(exitRect)) 
            {
                Exit();
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(barrierTexture, barrierRect1, Color.White);
            _spriteBatch.Draw(barrierTexture, barrierRect2, Color.White);
            _spriteBatch.Draw(exitTexture, exitRect, Color.White);
            _spriteBatch.Draw(currentPacTexture, pacRect, Color.White);
            _spriteBatch.Draw(coinTexture, coinRect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
