using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace OysterGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D Level1Boat;
        private Texture2D Map;
        private Texture2D GUI;
        MouseState mouseState = Mouse.GetState();
        private Texture2D BoatPath;
        private MouseState newState;
        private MouseState oldState;
        private Vector2 mousepos;
       

        public Game1()
        {
            
            this.IsMouseVisible = true;
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
            Level1Boat = Content.Load<Texture2D>("Level 1 Boat");
            BoatPath = Content.Load<Texture2D>("BoatPath");
            Map = Content.Load<Texture2D>("First Map");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        /// <summary>
        /// This method moves the sprite
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveSprite(float x, float y)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Map, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(Level1Boat, new Vector2(x, y), Color.White);
            spriteBatch.Draw(BoatPath, mousepos, Color.White);
            spriteBatch.End();
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            newState = Mouse.GetState();
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                mousepos = new Vector2(mouseState.X, mouseState.Y);
                MoveSprite(mousepos.X, mousepos.Y);
            }
            oldState = newState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            
            spriteBatch.Draw(Map, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.Draw(Level1Boat, new Vector2(400, 200), Color.White);
            spriteBatch.Draw(BoatPath, mousepos, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here
      
            

            base.Draw(gameTime);
        }
    }
}
