using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AulaXNA3D001
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        _Screen screen;
        _Camera camera;
        _Triangle triangle;
        _Moinho moinho;
        Matrix world;
        public Texture2D texture;
        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            world = Matrix.Identity;
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();

            this.triangle = new _Triangle(GraphicsDevice);
            this.moinho = new _Moinho(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Não queria achar as Texturas
            //this.texture = Content.Load<Texture2D>(@"Textures\G");
            //this.madeira = Content.Load<Texture2D>(@"Textures\Wood");
            //this.metal = Content.Load<Texture2D>(@"Textures\Metal");
        }

        protected override void UnloadContent()
        {
           //this.texture.Dispose();
           //this.madeira.Dispose();
           //this.metal.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();            

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.triangle.Draw(this.camera);
            this.moinho.Draw(this.camera, new Vector3(4, 0, -4),-35, new Vector3(3.3f, 0.5f, -4),1);
            this.moinho.Draw(this.camera, new Vector3(-4, 0, -4), 35, new Vector3(-3.3f, 0.5f, -4),2);
           

            base.Draw(gameTime);
        }
    }
}
