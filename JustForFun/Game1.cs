using JustForFun.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projekt;

namespace JustForFun
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TextureMananger textureManager;
        GameManager gameManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            textureManager = new TextureMananger();
            gameManager = new GameManager();
        }

 
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Fixed.windowWidth;
            graphics.PreferredBackBufferHeight = Fixed.windowHeight;
            graphics.ApplyChanges();
            //  gameManager.Load();
            textureManager.LoadTexture(Content);
            gameManager.Initi();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

       
        }

        protected override void UnloadContent()
        {   
           
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyMouseReader1.Update();
            gameManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

     
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.End();
            gameManager.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
