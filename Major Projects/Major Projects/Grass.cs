using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Major_Projects
{
    internal class Grass: Platforms
    {

        public Grass(Vector2 SpawnLocation)
        {
            Location = SpawnLocation;
        }

        public override void LoadContent(ContentManager Content)
        {
            _grass = Content.Load<Texture2D>("Grass");
            Edge = new Rectangle((int)Location.X, (int)Location.Y, _grass.Width, _grass.Height);
        }
        public override void Update()
        {
            
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_grass, Location, Color.White);
        }










    }
}
