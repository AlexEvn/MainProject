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
    public class Platforms
    {
        public Vector2 Location;
        protected Texture2D _grass;
        public Rectangle Edge;

        public virtual void LoadContent(ContentManager Content)
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_grass, Location, Color.White);
        }
    }


}
