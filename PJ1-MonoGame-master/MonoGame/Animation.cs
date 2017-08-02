using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Animation
    {
        public double contadorTempo = 0.0;
        public int indiceAnimacao = 0;
        public Texture2D[] textureAnimation;
        public int animationFrames;
        public double animationTime;

        public virtual void LoadTextures(ContentManager content, string[] textureNames)
        {
            textureAnimation = new Texture2D[textureNames.Length];

            for (int i = 0; i < textureNames.Length; i++)
            {
                textureAnimation[i] = content.Load<Texture2D>(textureNames[i]);
            }
        }

        public void Animate(GameTime gameTime)
        {
            contadorTempo += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (contadorTempo > animationTime)
            {
                indiceAnimacao += 1;
                if (indiceAnimacao == textureAnimation.Length)
                    indiceAnimacao = 0;

                contadorTempo = 0.0;
            }
        }

        public Texture2D GetAnimationFrame()
        {
            return textureAnimation[indiceAnimacao];
        }

    }
}
