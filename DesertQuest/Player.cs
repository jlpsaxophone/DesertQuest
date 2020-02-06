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
    public class Player
    {
        DesertQuest game;

        public BoundingRectangle bounds = new BoundingRectangle();

        Texture2D texture;

        public Player(DesertQuest game)
        {
            this.game = game;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("wizard");
            bounds.Width = 84;
            bounds.Height = 126;
            bounds.X = 0;
            bounds.Y = game.GraphicsDevice.Viewport.Height / 2 - bounds.Height / 2;
        }

        public void Update(GameTime timeSpan)
        {
            var newKeyboardState = Keyboard.GetState();
            if (newKeyboardState.IsKeyDown(Keys.Up))
            {
                bounds.Y -= (float)(.5*timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Down))
            {
                bounds.Y += (float)(.5*timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                bounds.X -= (float)(.5*timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                bounds.X += (float)(.5*timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (bounds.Y < 0) bounds.Y = 0;
            if (bounds.Y > game.GraphicsDevice.Viewport.Height - bounds.Height) bounds.Y = game.GraphicsDevice.Viewport.Height - bounds.Height;
            if (bounds.X < 0) bounds.X = 0;
            if (bounds.X > game.GraphicsDevice.Viewport.Width - bounds.Width) bounds.X = game.GraphicsDevice.Viewport.Width - bounds.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
