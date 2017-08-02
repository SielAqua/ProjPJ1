using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Player player;

        private GameObject[] objetos;

		public Game1()
		{
			graphics = new GraphicsDeviceManager( this );
			graphics.SynchronizeWithVerticalRetrace = false;

			Content.RootDirectory = "Content";

			player = new Player();
            player.position = new Vector2(100.0f, 100.0f);

            int numeroObjetos = 4;
            objetos = new GameObject[numeroObjetos];

            objetos[1] = new Tiro();
            objetos[1].scale = 0.1f;

            objetos[2] = player;

            objetos[3] = new Ball();
            objetos[3].position = new Vector2(999999.0f, 999999.0f);
            objetos[3].texture = "megaman1";
            objetos[3].scale = 5.0f;
        }

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			Viewport viewport = graphics.GraphicsDevice.Viewport;
			//ball.screenSize = new Vector2( viewport.Width, viewport.Height );

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch( GraphicsDevice );

            // TODO: use this.Content to load your game content here
            foreach (GameObject obj in objetos)
            {
                obj.Load(Content);
            }
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update( GameTime gameTime )
		{
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				Exit();

			// TODO: Add your update logic here
            player.TentaAtirar(objetos[3]);

            foreach (GameObject obj in objetos)
            {
                obj.Update(gameTime);
            }

            base.Update( gameTime );
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw( GameTime gameTime )
		{
            GraphicsDevice.Clear( Color.Chocolate );

			// TODO: Add your drawing code here
			spriteBatch.Begin();

            foreach( GameObject obj in objetos )
            {
                obj.Draw( spriteBatch );
            }

			spriteBatch.End();

			base.Draw( gameTime );
		}
	}
}
