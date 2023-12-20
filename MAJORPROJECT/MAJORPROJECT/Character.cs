using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MAJORPROJECT
{
    public class Character
    {
        private Texture2D _character;
        public Vector2 Position;
        public Vector2 Velocity;
        public Rectangle Edge;
        public bool CharacterStopped = false;

        public float Speed = 5f;  //Setting the speed/how far the sprite travels with one press of a button

        bool hasJumped;

        readonly Vector2 Gravity = new Vector2(0, -9.8f);


        public Character(Texture2D character)
        {
            _character = character;     //Creating a new variable for the texture
            hasJumped = true;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) //Moving Sprite Up
            {
                Position.Y += Speed;
                if (CharacterStopped == true & Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    CharacterStopped = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) //Moving Sprite Left
            {
                Position.X -= Speed;
                if (CharacterStopped == true & Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    CharacterStopped = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) //Moving Sprite Down
            {
                Position.Y += Speed;
                if (CharacterStopped == true & Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    CharacterStopped = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) //Moving Sprite Right
            {
                Position.X += Speed;
                if (CharacterStopped == true & Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    CharacterStopped = false;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                // VelocityY += Gravity * DeltaTime;
                //Position.Y -= VelocityY * DeltaTime;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                Position.Y += Gravity;
            }

            Edge = new Rectangle((int)Position.X, (int)Position.Y, 22, 46);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_character, Position, Color.White);  //Drawing the sprite onto the game space
        }
    }


}