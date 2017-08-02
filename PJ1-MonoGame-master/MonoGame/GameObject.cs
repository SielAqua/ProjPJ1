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
    public class GameObject
    {
        public Vector2 position = new Vector2(0.0f, 0.0f);
        public Vector2 velocity = new Vector2(0.0f, 0.0f);
        public float scale = 1.0f;

        public Animation animation = new Animation();

        public Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        public virtual void Load(ContentManager content)
        {
        }

        public virtual void Update(GameTime gameTime )
        {
            animation.Animate(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = animation.GetAnimationFrame();
            spriteBatch.Draw(texture, position, null, color,
                0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
        }
    }
}
