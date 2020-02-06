using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;  

namespace DesertQuest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class DesertQuest : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random = new Random();
        int lives = 3;
        
        Player player;
        Tumbleweed tumbleweed1;
        Tumbleweed tumbleweed2;
        Tumbleweed tumbleweed3;
        Snake snake1;
        Snake snake2;
        Snake snake3;
        Cactus cactus1;
        Cactus cactus2;
        Cactus cactus3;
        Cactus cactus4;
        Cactus cactus5;
        Cactus cactus6;
        Cactus cactus7;
        Diamond diamond1;
        Diamond diamond2;
        Diamond diamond3;
        bool diamond1collected = false;
        bool diamond2collected = false;
        bool diamond3collected = false;
        Heart life1;
        Heart life2;
        Heart life3;
        PlayerMessage youwin;
        PlayerMessage gameover;
        
        KeyboardState newKeyboardState;
        KeyboardState oldKeyboardState;

        public DesertQuest()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player(this);
            cactus1 = new Cactus(this, graphics, 50, 800);
            cactus2 = new Cactus(this, graphics, 150, 50);
            cactus3 = new Cactus(this, graphics, 300, 450);
            cactus4 = new Cactus(this, graphics, 760, 590);
            cactus5 = new Cactus(this, graphics, 1200, 550);
            cactus6 = new Cactus(this, graphics, 800, 9);
            cactus7 = new Cactus(this, graphics, 900, 160);
            snake1 = new Snake(this, 20, 290, false, 700, 20);
            snake2 = new Snake(this, 330, 620, false, 679, 290);
            snake3 = new Snake(this, 1050, 230, true, 850, 220);
            diamond1 = new Diamond(this, 620, 230);
            diamond2 = new Diamond(this, 900, 50);
            diamond3 = new Diamond(this, 600, 870);
            life1 = new Heart(this, 10, 10);
            life2 = new Heart(this, 70, 10);
            life3 = new Heart(this, 130, 10);
            youwin = new PlayerMessage(this, 2);
            gameover = new PlayerMessage(this, 1);
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //graphics.PreferredBackBufferWidth = 1042;
            //graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1302;
            graphics.PreferredBackBufferHeight = 960;
            graphics.ApplyChanges();

            tumbleweed1 = new Tumbleweed(this, graphics, random.NextDouble(), random.NextDouble(), 650, 0);
            tumbleweed2 = new Tumbleweed(this, graphics, random.NextDouble(), random.NextDouble(), 1200, 0);
            tumbleweed3 = new Tumbleweed(this, graphics, random.NextDouble(), random.NextDouble(), 950, 890);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            tumbleweed1.LoadContent(Content);
            tumbleweed2.LoadContent(Content);
            tumbleweed3.LoadContent(Content);
            snake1.LoadContent(Content);
            snake2.LoadContent(Content);
            snake3.LoadContent(Content);
            cactus1.LoadContent(Content);
            cactus2.LoadContent(Content);
            cactus3.LoadContent(Content);
            cactus4.LoadContent(Content);
            cactus5.LoadContent(Content);
            cactus6.LoadContent(Content);
            cactus7.LoadContent(Content);
            diamond1.LoadContent(Content);
            diamond2.LoadContent(Content);
            diamond3.LoadContent(Content);
            life1.LoadContent(Content);
            life2.LoadContent(Content);
            life3.LoadContent(Content);
            youwin.LoadContent(Content);
            gameover.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            newKeyboardState = Keyboard.GetState();

            if (newKeyboardState.IsKeyDown(Keys.Escape)) Exit();

            player.Update(gameTime);
            tumbleweed1.Update(gameTime);
            tumbleweed2.Update(gameTime);
            tumbleweed3.Update(gameTime);
            snake1.Update(gameTime);
            snake2.Update(gameTime);
            snake3.Update(gameTime);
            base.Update(gameTime);

            //check collisions
            if(Collisions.CollidesWith(player.bounds, tumbleweed1.bounds) 
                || Collisions.CollidesWith(player.bounds, tumbleweed2.bounds)
                || Collisions.CollidesWith(player.bounds, tumbleweed3.bounds)
                || Collisions.CollidesWith(player.bounds, snake1.bounds)
                || Collisions.CollidesWith(player.bounds, snake2.bounds)
                || Collisions.CollidesWith(player.bounds, snake3.bounds))
            {
                Initialize();
                LoadContent();
                Draw(gameTime);
                lives--;
                            
            }
            if(Collisions.CollidesWith(player.bounds, cactus1.bounds)
                || Collisions.CollidesWith(player.bounds, cactus2.bounds)
                || Collisions.CollidesWith(player.bounds, cactus3.bounds)
                || Collisions.CollidesWith(player.bounds, cactus4.bounds)
                || Collisions.CollidesWith(player.bounds, cactus5.bounds)
                || Collisions.CollidesWith(player.bounds, cactus6.bounds)
                || Collisions.CollidesWith(player.bounds, cactus7.bounds)) 
            {
                Initialize();
                LoadContent();
                Draw(gameTime);
                lives--;               
            } 
            if(Collisions.CollidesWith(player.bounds, diamond1.bounds))
            {
                diamond1collected = true;
            }
            if (Collisions.CollidesWith(player.bounds, diamond2.bounds))
            {
                diamond2collected = true;
            }
            if (Collisions.CollidesWith(player.bounds, diamond3.bounds))
            {
                diamond3collected = true;
            }

            oldKeyboardState = newKeyboardState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PeachPuff);
            
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            tumbleweed1.Draw(spriteBatch);           
            tumbleweed2.Draw(spriteBatch);
            tumbleweed3.Draw(spriteBatch);
            snake1.Draw(spriteBatch);
            snake2.Draw(spriteBatch);
            snake3.Draw(spriteBatch);
            cactus1.Draw(spriteBatch);
            cactus2.Draw(spriteBatch);
            cactus3.Draw(spriteBatch);
            cactus4.Draw(spriteBatch);
            cactus5.Draw(spriteBatch);
            cactus6.Draw(spriteBatch);
            cactus7.Draw(spriteBatch);

            if(!diamond1collected)
            {
                diamond1.Draw(spriteBatch);
            }
            if (!diamond2collected)
            {
                diamond2.Draw(spriteBatch);
            }
            if (!diamond3collected)
            {
                diamond3.Draw(spriteBatch);
            }

            if(lives == 3)
            {
                life3.Draw(spriteBatch);
            }
            if(lives >= 2)
            {
                life2.Draw(spriteBatch);
            }
            if(lives >= 1)
            {
                life1.Draw(spriteBatch);
            }
            if (lives <= 0)
            {
                gameover.Draw(spriteBatch);
                player.bounds.Height = 0;
                player.bounds.Width = 0;
                player.bounds.X = 0;
                player.bounds.Y = 0;
            }
            if(diamond1collected && diamond2collected && diamond3collected)
            {
                youwin.Draw(spriteBatch);
                player.bounds.Height = 0;
                player.bounds.Width = 0;
                player.bounds.X = 0;
                player.bounds.Y = 0;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
