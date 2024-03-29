﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace TowerDefence.Animatie 
{
    public class AnimationClass
    {
        public Rectangle[] Rectangles;
        public Color Color = Color.White;
        public Vector2 Origin;
        public float Rotation = 0f;
        public float Scale = 1f;
        public SpriteEffects SpriteEffect;
        public bool IsLooping = true;
        public int Frames;

        public AnimationClass Copy()
        {
            //kopie maken voor de volgende animatie
            AnimationClass ac = new AnimationClass();
            ac.Rectangles = Rectangles;
            ac.Color = Color;
            ac.Origin = Origin;
            ac.Rotation = Rotation;
            ac.Scale = Scale;
            ac.SpriteEffect = SpriteEffect;
            ac.IsLooping = IsLooping;
            ac.Frames = Frames;
            return ac;
        }

    }
}
