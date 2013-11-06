﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence.GUI
{
    public enum ButtonStatus
    {
        Normal,
        MouseOver,
        Pressed,
    }

    public class Button : Sprite
    {
        private MouseState previousState;

        private Texture2D hoverTexture;
        private Texture2D pressedTexture;

        private ButtonStatus state = ButtonStatus.Normal;
        private string buttontype;
        private Player player;

        public static bool available = true;
        public static bool Visible = false;

        public event EventHandler Clicked;

        public Button(Texture2D texture, Texture2D hoverTexture, Texture2D pressedTexture, Vector2 position,Player player,string buttontype)
            : base(texture, position)
        {
            this.hoverTexture = hoverTexture;
            this.pressedTexture = pressedTexture;
            this.buttontype = buttontype;

            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            this.Clicked += new EventHandler(Button_Clicked);
            this.player = player;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (available)
            {
                //button states
                int mouseX = mouseState.X;
                int mouseY = mouseState.Y;

                bool isMouseOver = bounds.Contains(mouseX, mouseY);

                if (isMouseOver && state != ButtonStatus.Pressed)
                {
                    state = ButtonStatus.MouseOver;
                }

                else if (isMouseOver == false && state != ButtonStatus.Pressed)
                {
                    state = ButtonStatus.Normal;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
                {
                    if (isMouseOver == true)
                    {
                        state = ButtonStatus.MouseOver;

                        if (Clicked != null)
                        {
                            Clicked(this, EventArgs.Empty);
                        }
                    }

                    else if (state == ButtonStatus.Pressed)
                    {
                        state = ButtonStatus.Normal;
                    }
                }

                previousState = mouseState;
            }

        }

        private void Button_Clicked(object sender,EventArgs e)
        {
            //button type voor het aanroepen van nieuwe toren
            switch (buttontype)
            {
                case "Fly Trap":
                    player.NewTowerType = "Fly Trap";
                    break;
                case "Fence":
                    player.NewTowerType = "Fence";
                    break;
                case"Bear Trap":
                    player.NewTowerType = "Bear Trap";
                    break;
                case"BaseballBat":
                    player.NewTowerType = "BaseballBat";
                    break;
                        
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (available)
            {
                if (Visible)
                {
                    switch (state)
                    {
                        case ButtonStatus.Normal:
                            spriteBatch.Draw(texture,bounds, Color.White);
                            break;

                        case ButtonStatus.MouseOver:
                            spriteBatch.Draw(hoverTexture, bounds, Color.White);
                            break;

                        case ButtonStatus.Pressed:
                            spriteBatch.Draw(pressedTexture, bounds, Color.White);
                            break;

                        default:
                            spriteBatch.Draw(texture,bounds, Color.White);
                            break;
                    }
                }
            }
        }
    }
}
