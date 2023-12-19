using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Principal;

namespace Major_Projects
{
    public class Game1 : Game
    {
       GraphicsDeviceManager graphics;
       SpriteBatch _spriteBatch;
       //Background _Background;

       Random rnd = new Random();  //Creating a random variable

       Character _MainCharacter;     //Creating a new variable for the main controllable character

       List<Texture2D> Backgrounds = new List<Texture2D>();
       List<Grass> platform = new List<Grass>();

       

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;

            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;  //Allowing the game to be played in fullscreen
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Backgrounds.Add(Content.Load<Texture2D>("Background"));
                      
            int rnd_x = rnd.Next(1,500);   //Creating random values so the sprite can spawn at a random part of the game screen
            int rnd_y = rnd.Next(1,500);

            var character = Content.Load<Texture2D>("character");   //Loading in the sprite
            
            _MainCharacter = new Character(character);       //Assgin _MainCharacter to the sprite
            _MainCharacter.Position = new Vector2(rnd_x, rnd_x);  //Setting the starting position of the sprite
        }

        protected override void Update(GameTime gameTime)
        {
            _MainCharacter.Update();  //Updating _MainCharacter
            base.Update(gameTime);


            if (Keyboard.GetState().IsKeyDown(Keys.Tab))  //Allows the user to go from fullscreen to windowed
            {
                graphics.PreferredBackBufferHeight = 720;
                graphics.PreferredBackBufferWidth = 1280;
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.CapsLock))  //Allows the user to go from windowed to fullscreen
            {
                graphics.PreferredBackBufferHeight = 1080;
                graphics.PreferredBackBufferWidth = 1920;
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }

            if(platform.Count < 25)
            {
                int rnd_x = rnd.Next(1, 500);   //Creating random values so the sprite can spawn at a random part of the game screen
                int rnd_y = rnd.Next(1, 500);
                int ScreenWidth = Window.ClientBounds.Width;
                int ScreenHeight = Window.ClientBounds.Height;
                Vector2 Location = new Vector2(rnd.Next(0, ScreenWidth), rnd.Next(0, ScreenHeight));
                Grass NewGrass = new Grass(Location);
                NewGrass.LoadContent(Content);
                platform.Add(NewGrass);
            }   
            
            foreach(Grass Item in platform)
            {
                if (Item.Edge.Intersects(_MainCharacter.Edge))
                {
                    _MainCharacter.CharacterStopped = true;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            Rectangle newRect = new Rectangle(0, 0, 2000, 1000);
            _MainCharacter.Draw(_spriteBatch);  //Allows for the sprite to be physcially drawn onto the game space

            _spriteBatch.Draw(Backgrounds[0], newRect, Color.White);
            

            foreach(Grass Item in platform)
            {
                Item.Draw(_spriteBatch);
            }
                     
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}