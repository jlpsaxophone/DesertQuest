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
    public class Snake
    {
        DesertQuest game;
        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;
        bool up;
        bool direction = true;
        float furthest;
        float closest;

        public Snake(DesertQuest game, float x, float y, bool up, float furthest, float closest)
        {
            this.game = game;
            bounds.X = x;
            bounds.Y = y;
            this.up = up;
            this.furthest = furthest;
            this.closest = closest;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("snake");
            bounds.Width = 81;
            bounds.Height = 74;
        }

        public void Update(GameTime timeSpan)
        {
            if(up)
            {
                if (direction)
                {
                    if (bounds.Y > furthest)
                    {
                        direction = !direction;
                    }
                    else
                    {
                        bounds.Y += (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
                    }
                }
                else
                {
                    if (bounds.Y < closest)
                    {
                        direction = !direction;
                    }
                    else
                    {
                        bounds.Y -= (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
                    }
                }
            }
            else
            {
                if(direction)
                {
                    if (bounds.X > furthest)
                    {
                        direction = !direction;
                    }
                    else
                    {
                        bounds.X += (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
                    }                   
                }
                else
                {
                    if (bounds.X < closest)
                    {
                        direction = !direction;
                    }
                    else
                    {
                        bounds.X -= (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
                    }
                }              
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
