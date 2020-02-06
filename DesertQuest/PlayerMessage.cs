using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace DesertQuest
{
    public class PlayerMessage
    {
        DesertQuest game;

        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;

        int type;

        public PlayerMessage(DesertQuest game, int type)
        {
            this.game = game;
            this.type = type;
        }
        public void LoadContent(ContentManager content)
        {
            if(type == 1)
            {
                texture = content.Load<Texture2D>("gameover");
            }
            if(type == 2)
            {
                texture = content.Load<Texture2D>("youwin");
            }          
            bounds.Width = 497;
            bounds.Height = 70;
            bounds.X = 402;
            bounds.Y = 445;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(texture, bounds, Color.White);                   
        }
    }
}
