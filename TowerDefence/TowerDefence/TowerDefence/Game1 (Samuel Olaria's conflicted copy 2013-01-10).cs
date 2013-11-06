using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using TowerDefence.Management;
using TowerDefence.Towers;
using TowerDefence.GUI;
using TowerDefence.Screens;
using TowerDefence.Resources;
using TowerDefence.Tiles;

namespace TowerDefence
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public enum GameState
        {
            MainMenu,
            GamePlay,
            Pause,
            GameOver,
        }

        GameState CurrentState = GameState.GamePlay;

        public Game1()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            Globals.GameSize = new Vector2(12 * 84, 84 + 8 * 84);
            Globals.Graphics.PreferredBackBufferWidth = (int)Globals.GameSize.X;
            Globals.Graphics.PreferredBackBufferHeight = (int)Globals.GameSize.Y;
            Globals.Graphics.ApplyChanges();

            Globals.BackBuffer = new RenderTarget2D(Globals.Graphics.GraphicsDevice, (int)Globals.GameSize.X, (int)Globals.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None, 0,RenderTargetUsage.PreserveContents);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.Content = this.Content;

            Textures.Load();
            Fonts.Load();
            Texture2D bulletTexture = Content.Load<Texture2D>("Bulletsprite");
        }

     

        protected override void UnloadContent()
        {
            
        }

       
        protected override void Update(GameTime gameTime)
        {
            Globals.GameTime = gameTime;
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        CurrentState = GameState.GamePlay;
                    break;
                   
                case GameState.GamePlay:
                    if (Keyboard.GetState().IsKeyDown(Keys.Space))
                        CurrentState = GameState.GameOver;
                    break;

                case GameState.GameOver:
                    if (Keyboard.GetState().IsKeyDown(Keys.R))
                        CurrentState = GameState.GamePlay;
                    break;
            }

            if (CurrentState == GameState.GamePlay)
            {
                Textures.waveManager.Update(gameTime);
                Textures.player.Update(gameTime, Textures.waveManager.Enemies);
                Textures.arrowButton.Update(gameTime);
                Textures.PsnGasButton.Update(gameTime);
            }
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            Globals.Graphics.GraphicsDevice.SetRenderTarget(null);

            Globals.SpriteBatch.Begin();
            Globals.SpriteBatch.Draw(Globals.BackBuffer, new Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), Color.White);
            Textures.level.Draw(Globals.SpriteBatch);
            Textures.player.Draw(Globals.SpriteBatch);
            Textures.waveManager.Draw(Globals.SpriteBatch);
            Textures.toolbar.Draw(Globals.SpriteBatch, Textures.player);
            Textures.arrowButton.Draw(Globals.SpriteBatch);
            Textures.PsnGasButton.Draw(Globals.SpriteBatch);
            Globals.SpriteBatch.End();

            
        }
    }
}
