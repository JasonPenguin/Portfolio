using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
using TowerDefence.Resources;


namespace TowerDefence
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public enum GameState
        {
            MainMenu,
            GamePlay,
            Win,
            GameOver,
        }

        SpriteBatch spritebatch;





        GameState CurrentState = GameState.MainMenu;

        public Game1()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
           
            Content.RootDirectory = "Content";
            

        }

        protected override void Initialize()
        {
            //game window size 
            IsMouseVisible = true;
            Globals.GameSize = new Vector2(12 * 84, 84 + 7 * 84);
            Globals.Graphics.PreferredBackBufferWidth = (int)Globals.GameSize.X;
            Globals.Graphics.PreferredBackBufferHeight = (int)Globals.GameSize.Y;
            Globals.Graphics.ApplyChanges();

            Globals.BackBuffer = new RenderTarget2D(Globals.Graphics.GraphicsDevice, (int)Globals.GameSize.X, (int)Globals.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None, 0,RenderTargetUsage.PreserveContents);
            spritebatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
               
            
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.Content = this.Content;

            Textures.Load();
            Fonts.Load();
        }

     

        protected override void UnloadContent()
        {
            
        }

       
        protected override void Update(GameTime gameTime)
        {
            //game states
            Globals.GameTime = gameTime;
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        CurrentState = GameState.GamePlay;
                    break;
                   
                case GameState.GamePlay:
                    if (Player.lives <= 0)
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
                Textures.player.Update(gameTime,Textures.enemies,Textures.Waterenemies);
                Textures.Flytrap.Update(gameTime);
                Textures.ElecFence.Update(gameTime);
                Textures.BaseballBat.Update(gameTime);
                Textures.waterWavemanager.Update(gameTime);
                Textures.gamemanager.Update(gameTime);
                Textures.racoonmanager.Update(gameTime);
                Textures.BearTrap.Update(gameTime);
            }


            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.Graphics.GraphicsDevice.SetRenderTarget(null);
            base.Draw(gameTime);
            if (CurrentState == GameState.Win)
            {
                spritebatch.Begin();
                spritebatch.End();
            }

            if (CurrentState == GameState.MainMenu)
            {
                spritebatch.Begin();
                spritebatch.Draw(Textures.startscherm, new Vector2(Textures.level.Width / 2 - 5, Textures.level.Heigth / 2 - 5), Color.White);
                spritebatch.End();
            }

            if (CurrentState == GameState.GamePlay)
            {
                spritebatch.Begin();
                spritebatch.Draw(Textures.background, new Rectangle(Textures.level.Width / 2 - 5, Textures.level.Heigth / 2 - 5, 1008, 672), Color.White);
                spritebatch.End();
                Globals.SpriteBatch.Begin();
                Textures.waterWavemanager.Draw(Globals.SpriteBatch);
                Textures.waveManager.Draw(Globals.SpriteBatch);
                Globals.SpriteBatch.End();

                Globals.SpriteBatch.Begin();
                Globals.SpriteBatch.Draw(Textures.foreground, new Rectangle(Textures.level.Width / 2-5, Textures.level.Heigth / 2 - 5, 1008, 672), Color.White);
                Globals.SpriteBatch.End();

                Globals.SpriteBatch.Begin();
                Textures.player.Draw(Globals.SpriteBatch);
                Textures.toolbar.Draw(Globals.SpriteBatch, Textures.player);
                Textures.gamemanager.Draw(Globals.SpriteBatch);
                Textures.racoonmanager.Draw(Globals.SpriteBatch);
                Textures.Flytrap.Draw(Globals.SpriteBatch);
                Textures.ElecFence.Draw(Globals.SpriteBatch);
                Textures.BearTrap.Draw(Globals.SpriteBatch);
                Textures.BaseballBat.Draw(Globals.SpriteBatch);
                Globals.SpriteBatch.End();
            }

            if (CurrentState == GameState.GameOver)
            {
                spritebatch.Begin();
                spritebatch.Draw(Textures.lose, new Vector2(Textures.level.Width / 2 - 5, Textures.level.Heigth / 2-5), Color.White);
                //spritebatch.Draw(Textures.Livedecay, new Rectangle(200, 10, 35, 33), Color.White);
                spritebatch.End();
            }
        }
    }
}
