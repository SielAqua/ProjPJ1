using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Player : GameObject
    {
        public Animation animacaoParado = new Animation();
        public Animation animacaoAndando = new Animation();

        public int indiceAnimacao = 0;
        public int indiceAnimacao2 = 0;

        public double contadorTempo = 0.0;
        public double contadorTempo2 = 0.0;

        public bool olhandoDireita;
        public bool estaAndando;

        public override void Load(ContentManager content)
        {
            animacaoParado.LoadTextures(content, new string[] { "megaman1", "megaman5" });

            animacaoAndando.LoadTextures(content, new string[] { "megaman2", "megaman3", "megaman4" });
           
        }

        public void TentaAtirar(GameObject tiro)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                tiro.position = position;

                if (olhandoDireita)
                {
                    tiro.velocity = new Vector2(1000.0f, 0.0f);
                    tiro.position.X += 20.0f;
                }
                else
                {
                    tiro.velocity = new Vector2(-1000.0f, 0.0f);
                    tiro.position.X -= 20.0f;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 4.0f;
                olhandoDireita = true;
                estaAndando = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 4.0f;
                olhandoDireita = false;
                estaAndando = true;
            }
            else
            {
                estaAndando = false;
            }

            animacaoParado.Animate(gameTime);
            animacaoParado.animationTime = 100;

            animacaoAndando.Animate(gameTime);
            animacaoParado.animationTime = 100;
        }




        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects flip;
            if (olhandoDireita)
                flip = SpriteEffects.FlipHorizontally;
            else
                flip = SpriteEffects.None;

            Texture2D texture;
            if (estaAndando)
            {
                texture = animacaoAndando.GetAnimationFrame();
            }
            else
            {
                texture = animacaoParado.GetAnimationFrame();
            }

            spriteBatch.Draw(texture, position, null, color, 0.0f,
                Vector2.Zero, 5.0f, flip, 0.0f);
        }
    }

}