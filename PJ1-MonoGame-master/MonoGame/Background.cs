using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame
{
    public class Background : GameObject
    {
        public override void Load(ContentManager content)
        {
            animation.LoadTextures(content, new string[] { "BG" });
        }
    }
}
